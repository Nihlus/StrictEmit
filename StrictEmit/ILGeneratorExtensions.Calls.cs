//
//  ILGeneratorExtensions.Calls.cs
//
//  Copyright (c) 2018 Jarl Gullberg
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
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
        public static void EmitCallConstructorDirect<T>([NotNull] this ILGenerator il, params Type[] parameterTypes)
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
        public static void EmitCallConstructorVirtual<T>([NotNull] this ILGenerator il, params Type[] parameterTypes)
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
            [NotNull] this ILGenerator il,
            CallingConventions callingConventions,
            [NotNull] Type returnType,
            [NotNull] Type[] parameterTypes,
            [NotNull] Type[] optionalParameterTypes
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
            [NotNull] this ILGenerator il,
            CallingConventions callingConventions,
            [CanBeNull] Type returnType = null,
            [NotNull] params Type[] parameterTypes
        )
        {
            returnType = returnType ?? typeof(void);

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
            [NotNull] this ILGenerator il,
            CallingConvention callingConvention,
            [CanBeNull] Type returnType = null,
            [NotNull] params Type[] parameterTypes
        )
        {
            returnType = returnType ?? typeof(void);

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
            [NotNull] this ILGenerator il,
            [NotNull] string functionName,
            [NotNull] params Type[] parameterTypes
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
            [NotNull] this ILGenerator il,
            [NotNull] string functionName,
            [NotNull] params Type[] parameterTypes
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
        public static void EmitCallDirect([NotNull] this ILGenerator il, [NotNull] MethodInfo method)
            => il.Emit(OpCodes.Call, method);

        /// <summary>
        /// Calls the constructor indicated by the passed constructor descriptor.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="constructor">The constructor.</param>
        [PublicAPI]
        public static void EmitCallDirect([NotNull] this ILGenerator il, [NotNull] ConstructorInfo constructor)
            => il.Emit(OpCodes.Call, constructor);

        /// <summary>
        /// Calls a late-bound method on an object, pushing the return value onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="method">The method.</param>
        [PublicAPI]
        public static void EmitCallVirtual([NotNull] this ILGenerator il, [NotNull] MethodInfo method)
            => il.Emit(OpCodes.Callvirt, method);

        /// <summary>
        /// Calls a late-bound constructor on an object, pushing the return value onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="constructor">The constructor.</param>
        [PublicAPI]
        public static void EmitCallVirtual([NotNull] this ILGenerator il, [NotNull] ConstructorInfo constructor)
            => il.Emit(OpCodes.Callvirt, constructor);

        /// <summary>
        /// Attempts to cast an object passed by reference to the specified class.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="classType">The type.</param>
        [PublicAPI]
        public static void EmitCastClass([NotNull] this ILGenerator il, [NotNull] Type classType)
            => il.Emit(OpCodes.Castclass, classType);

        /// <summary>
        /// Constrains the type on which a virtual method call is made.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="typeToConstrainTo">The type.</param>
        [PublicAPI]
        public static void EmitCallVirtualConstrainedPrefix([NotNull] this ILGenerator il, [NotNull] Type typeToConstrainTo)
            => il.Emit(OpCodes.Constrained, typeToConstrainTo);

        /// <summary>
        /// Pushes an unmanaged pointer (type <strong>native int</strong>) to the native code implementing a specific
        /// method onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="method">The method.</param>
        [PublicAPI]
        public static void EmitLoadFunctionPointer([NotNull] this ILGenerator il, [NotNull] MethodInfo method)
            => il.Emit(OpCodes.Ldftn, method);

        /// <summary>
        /// Pushes an unmanaged pointer (type <strong>native int</strong>) to the native code implementing a particular
        /// virtual method associated with a specified object onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="method">The method.</param>
        [PublicAPI]
        public static void EmitLoadVirtualFunction([NotNull] this ILGenerator il, [NotNull] MethodInfo method)
            => il.Emit(OpCodes.Ldvirtftn, method);

        /// <summary>
        /// Specifies that an address currently atop the evaluation stack might be volatile, and the results of reading
        /// that location cannot be cached or that multiple stores to that location cannot be suppressed.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitVolatilePrefix([NotNull] this ILGenerator il) => il.Emit(OpCodes.Volatile);
    }
}
