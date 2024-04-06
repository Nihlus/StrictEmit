//
//  SPDX-FileName: ILGeneratorExtensions.Calls.cs
//  SPDX-FileCopyrightText: Copyright (c) Jarl Gullberg
//  SPDX-License-Identifier: GPL-3.0-or-later
//

#pragma warning disable SA1513

using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using static System.Reflection.CallingConventions;

namespace StrictEmit
{
    /// <summary>
    /// Extension methods for the <see cref="ILGenerator"/> class.
    /// </summary>
    [PublicAPI]
    public static partial class ILGeneratorExtensions
    {
        /// <summary>
        /// Calls the constructor on the given type indicated by the (optional) parameter type set.
        /// </summary>
        /// <typeparam name="T">The type in which the constructor exists.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="parameterTypes">The parameter types of the constructor.</param>
        /// <exception cref="EntryPointNotFoundException">Thrown if no matching constructor can be found.</exception>
        public static void EmitCallConstructorDirect<T>(this ILGenerator il, params Type[] parameterTypes)
        {
            var type = typeof(T);
            var constructor = type.GetConstructor(parameterTypes);

            if (constructor is null)
            {
                throw new EntryPointNotFoundException("No constructor with those parameters could be found.");
            }

            il.EmitCallDirect(constructor);
        }

        /// <summary>
        /// Calls a late-bound constructor on the given type indicated by the (optional) parameter type set.
        /// </summary>
        /// <typeparam name="T">The type in which the constructor exists.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="parameterTypes">The parameter types of the constructor.</param>
        /// <exception cref="EntryPointNotFoundException">Thrown if no matching constructor can be found.</exception>
        public static void EmitCallConstructorVirtual<T>(this ILGenerator il, params Type[] parameterTypes)
        {
            var type = typeof(T);
            var constructor = type.GetConstructor(parameterTypes);

            if (constructor is null)
            {
                throw new EntryPointNotFoundException("No constructor with those parameters could be found.");
            }

            il.EmitCallVirtual(constructor);
        }

        /// <summary>
        /// Puts a Calli instruction onto the Microsoft intermediate language (MSIL) stream, specifying a managed
        /// calling convention for the indirect call.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="callingConventions">
        /// The managed calling conventions of the function pointer on the stack. <see cref="CallingConventions.VarArgs"/>
        /// may be omitted; it will be added automatically if needed.
        /// </param>
        /// <param name="returnType">The return type of the managed function pointer. Defaults to void.</param>
        /// <param name="parameterTypes">The parameter types of the managed function pointer.</param>
        /// <param name="optionalParameterTypes">The optional parameter types of the managed function pointer.</param>
        public static void EmitCallIndirect
        (
            this ILGenerator il,
            CallingConventions callingConventions,
            Type returnType,
            Type[] parameterTypes,
            Type[] optionalParameterTypes
        )
        {
            if (!callingConventions.HasFlag(VarArgs))
            {
                callingConventions |= VarArgs;
            }

            il.EmitCalli(OpCodes.Calli, callingConventions, returnType, parameterTypes, optionalParameterTypes);
        }

        /// <summary>
        /// Puts a Calli instruction onto the Microsoft intermediate language (MSIL) stream, specifying a managed
        /// calling convention for the indirect call.
        ///
        /// This method will use the unmanaged calling convention overload if available, and if not, fall back to the
        /// managed calling convention overload. This is done for backwards compatibility with Mono and the .NET
        /// Framework, which implement this overload. .NET Core does not implement it before version 2.1, and this
        /// method may therefore produce unexpected results on versions 2.0 and prior. In particular, it will default to
        /// the __fastcall unmanaged calling convention. As calling conventions are ignored on non-x86 platforms, this
        /// is usually not an issue.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="callingConventions">The managed calling conventions of the function pointer on the stack.</param>
        /// <param name="returnType">The return type of the managed function pointer. Defaults to void.</param>
        /// <param name="parameterTypes">The parameter types of the managed function pointer.</param>
        public static void EmitCallIndirect
        (
            this ILGenerator il,
            CallingConventions callingConventions,
            Type? returnType = null,
            params Type[] parameterTypes
        )
        {
            returnType ??= typeof(void);

            il.EmitCalli(OpCodes.Calli, callingConventions, returnType, parameterTypes, null);
        }

        /// <summary>
        /// Puts a Calli instruction onto the Microsoft intermediate language (MSIL) stream, specifying an unmanaged
        /// calling convention for the indirect call.
        ///
        /// This method will use the unmanaged calling convention overload if available, and if not, fall back to the
        /// managed calling convention overload. This is done for backwards compatibility with Mono and the .NET
        /// Framework, which implement this overload. .NET Core does not implement it before version 2.1, and this
        /// method may therefore produce unexpected results on versions 2.0 and prior. In particular, it will default to
        /// the __fastcall unmanaged calling convention. As calling conventions are ignored on non-x86 platforms, this
        /// is usually not an issue.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="callingConvention">The unmanaged calling convention of the function pointer on the stack.</param>
        /// <param name="returnType">The return type of the unmanaged function pointer. Defaults to void.</param>
        /// <param name="parameterTypes">The parameter types of the unmanaged function pointer.</param>
        public static void EmitCallIndirect
        (
            this ILGenerator il,
            CallingConvention callingConvention,
            Type? returnType = null,
            params Type[] parameterTypes
        )
        {
            returnType ??= typeof(void);

            var calliOverload = typeof(ILGenerator).GetMethod
            (
                nameof(ILGenerator.EmitCalli),
                new[] { typeof(OpCode), typeof(CallingConvention), typeof(Type), typeof(Type[]) }
            );

            if (calliOverload is null)
            {
                // Use the existing overload - things may break
                il.EmitCalli(OpCodes.Calli, Standard, returnType, parameterTypes, null);
            }
            else
            {
                // Use the correct overload via reflection
                calliOverload.Invoke(il, new object[] { OpCodes.Calli, callingConvention, returnType, parameterTypes });
            }
        }

        /// <summary>
        /// Calls the method in the given type, indicated by its name (and optionally, its parameters).
        /// </summary>
        /// <typeparam name="T">The type in which the method exists.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="functionName">The name of the function.</param>
        /// <param name="parameterTypes">The parameter types of the function.</param>
        /// <exception cref="EntryPointNotFoundException">Thrown if no matching method can be found.</exception>
        public static void EmitCallDirect<T>
        (
            this ILGenerator il,
            string functionName,
            params Type[] parameterTypes
        )
        {
            var type = typeof(T);
            var method = type.GetMethod(functionName, parameterTypes);

            if (method is null)
            {
                throw new EntryPointNotFoundException("No method with that name and parameter combination could be found.");
            }

            il.EmitCallDirect(method);
        }

        /// <summary>
        /// Calls a late-bound method on an object, pushing the return value onto the evaluation stack. The method is
        /// resolved in the given type, indicated by its name (and optionally, its parameters).
        /// </summary>
        /// <typeparam name="T">The type in which the method exists.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="functionName">The name of the function.</param>
        /// <param name="parameterTypes">The parameter types of the function.</param>
        /// <exception cref="EntryPointNotFoundException">Thrown if no matching method can be found.</exception>
        public static void EmitCallVirtual<T>
        (
            this ILGenerator il,
            string functionName,
            params Type[] parameterTypes
        )
        {
            var type = typeof(T);
            var method = parameterTypes.Length > 0
                ? type.GetMethod(functionName, parameterTypes)
                : type.GetMethod(functionName);

            if (method is null)
            {
                throw new EntryPointNotFoundException("No method with that name and type combination could be found.");
            }

            il.EmitCallVirtual(method);
        }

        /// <summary>
        /// Calls the method indicated by the passed method descriptor.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="method">The method.</param>
        [PublicAPI]
        public static void EmitCallDirect(this ILGenerator il, MethodInfo method)
            => il.Emit(OpCodes.Call, method);

        /// <summary>
        /// Calls the constructor indicated by the passed constructor descriptor.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="constructor">The constructor.</param>
        [PublicAPI]
        public static void EmitCallDirect(this ILGenerator il, ConstructorInfo constructor)
            => il.Emit(OpCodes.Call, constructor);

        /// <summary>
        /// Calls a late-bound method on an object, pushing the return value onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="method">The method.</param>
        [PublicAPI]
        public static void EmitCallVirtual(this ILGenerator il, MethodInfo method)
            => il.Emit(OpCodes.Callvirt, method);

        /// <summary>
        /// Calls a late-bound constructor on an object, pushing the return value onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="constructor">The constructor.</param>
        [PublicAPI]
        public static void EmitCallVirtual(this ILGenerator il, ConstructorInfo constructor)
            => il.Emit(OpCodes.Callvirt, constructor);

        /// <summary>
        /// Attempts to cast an object passed by reference to the specified class.
        /// </summary>
        /// <typeparam name="T">The type to cast the item on the top of the stack to.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitCastClass<T>(this ILGenerator il)
            => il.EmitCastClass(typeof(T));

        /// <summary>
        /// Attempts to cast an object passed by reference to the specified class.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="classType">The type to cast the item on the top of the stack to.</param>
        [PublicAPI]
        public static void EmitCastClass(this ILGenerator il, Type classType)
            => il.Emit(OpCodes.Castclass, classType);

        /// <summary>
        /// Constrains the type on which a virtual method call is made.
        /// </summary>
        /// <typeparam name="T">The type in which the method exists.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitCallVirtualConstrainedPrefix<T>(this ILGenerator il)
            => il.EmitCallVirtualConstrainedPrefix(typeof(T));

        /// <summary>
        /// Constrains the type on which a virtual method call is made.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="typeToConstrainTo">The type in which the method exists.</param>
        [PublicAPI]
        public static void EmitCallVirtualConstrainedPrefix(this ILGenerator il, Type typeToConstrainTo)
            => il.Emit(OpCodes.Constrained, typeToConstrainTo);

        /// <summary>
        /// Pushes an unmanaged pointer (type <strong>native int</strong>) to the native code implementing a specific
        /// method onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="method">The method.</param>
        [PublicAPI]
        public static void EmitLoadFunctionPointer(this ILGenerator il, MethodInfo method)
            => il.Emit(OpCodes.Ldftn, method);

        /// <summary>
        /// Pushes an unmanaged pointer (type <strong>native int</strong>) to the native code implementing a particular
        /// virtual method associated with a specified object onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="method">The method.</param>
        [PublicAPI]
        public static void EmitLoadVirtualFunction(this ILGenerator il, MethodInfo method)
            => il.Emit(OpCodes.Ldvirtftn, method);

        /// <summary>
        /// Specifies that an address currently atop the evaluation stack might be volatile, and the results of reading
        /// that location cannot be cached or that multiple stores to that location cannot be suppressed.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitVolatilePrefix(this ILGenerator il)
            => il.Emit(OpCodes.Volatile);
    }
}
