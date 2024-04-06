//
//  SPDX-FileName: ILGeneratorExtensions.Utility.cs
//  SPDX-FileCopyrightText: Copyright (c) Jarl Gullberg
//  SPDX-License-Identifier: GPL-3.0-or-later
//

using System;
using System.Reflection.Emit;
using JetBrains.Annotations;

namespace StrictEmit
{
    public static partial class ILGeneratorExtensions
    {
        /// <summary>
        /// Signals the Common Language Infrastructure (CLI) to inform the debugger that a break point has been tripped.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitBreakpoint([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Break);

        /// <summary>
        /// Fills space if opcodes are patched. No meaningful operation is performed although a processing cycle can be
        /// consumed.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitNoOperation([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Nop);

        /// <summary>
        /// Removes the value currently on top of the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitPop([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Pop);

        /// <summary>
        /// Pushes the size, in bytes, of a supplied value type onto the evaluation stack.
        /// </summary>
        /// <typeparam name="T">The type to calculate the size of.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitSizeOf<T>([NotNull] this ILGenerator il)
            => il.EmitSizeOf(typeof(T));

        /// <summary>
        /// Pushes the size, in bytes, of a supplied value type onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="type">The type to calculate the size of.</param>
        [PublicAPI]
        public static void EmitSizeOf([NotNull] this ILGenerator il, [NotNull] Type type)
            => il.Emit(OpCodes.Sizeof, type);

        /// <summary>
        /// Emits a set of IL instructions which will produce the equivalent of a typeof(T) call, placing it onto the
        /// evaluation stack.
        /// </summary>
        /// <typeparam name="T">The type to be emitted.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>.
        [PublicAPI]
        public static void EmitTypeOf<T>([NotNull] this ILGenerator il)
            => il.EmitTypeOf(typeof(T));

        /// <summary>
        /// Emits a set of IL instructions which will produce the equivalent of a typeof(T) call, placing it onto the
        /// evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="type">The type to be emitted.</param>
        [PublicAPI]
        public static void EmitTypeOf([NotNull] this ILGenerator il, [NotNull] Type type)
        {
            il.EmitLoadToken(type);
            il.EmitCallDirect<Type>(nameof(Type.GetTypeFromHandle), typeof(RuntimeTypeHandle));
        }
    }
}
