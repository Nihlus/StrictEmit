//
//  SPDX-FileName: ILGeneratorExtensions.Math.cs
//  SPDX-FileCopyrightText: Copyright (c) Jarl Gullberg
//  SPDX-License-Identifier: GPL-3.0-or-later
//

using System.Reflection.Emit;
using JetBrains.Annotations;

namespace StrictEmit
{
    public static partial class ILGeneratorExtensions
    {
        /// <summary>
        /// Adds two values and pushes the result onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitAdd([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Add);

        /// <summary>
        /// Adds two integers, performs an overflow check, and pushes the result onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitAddChecked([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Add_Ovf);

        /// <summary>
        /// Adds two unsigned integer values, performs an overflow check, and pushes the result onto the evaluation
        /// stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitUnsignedAddChecked([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Add_Ovf_Un);

        /// <summary>
        /// Computes the bitwise AND of two values and pushes the result onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitAnd([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.And);

        /// <summary>
        /// Compares two values. If they are equal, the integer value 1 <strong>(int32</strong>) is pushed onto the
        /// evaluation stack; otherwise 0 (<strong>int32</strong>) is pushed onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitCompareEqual([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Ceq);

        /// <summary>
        /// Compares two values. If the first value is greater than the second, the integer value 1
        /// <strong>(int32</strong>) is pushed onto the evaluation stack; otherwise 0 (<strong>int32</strong>) is pushed
        /// onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitCompareGreaterThan([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Cgt);

        /// <summary>
        /// Compares two unsigned or unordered values. If the first value is greater than the second, the integer value
        /// 1 <strong>(int32</strong>) is pushed onto the evaluation stack; otherwise 0 (<strong>int32</strong>) is
        /// pushed onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitCompareGreaterThanUnsigned([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Cgt_Un);

        /// <summary>
        /// Throws <a href="https://msdn.microsoft.com/en-us/library/system.arithmeticexception(v=vs.110).aspx">ArithmeticException</a>
        /// if value is not a finite number.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitCheckIsFinite([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Ckfinite);

        /// <summary>
        /// Compares two values. If the first value is less than the second, the integer value 1
        /// <strong>(int32</strong>) is pushed onto the evaluation stack; otherwise 0 (<strong>int32</strong>) is pushed
        /// onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitCompareLessThan([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Clt);

        /// <summary>
        /// Compares the unsigned or unordered values <em>value1</em> and <em>value2</em>. If <em>value1</em> is less
        /// than <em>value2</em>, then the integer value 1 <strong>(int32</strong>) is pushed onto the evaluation stack;
        /// otherwise 0 (<strong>int32</strong>) is pushed onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitCompareLessThanUnsigned([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Clt_Un);

        /// <summary>
        /// Divides two values and pushes the result as a floating-point (type <strong>F</strong>) or quotient
        /// (type <strong>int32</strong>) onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitDivide([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Div);

        /// <summary>
        /// Divides two unsigned integer values and pushes the result (<strong>int32</strong>) onto the evaluation
        /// stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitDivideUnsigned([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Div_Un);

        /// <summary>
        /// Subtracts one value from another and pushes the result onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitSubtract([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Sub);

        /// <summary>
        /// Subtracts one integer value from another, performs an overflow check, and pushes the result onto the
        /// evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitSubtractChecked([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Sub_Ovf);

        /// <summary>
        /// Subtracts one unsigned integer value from another, performs an overflow check, and pushes the result onto
        /// the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitUnsignedSubtractChecked([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Sub_Ovf_Un);

        /// <summary>
        /// Shifts an integer value to the left (in zeroes) by a specified number of bits, pushing the result onto the
        /// evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitShiftLeft([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Shl);

        /// <summary>
        /// Shifts an integer value (in sign) to the right by a specified number of bits, pushing the result onto the
        /// evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitShiftRight([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Shr);

        /// <summary>
        /// Shifts an unsigned integer value (in zeroes) to the right by a specified number of bits, pushing the result
        /// onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitShiftRightUnsigned([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Shr_Un);

        /// <summary>
        /// Divides two values and pushes the remainder onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitRemainder([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Rem);

        /// <summary>
        /// Divides two unsigned values and pushes the remainder onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitRemainderUnsigned([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Rem_Un);

        /// <summary>
        /// Computes the bitwise complement of the integer value on top of the stack and pushes the result onto the
        /// evaluation stack as the same type.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitBitwiseNot([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Not);

        /// <summary>
        /// Compute the bitwise complement of the two integer values on top of the stack and pushes the result onto the
        /// evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitBitwiseOr([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Or);

        /// <summary>
        /// Computes the bitwise XOR of the top two values on the evaluation stack, pushing the result onto the
        /// evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitBitwiseXor([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Xor);

        /// <summary>
        /// Multiplies two values and pushes the result on the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitMultiply([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Mul);

        /// <summary>
        /// Multiplies two integer values, performs an overflow check, and pushes the result onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitMultiplyChecked([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Mul_Ovf);

        /// <summary>
        /// Multiplies two unsigned integer values, performs an overflow check, and pushes the result onto the
        /// evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitUnsignedMultiplyChecked([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Mul_Ovf_Un);

        /// <summary>
        /// Negates a value and pushes the result onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitNegate([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Neg);
    }
}
