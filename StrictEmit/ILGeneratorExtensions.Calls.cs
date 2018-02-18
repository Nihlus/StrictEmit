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
using JetBrains.Annotations;

namespace StrictEmit
{
    /// <summary>
    /// Extension methods for the <see cref="ILGenerator"/> class.
    /// </summary>
    [PublicAPI]
    public static partial class ILGeneratorExtensions
    {
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
