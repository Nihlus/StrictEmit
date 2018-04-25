//
//  ILGeneratorExtensions.Utility.cs
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
        public static void EmitBreakpoint([NotNull] this ILGenerator il) => il.Emit(OpCodes.Break);

        /// <summary>
        /// Fills space if opcodes are patched. No meaningful operation is performed although a processing cycle can be
        /// consumed.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitNoOperation([NotNull] this ILGenerator il) => il.Emit(OpCodes.Nop);

        /// <summary>
        /// Removes the value currently on top of the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitPop([NotNull] this ILGenerator il) => il.Emit(OpCodes.Pop);

        /// <summary>
        /// Pushes the size, in bytes, of a supplied value type onto the evaluation stack.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitSizeOf<T>([NotNull] this ILGenerator il) => il.EmitSizeOf(typeof(T));

        /// <summary>
        /// Pushes the size, in bytes, of a supplied value type onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="type">The type.</param>
        [PublicAPI]
        public static void EmitSizeOf([NotNull] this ILGenerator il, [NotNull] Type type)
            => il.Emit(OpCodes.Sizeof, type);

        /// <summary>
        /// Emits a set of IL instructions which will produce the equivalent of a typeof(T) call, placing it onto the
        /// evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="type">The type to be emitted.</param>
        public static void EmitTypeOf([NotNull] this ILGenerator il, [NotNull] Type type)
        {
            il.EmitLoadToken(type);
            il.EmitCallDirect<Type>(nameof(Type.GetTypeFromHandle), typeof(RuntimeTypeHandle));
        }
    }
}
