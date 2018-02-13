//
//  ILGeneratorExtensions.cs
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
    public static class ILGeneratorExtensions
    {
        /// <summary>
        /// Adds two values and pushes the result onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitAdd([NotNull] this ILGenerator il) => il.Emit(OpCodes.Add);

        /// <summary>
        /// Adds two integers, performs an overflow check, and pushes the result onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitAddChecked([NotNull] this ILGenerator il) => il.Emit(OpCodes.Add_Ovf);

        /// <summary>
        /// Adds two unsigned integer values, performs an overflow check, and pushes the result onto the evaluation
        /// stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitUnsignedAddChecked([NotNull] this ILGenerator il) => il.Emit(OpCodes.Add_Ovf_Un);

        /// <summary>
        /// Computes the bitwise AND of two values and pushes the result onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitAnd([NotNull] this ILGenerator il) => il.Emit(OpCodes.And);

        /// <summary>
        /// Returns an unmanaged pointer to the argument list of the current method.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitGetArglistPointer([NotNull] this ILGenerator il) => il.Emit(OpCodes.Arglist);

        /// <summary>
        /// Transfers control to a target instruction if two values are equal.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitBranchIfEqual([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Beq, instruction);

        /// <summary>
        /// Transfers control to a target instruction (short form) if two values are equal.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortBranchIfEqual([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Beq_S, instruction);

        /// <summary>
        /// Transfers control to a target instruction if the first value is greater than or equal to the second value.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitBranchGreaterThanOrEqual([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Bge, instruction);

        /// <summary>
        /// Transfers control to a target instruction (short form) if the first value is greater than or equal to the
        /// second value.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortBranchGreaterThanOrEqual([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Bge_S, instruction);

        /// <summary>
        /// Transfers control to a target instruction if the first value is greater than the second value, when
        /// comparing unsigned integer values or unordered float values.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitGreaterThanOrEqualUnsigned([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Bge_Un, instruction);

        /// <summary>
        /// Transfers control to a target instruction (short form) if the first value is greater than the second value,
        /// when comparing unsigned integer values or unordered float values.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortGreaterThanOrEqualUnsigned([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Bge_Un_S, instruction);

        /// <summary>
        /// Transfers control to a target instruction if the first value is greater than the second value.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitBranchGreaterThan([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Bgt, instruction);

        /// <summary>
        /// Transfers control to a target instruction (short form) if the first value is greater than the second value.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortBranchGreaterThan([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Bgt_S, instruction);

        /// <summary>
        /// Transfers control to a target instruction if the first value is greater than the second value, when
        /// comparing unsigned integer values or unordered float values.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitBranchGreaterThanUnsigned([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Bgt_Un, instruction);

        /// <summary>
        /// Transfers control to a target instruction (short form) if the first value is greater than the second value,
        /// when comparing unsigned integer values or unordered float values.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortBranchGreaterThanUnsigned([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Bgt_Un_S, instruction);

        /// <summary>
        /// Transfers control to a target instruction if the first value is less than or equal to the second value.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitBranchLessThanOrEqual([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Ble, instruction);

        /// <summary>
        /// Transfers control to a target instruction (short form) if the first value is less than or equal to the
        /// second value.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortBranchLessThanOrEqual([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Ble_S, instruction);

        /// <summary>
        /// Transfers control to a target instruction if the first value is less than or equal to the second value, when
        /// comparing unsigned integer values or unordered float values.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitLessThanOrEqualUnsigned([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Ble_Un, instruction);

        /// <summary>
        /// Transfers control to a target instruction (short form) if the first value is less than or equal to the
        /// second value, when comparing unsigned integer values or unordered float values.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortLessThanOrEqualUnsigned([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Ble_Un_S, instruction);

        /// <summary>
        /// Transfers control to a target instruction if the first value is less than the second value.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitBranchLessThan([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Blt, instruction);

        /// <summary>
        /// Transfers control to a target instruction (short form) if the first value is less than the second value.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortBranchLessThan([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Blt_S, instruction);

        /// <summary>
        /// Transfers control to a target instruction if the first value is less than the second value, when comparing
        /// unsigned integer values or unordered float values.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitLessThanUnsigned([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Blt_Un, instruction);

        /// <summary>
        /// Transfers control to a target instruction (short form) if the first value is less than the second value,
        /// when comparing unsigned integer values or unordered float values.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortLessThanUnsigned([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Blt_Un_S, instruction);

        /// <summary>
        /// Transfers control to a target instruction when two unsigned integer values or unordered float values are not
        /// equal.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitBranchNotEqualUnsigned([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Bne_Un, instruction);

        /// <summary>
        /// Transfers control to a target instruction (short form) when two unsigned integer values or unordered float
        /// values are not equal.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortBranchNotEqualUnsigned([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Bne_Un_S, instruction);

        /// <summary>
        /// Converts a value type to an object reference (type <strong>O</strong>).
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="typeToBox">The type.</param>
        [PublicAPI]
        public static void EmitBox([NotNull] this ILGenerator il, [NotNull] Type typeToBox)
        {
            if (!typeToBox.IsValueType)
            {
                throw new ArgumentException("The type to box must be a value type.", nameof(typeToBox));
            }

            il.Emit(OpCodes.Box, typeToBox);
        }

        /// <summary>
        /// Unconditionally transfers control to a target instruction.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitBranch([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Br, instruction);

        /// <summary>
        /// Unconditionally transfers control to a target instruction (short form).
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortBranch([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Br_S, instruction);

        /// <summary>
        /// Signals the Common Language Infrastructure (CLI) to inform the debugger that a break point has been tripped.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitBreakpoint([NotNull] this ILGenerator il) => il.Emit(OpCodes.Break);

        /// <summary>
        /// Transfers control to a target instruction if <em>value</em> is <strong>false</strong>, a null reference
        /// (<strong>Nothing</strong> in Visual Basic), or zero.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitBranchFalse([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Brfalse, instruction);

        /// <summary>
        /// Transfers control to a target instruction if <em>value</em> is <strong>false</strong>, a null reference,
        /// or zero.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortBranchFalse([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Brfalse_S, instruction);

        /// <summary>
        /// Transfers control to a target instruction if <em>value</em> is <strong>true</strong>, not null, or non-zero.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitBranchTrue([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Brtrue, instruction);

        /// <summary>
        /// Transfers control to a target instruction (short form) if <em>value</em> is <strong>true</strong>, not null,
        /// or non-zero.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortBranchTrue([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Brtrue_S, instruction);

        /// <summary>
        /// Calls the method indicated by the passed method descriptor.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="method">The method.</param>
        [PublicAPI]
        public static void EmitCallDirect([NotNull] this ILGenerator il, [NotNull] MethodInfo method)
            => il.Emit(OpCodes.Call, method);

        /// <summary>
        /// Calls a late-bound method on an object, pushing the return value onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="method">The method.</param>
        [PublicAPI]
        public static void EmitCallVirtual([NotNull] this ILGenerator il, [NotNull] MethodInfo method)
            => il.Emit(OpCodes.Callvirt, method);

        /// <summary>
        /// Attempts to cast an object passed by reference to the specified class.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="classType">The type.</param>
        [PublicAPI]
        public static void EmitCastClass([NotNull] this ILGenerator il, [NotNull] Type classType)
            => il.Emit(OpCodes.Castclass, classType);

        /// <summary>
        /// Compares two values. If they are equal, the integer value 1 <strong>(int32</strong>) is pushed onto the
        /// evaluation stack; otherwise 0 (<strong>int32</strong>) is pushed onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitCompareEqual([NotNull] this ILGenerator il) => il.Emit(OpCodes.Ceq);

        /// <summary>
        /// Compares two values. If the first value is greater than the second, the integer value 1
        /// <strong>(int32</strong>) is pushed onto the evaluation stack; otherwise 0 (<strong>int32</strong>) is pushed
        /// onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitCompareGreaterThan([NotNull] this ILGenerator il) => il.Emit(OpCodes.Cgt);

        /// <summary>
        /// Compares two unsigned or unordered values. If the first value is greater than the second, the integer value
        /// 1 <strong>(int32</strong>) is pushed onto the evaluation stack; otherwise 0 (<strong>int32</strong>) is
        /// pushed onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitCompareGreaterThanUnsigned([NotNull] this ILGenerator il) => il.Emit(OpCodes.Cgt_Un);

        /// <summary>
        /// Throws <a href="https://msdn.microsoft.com/en-us/library/system.arithmeticexception(v=vs.110).aspx">ArithmeticException</a>
        /// if value is not a finite number.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitCheckIsFinite([NotNull] this ILGenerator il) => il.Emit(OpCodes.Ckfinite);

        /// <summary>
        /// Compares two values. If the first value is less than the second, the integer value 1
        /// <strong>(int32</strong>) is pushed onto the evaluation stack; otherwise 0 (<strong>int32</strong>) is pushed
        /// onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitCompareLessThan([NotNull] this ILGenerator il) => il.Emit(OpCodes.Clt);

        /// <summary>
        /// Compares the unsigned or unordered values <em>value1</em> and <em>value2</em>. If <em>value1</em> is less
        /// than <em>value2</em>, then the integer value 1 <strong>(int32</strong>) is pushed onto the evaluation stack;
        /// otherwise 0 (<strong>int32</strong>) is pushed onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitCompareLessThanUnsigned([NotNull] this ILGenerator il) => il.Emit(OpCodes.Clt_Un);

        /// <summary>
        /// Constrains the type on which a virtual method call is made.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="typeToConstrainTo">The type.</param>
        [PublicAPI]
        public static void EmitCallVirtualConstrainedPrefix([NotNull] this ILGenerator il, [NotNull] Type typeToConstrainTo)
            => il.Emit(OpCodes.Constrained, typeToConstrainTo);

        /// <summary>
        /// Converts the value on top of the evaluation stack to <strong>native int</strong>.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertToNativeInt([NotNull] this ILGenerator il) => il.Emit(OpCodes.Conv_I);

        /// <summary>
        /// Converts the value on top of the evaluation stack to <strong>int8</strong>, then extends (pads) it to
        /// <strong>int32</strong>.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertToByte([NotNull] this ILGenerator il) => il.Emit(OpCodes.Conv_I1);

        /// <summary>
        /// Converts the value on top of the evaluation stack to <strong>int16</strong>, then extends (pads) it to
        /// <strong>int32</strong>.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertToShort([NotNull] this ILGenerator il) => il.Emit(OpCodes.Conv_I2);

        /// <summary>
        /// Converts the value on top of the evaluation stack to <strong>int32</strong>.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertToInt([NotNull] this ILGenerator il) => il.Emit(OpCodes.Conv_I4);

        /// <summary>
        /// Converts the value on top of the evaluation stack to <strong>int64</strong>.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertToLong([NotNull] this ILGenerator il) => il.Emit(OpCodes.Conv_I8);

        /// <summary>
        /// Converts the signed value on top of the evaluation stack to signed <strong>native int</strong>, throwing
        /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
        /// on overflow.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertToNativeIntChecked([NotNull] this ILGenerator il) => il.Emit(OpCodes.Conv_Ovf_I);

        /// <summary>
        /// Converts the signed value on top of the evaluation stack to signed <strong>int8</strong> and extends it to
        /// <strong>int32</strong>, throwing
        /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
        /// on overflow.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertToByteChecked([NotNull] this ILGenerator il) => il.Emit(OpCodes.Conv_Ovf_I1);

        /// <summary>
        /// Converts the signed value on top of the evaluation stack to signed <strong>int16</strong> and extending it
        /// to <strong>int32</strong>, throwing
        /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
        /// on overflow.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertToShortChecked([NotNull] this ILGenerator il) => il.Emit(OpCodes.Conv_Ovf_I2);

        /// <summary>
        /// Converts the signed value on top of the evaluation stack to signed <strong>int32</strong>, throwing
        /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
        /// on overflow.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertToIntChecked([NotNull] this ILGenerator il) => il.Emit(OpCodes.Conv_Ovf_I4);

        /// <summary>
        /// Converts the signed value on top of the evaluation stack to signed <strong>int64</strong>, throwing
        /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
        /// on overflow.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertToLongChecked([NotNull] this ILGenerator il) => il.Emit(OpCodes.Conv_Ovf_I8);

        /// <summary>
        /// Converts the unsigned value on top of the evaluation stack to signed <strong>native int</strong>, throwing
        /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
        /// on overflow.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertUnsignedToNativeIntChecked([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Conv_Ovf_I_Un);

        /// <summary>
        /// Converts the unsigned value on top of the evaluation stack to signed <strong>int8</strong> and extends it to
        /// <strong>int32</strong>, throwing
        /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
        /// on overflow.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertUnsignedToByteChecked([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Conv_Ovf_I1_Un);

        /// <summary>
        /// Converts the unsigned value on top of the evaluation stack to signed <strong>int16</strong> and extends it
        /// to <strong>int32</strong>, throwing
        /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
        /// on overflow.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertUnsignedToShortChecked([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Conv_Ovf_I2_Un);

        /// <summary>
        /// Converts the unsigned value on top of the evaluation stack to signed <strong>int32</strong>, throwing
        /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
        /// on overflow.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertUnsignedToIntChecked([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Conv_Ovf_I4_Un);

        /// <summary>
        /// Converts the unsigned value on top of the evaluation stack to signed <strong>int64</strong>, throwing
        /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
        /// on overflow.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertUnsignedToLongChecked([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Conv_Ovf_I8_Un);

        /// <summary>
        /// Converts the value on top of the evaluation stack to <strong>unsigned native int</strong>, and extends it to
        /// <strong>native int</strong>.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertToUnsignedNativeInt([NotNull] this ILGenerator il) => il.Emit(OpCodes.Conv_U);

        /// <summary>
        /// Converts the value on top of the evaluation stack to <strong>unsigned int8</strong>, and extends it to
        /// <strong>int32</strong>.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertToUByte([NotNull] this ILGenerator il) => il.Emit(OpCodes.Conv_U1);

        /// <summary>
        /// Converts the value on top of the evaluation stack to <strong>unsigned int16</strong>, and extends it to
        /// <strong>int32</strong>.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertToUShort([NotNull] this ILGenerator il) => il.Emit(OpCodes.Conv_U2);

        /// <summary>
        /// Converts the value on top of the evaluation stack to <strong>unsigned int32</strong>, and extends it to
        /// <strong>int32</strong>.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertToUInt([NotNull] this ILGenerator il) => il.Emit(OpCodes.Conv_U4);

        /// <summary>
        /// Converts the value on top of the evaluation stack to <strong>unsigned int64</strong>, and extends it to
        /// <strong>int64</strong>.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertToULong([NotNull] this ILGenerator il) => il.Emit(OpCodes.Conv_U8);

        /// <summary>
        /// Converts the signed value on top of the evaluation stack to <strong>unsigned native int</strong>, throwing
        /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
        /// on overflow.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertToUnsignedNativeIntChecked([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Conv_Ovf_U);

        /// <summary>
        /// Converts the signed value on top of the evaluation stack to <strong>unsigned int8</strong> and extends it to
        /// <strong>int32</strong>, throwing
        /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
        /// on overflow.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertToUByteChecked([NotNull] this ILGenerator il) => il.Emit(OpCodes.Conv_Ovf_U1);

        /// <summary>
        /// Converts the signed value on top of the evaluation stack to <strong>unsigned int16</strong> and extends it
        /// to <strong>int32</strong>, throwing
        /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a> on
        /// overflow.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertToUShortChecked([NotNull] this ILGenerator il) => il.Emit(OpCodes.Conv_Ovf_U2);

        /// <summary>
        /// Converts the signed value on top of the evaluation stack to <strong>unsigned int32</strong>, throwing
        /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
        /// on overflow.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertToUIntChecked([NotNull] this ILGenerator il) => il.Emit(OpCodes.Conv_Ovf_U4);

        /// <summary>
        /// Converts the signed value on top of the evaluation stack to <strong>unsigned int64</strong>, throwing
        /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
        /// on overflow.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertToULongChecked([NotNull] this ILGenerator il) => il.Emit(OpCodes.Conv_Ovf_U8);

        /// <summary>
        /// Converts the unsigned value on top of the evaluation stack to <strong>unsigned native int</strong>, throwing
        /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
        /// on overflow.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertUnsignedToUnsignedNativeIntChecked([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Conv_Ovf_U_Un);

        /// <summary>
        /// Converts the unsigned value on top of the evaluation stack to <strong>unsigned int8</strong> and extends it
        /// to <strong>int32</strong>, throwing
        /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
        /// on overflow.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertUnsignedToUByteChecked([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Conv_Ovf_U1_Un);

        /// <summary>
        /// Converts the unsigned value on top of the evaluation stack to <strong>unsigned int16</strong> and extends it
        /// to <strong>int32</strong>, throwing
        /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
        /// on overflow.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertUnsignedToUShortChecked([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Conv_Ovf_U2_Un);

        /// <summary>
        /// Converts the unsigned value on top of the evaluation stack to <strong>unsigned int32</strong>, throwing
        /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
        /// on overflow.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertUnsignedToUIntChecked([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Conv_Ovf_U4_Un);

        /// <summary>
        /// Converts the unsigned value on top of the evaluation stack to <strong>unsigned int64</strong>, throwing
        /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
        /// on overflow.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertUnsignedToULongChecked([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Conv_Ovf_U8_Un);

        /// <summary>
        /// Converts the value on top of the evaluation stack to <strong>float32</strong>.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertToFloat([NotNull] this ILGenerator il) => il.Emit(OpCodes.Conv_R4);

        /// <summary>
        /// Converts the value on top of the evaluation stack to <strong>float64</strong>.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertToDouble([NotNull] this ILGenerator il) => il.Emit(OpCodes.Conv_R8);

        /// <summary>
        /// Converts the unsigned integer value on top of the evaluation stack to <strong>float32</strong>.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitConvertUnsignedIntegerToFloat([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Conv_R_Un);

        /// <summary>
        /// Copies a specified number bytes from a source address to a destination address.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitCopyBlock([NotNull] this ILGenerator il) => il.Emit(OpCodes.Cpblk);

        /// <summary>
        /// Copies the value type located at the address of an object (type <strong>&amp;</strong>, <strong>*</strong>
        /// or <strong>native int</strong>) to the address of the destination object (type <strong>&amp;</strong>,
        /// <strong>*</strong> or <strong>native int</strong>).
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitCopyObject<T>([NotNull] this ILGenerator il) => il.EmitCopyObject(typeof(T));

        /// <summary>
        /// Copies the value type located at the address of an object (type <strong>&amp;</strong>, <strong>*</strong>
        /// or <strong>native int</strong>) to the address of the destination object (type <strong>&amp;</strong>,
        /// <strong>*</strong> or <strong>native int</strong>).
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="objectType">The type.</param>
        [PublicAPI]
        public static void EmitCopyObject([NotNull] this ILGenerator il, [NotNull] Type objectType)
            => il.Emit(OpCodes.Cpobj, objectType);

        /// <summary>
        /// Divides two values and pushes the result as a floating-point (type <strong>F</strong>) or quotient
        /// (type <strong>int32</strong>) onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitDivide([NotNull] this ILGenerator il) => il.Emit(OpCodes.Div);

        /// <summary>
        /// Divides two unsigned integer values and pushes the result (<strong>int32</strong>) onto the evaluation
        /// stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitDivideUnsigned([NotNull] this ILGenerator il) => il.Emit(OpCodes.Div_Un);

        /// <summary>
        /// Copies the current topmost value on the evaluation stack, and then pushes the copy onto the evaluation
        /// stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitDuplicate([NotNull] this ILGenerator il) => il.Emit(OpCodes.Dup);

        /// <summary>
        /// Transfers control from the <strong>filter</strong> clause of an exception back to the Common Language
        /// Infrastructure (CLI) exception handler.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitEndFilter([NotNull] this ILGenerator il) => il.Emit(OpCodes.Endfilter);

        /// <summary>
        /// Transfers control from the <strong>fault</strong> or <strong>finally</strong> clause of an exception block
        /// back to the Common Language Infrastructure (CLI) exception handler.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitEndFinally([NotNull] this ILGenerator il) => il.Emit(OpCodes.Endfinally);

        /// <summary>
        /// Initializes a specified block of memory at a specific address to a given size and initial value.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitInitBlock(this ILGenerator il) => il.Emit(OpCodes.Initblk);

        /// <summary>
        /// Initializes each field of the value type at a specified address to a null reference or a 0 of the
        /// appropriate primitive type.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitInitObject<T>(this ILGenerator il) => il.EmitInitObject(typeof(T));

        /// <summary>
        /// Initializes each field of the value type at a specified address to a null reference or a 0 of the
        /// appropriate primitive type.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="objectType">The type.</param>
        [PublicAPI]
        public static void EmitInitObject(this ILGenerator il, Type objectType) => il.Emit(OpCodes.Initobj, objectType);

        /// <summary>
        /// Tests whether an object reference (type <strong>O</strong>) is an instance of a particular class.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitIsInstance<T>([NotNull] this ILGenerator il) => il.EmitIsInstance(typeof(T));

        /// <summary>
        /// Tests whether an object reference (type <strong>O</strong>) is an instance of a particular class.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="typeToCheck">The type.</param>
        [PublicAPI]
        public static void EmitIsInstance([NotNull] this ILGenerator il, [NotNull] Type typeToCheck)
            => il.Emit(OpCodes.Isinst, typeToCheck);

        /// <summary>
        /// Exits current method and jumps to specified method.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="method">The method.</param>
        [PublicAPI]
        public static void EmitJump([NotNull] this ILGenerator il, [NotNull] MethodInfo method)
            => il.Emit(OpCodes.Jmp, method);

        /// <summary>
        /// Loads an argument (referenced by a specified index value) onto the stack. This method will use the
        /// appropriate constant- or short-optimized instruction, if applicable.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="argumentIndex">The argument index.</param>
        [PublicAPI]
        public static void EmitLoadArgument([NotNull] this ILGenerator il, short argumentIndex)
        {
            switch (argumentIndex)
            {
                case 0:
                {
                    il.Emit(OpCodes.Ldarg_0);
                    break;
                }
                case 1:
                {
                    il.Emit(OpCodes.Ldarg_1);
                    break;
                }
                case 2:
                {
                    il.Emit(OpCodes.Ldarg_2);
                    break;
                }
                case 3:
                {
                    il.Emit(OpCodes.Ldarg_3);
                    break;
                }
                default:
                {
                    if (argumentIndex >= 4 && argumentIndex <= 255)
                    {
                        il.Emit(OpCodes.Ldarg_S, (byte)argumentIndex);
                    }
                    else
                    {
                        il.Emit(OpCodes.Ldarg, argumentIndex);
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Load an argument address onto the evaluation stack. This method will use the appropriate short-optimized
        /// instruction, if applicable.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="argumentIndex">The argument index.</param>
        [PublicAPI]
        public static void EmitLoadArgumentAddress([NotNull] this ILGenerator il, short argumentIndex)
        {
            if (argumentIndex >= 4 && argumentIndex <= 255)
            {
                il.Emit(OpCodes.Ldarga_S, (byte)argumentIndex);
            }
            else
            {
                il.Emit(OpCodes.Ldarga, argumentIndex);
            }
        }

        /// <summary>
        /// Pushes a supplied value onto the evaluation stack as an <strong>int32</strong>. This method will use the
        /// appropriate constant- or short-optimized instruction, if applicable.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="value">The value.</param>
        [PublicAPI]
        public static void EmitLoadConstantInt([NotNull] this ILGenerator il, int value)
        {
            switch (value)
            {
                case -1:
                {
                    il.Emit(OpCodes.Ldc_I4_M1);
                    break;
                }
                case 0:
                {
                    il.Emit(OpCodes.Ldc_I4_0);
                    break;
                }
                case 1:
                {
                    il.Emit(OpCodes.Ldc_I4_1);
                    break;
                }
                case 2:
                {
                    il.Emit(OpCodes.Ldc_I4_2);
                    break;
                }
                case 3:
                {
                    il.Emit(OpCodes.Ldc_I4_3);
                    break;
                }
                case 4:
                {
                    il.Emit(OpCodes.Ldc_I4_4);
                    break;
                }
                case 5:
                {
                    il.Emit(OpCodes.Ldc_I4_5);
                    break;
                }
                case 6:
                {
                    il.Emit(OpCodes.Ldc_I4_6);
                    break;
                }
                case 7:
                {
                    il.Emit(OpCodes.Ldc_I4_7);
                    break;
                }
                case 8:
                {
                    il.Emit(OpCodes.Ldc_I4_8);
                    break;
                }
                default:
                {
                    if (value >= 4 && value <= 255)
                    {
                        il.Emit(OpCodes.Ldc_I4_S, (byte)value);
                    }
                    else
                    {
                        il.Emit(OpCodes.Ldc_I4, value);
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Pushes a supplied value of type <strong>int64</strong> onto the evaluation stack as an <strong>int64</strong>.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="value">The value.</param>
        [PublicAPI]
        public static void EmitConstantLong([NotNull] this ILGenerator il, long value) => il.Emit(OpCodes.Ldc_I8, value);

        /// <summary>
        /// Pushes a supplied value of type <strong>float32</strong> onto the evaluation stack as type
        /// <strong>F</strong> (float).
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="value">The value.</param>
        [PublicAPI]
        public static void EmitConstantFloat([NotNull] this ILGenerator il, float value)
            => il.Emit(OpCodes.Ldc_R4, value);

        /// <summary>
        /// Pushes a supplied value of type <strong>float64</strong> onto the evaluation stack as type
        /// <strong>F</strong> (float).
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="value">The value.</param>
        [PublicAPI]
        public static void EmitConstantDouble([NotNull] this ILGenerator il, double value)
            => il.Emit(OpCodes.Ldc_R8, value);

        /// <summary>
        /// Loads the element at a specified array index onto the top of the evaluation stack as the specified type, or
        /// as an object reference.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitLoadArrayElement<T>([NotNull] this ILGenerator il) => il.EmitLoadArrayElement(typeof(T));

        /// <summary>
        /// Loads the element at a specified array index onto the top of the evaluation stack as the specified type, or
        /// as an object reference.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="arrayElementType">The element type of the array.</param>
        [PublicAPI]
        public static void EmitLoadArrayElement([NotNull] this ILGenerator il, [NotNull] Type arrayElementType)
        {
            switch (arrayElementType)
            {
                case var _ when arrayElementType == typeof(IntPtr):
                {
                    il.Emit(OpCodes.Ldelem_I);
                    break;
                }
                case var _ when arrayElementType == typeof(sbyte):
                {
                    il.Emit(OpCodes.Ldelem_I1);
                    break;
                }
                case var _ when arrayElementType == typeof(short):
                {
                    il.Emit(OpCodes.Ldelem_I2);
                    break;
                }
                case var _ when arrayElementType == typeof(int):
                {
                    il.Emit(OpCodes.Ldelem_I4);
                    break;
                }
                case var _ when arrayElementType == typeof(long):
                {
                    il.Emit(OpCodes.Ldelem_I8);
                    break;
                }
                case var _ when arrayElementType == typeof(float):
                {
                    il.Emit(OpCodes.Ldelem_R4);
                    break;
                }
                case var _ when arrayElementType == typeof(double):
                {
                    il.Emit(OpCodes.Ldelem_R8);
                    break;
                }
                case var _ when arrayElementType == typeof(byte):
                {
                    il.Emit(OpCodes.Ldelem_U1);
                    break;
                }
                case var _ when arrayElementType == typeof(ushort):
                {
                    il.Emit(OpCodes.Ldelem_U2);
                    break;
                }
                case var _ when arrayElementType == typeof(uint):
                {
                    il.Emit(OpCodes.Ldelem_U4);
                    break;
                }
                case var _ when !arrayElementType.IsValueType:
                {
                    il.Emit(OpCodes.Ldelem_Ref);
                    break;
                }
                default:
                {
                    il.Emit(OpCodes.Ldelem, arrayElementType);
                    break;
                }
            }
        }

        /// <summary>
        /// Loads the address of the array element at a specified array index onto the top of the evaluation stack as
        /// type <strong>&amp;</strong> (managed pointer).
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitLoadArrayElementAddress<T>([NotNull] this ILGenerator il)
            => il.EmitLoadArrayElementAddress(typeof(T));

        /// <summary>
        /// Loads the address of the array element at a specified array index onto the top of the evaluation stack as
        /// type <strong>&amp;</strong> (managed pointer).
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="arrayElementType">The element type of the array.</param>
        [PublicAPI]
        public static void EmitLoadArrayElementAddress([NotNull] this ILGenerator il, [NotNull] Type arrayElementType)
            => il.Emit(OpCodes.Ldelema, arrayElementType);

        /// <summary>
        /// Finds the value of a field in the object whose reference is currently on the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="field">The field.</param>
        [PublicAPI]
        public static void EmitLoadField([NotNull] this ILGenerator il, [NotNull] FieldInfo field)
            => il.Emit(OpCodes.Ldfld, field);

        /// <summary>
        /// Finds the address of a field in the object whose reference is currently on the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="field">The field.</param>
        [PublicAPI]
        public static void EmitLoadFieldAddress([NotNull] this ILGenerator il, [NotNull] FieldInfo field)
            => il.Emit(OpCodes.Ldflda, field);

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
        /// Loads a value or object reference of the given type as a <strong>native int</strong> onto the evaluation
        /// stack indirectly.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitDereferencePointer<T>([NotNull] this ILGenerator il) => il.EmitLoadIndirect<T>();

        /// <summary>
        /// Loads a value or object reference of the given type as a <strong>native int</strong> onto the evaluation
        /// stack indirectly.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="typeToDereference">The type.</param>
        [PublicAPI]
        public static void EmitDereferencePointer([NotNull] this ILGenerator il, [NotNull] Type typeToDereference) =>
            il.EmitLoadIndirect(typeToDereference);

        /// <summary>
        /// Loads a value or object reference of the given type as a <strong>native int</strong> onto the evaluation
        /// stack indirectly.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitLoadIndirect<T>([NotNull] this ILGenerator il) => il.EmitLoadIndirect(typeof(T));

        /// <summary>
        /// Loads a value or object reference of the given type as a <strong>native int</strong> onto the evaluation
        /// stack indirectly.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="typeToLoad">The type.</param>
        [PublicAPI]
        public static void EmitLoadIndirect([NotNull] this ILGenerator il, [NotNull] Type typeToLoad)
        {
            switch (typeToLoad)
            {
                case var _ when typeToLoad == typeof(IntPtr):
                {
                    il.Emit(OpCodes.Ldind_I);
                    break;
                }
                case var _ when typeToLoad == typeof(sbyte):
                {
                    il.Emit(OpCodes.Ldind_I1);
                    break;
                }
                case var _ when typeToLoad == typeof(short):
                {
                    il.Emit(OpCodes.Ldind_I2);
                    break;
                }
                case var _ when typeToLoad == typeof(int):
                {
                    il.Emit(OpCodes.Ldind_I4);
                    break;
                }
                case var _ when typeToLoad == typeof(long):
                {
                    il.Emit(OpCodes.Ldind_I8);
                    break;
                }
                case var _ when typeToLoad == typeof(float):
                {
                    il.Emit(OpCodes.Ldind_R4);
                    break;
                }
                case var _ when typeToLoad == typeof(double):
                {
                    il.Emit(OpCodes.Ldind_R8);
                    break;
                }
                case var _ when typeToLoad == typeof(byte):
                {
                    il.Emit(OpCodes.Ldind_U1);
                    break;
                }
                case var _ when typeToLoad == typeof(ushort):
                {
                    il.Emit(OpCodes.Ldind_U2);
                    break;
                }
                case var _ when typeToLoad == typeof(uint):
                {
                    il.Emit(OpCodes.Ldind_U4);
                    break;
                }
                case var _ when !typeToLoad.IsValueType:
                {
                    il.Emit(OpCodes.Ldind_Ref);
                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException(nameof(typeToLoad), "Unrecognized indirect type.");
                }
            }
        }

        /// <summary>
        /// Pushes the number of elements of a zero-based, one-dimensional array onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitLoadLength([NotNull] this ILGenerator il) => il.Emit(OpCodes.Ldlen);

        /// <summary>
        /// Loads the local variable at a specific index onto the evaluation stack. This method will use the appropriate
        /// constant- or short-optimized instruction, if applicable.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="localIndex">The index of the local variable.</param>
        [PublicAPI]
        public static void EmitLoadLocalVariable([NotNull] this ILGenerator il, short localIndex)
        {
            switch (localIndex)
            {
                case 0:
                {
                    il.Emit(OpCodes.Ldloc_0);
                    break;
                }
                case 1:
                {
                    il.Emit(OpCodes.Ldloc_1);
                    break;
                }
                case 2:
                {
                    il.Emit(OpCodes.Ldloc_2);
                    break;
                }
                case 3:
                {
                    il.Emit(OpCodes.Ldloc_3);
                    break;
                }
                default:
                {
                    if (localIndex >= 4 && localIndex <= 255)
                    {
                        il.Emit(OpCodes.Ldloc_S, (byte)localIndex);
                    }
                    else
                    {
                        il.Emit(OpCodes.Ldloc, localIndex);
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Loads the address of the local variable at a specific index onto the evaluation stack. This method will use
        /// the appropriate short-optimized instruction, if applicable.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="localIndex">The index of the variable.</param>
        [PublicAPI]
        public static void EmitLoadLocalVariableAddress([NotNull] this ILGenerator il, int localIndex)
        {
            if (localIndex >= 4 && localIndex <= 255)
            {
                il.Emit(OpCodes.Ldloca_S, (byte)localIndex);
            }
            else
            {
                il.Emit(OpCodes.Ldloca, localIndex);
            }
        }

        /// <summary>
        /// Pushes a null reference (type <strong>O</strong>) onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitLoadNull([NotNull] this ILGenerator il) => il.Emit(OpCodes.Ldnull);

        /// <summary>
        /// Copies the value type object pointed to by an address to the top of the evaluation stack.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitLoadObject<T>([NotNull] this ILGenerator il)
            => il.EmitLoadObject(typeof(T));

        /// <summary>
        /// Copies the value type object pointed to by an address to the top of the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="valueType">The type.</param>
        [PublicAPI]
        public static void EmitLoadObject([NotNull] this ILGenerator il, [NotNull] Type valueType)
            => il.Emit(OpCodes.Ldobj, valueType);

        /// <summary>
        /// Pushes the value of a static field onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="field">The field.</param>
        [PublicAPI]
        public static void EmitLoadStaticField([NotNull] this ILGenerator il, [NotNull] FieldInfo field)
        {
            if (!field.IsStatic)
            {
                throw new ArgumentException("The given field was not static.", nameof(field));
            }

            il.Emit(OpCodes.Ldsfld, field);
        }

        /// <summary>
        /// Pushes the address of a static field onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="field">The field.</param>
        [PublicAPI]
        public static void EmitLoadStaticFieldAddress([NotNull] this ILGenerator il, [NotNull] FieldInfo field)
        {
            if (!field.IsStatic)
            {
                throw new ArgumentException("The given field was not static.", nameof(field));
            }

            il.Emit(OpCodes.Ldsflda, field);
        }

        /// <summary>
        /// Pushes a new object reference to a string literal stored in the metadata.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="value">The string value.</param>
        [PublicAPI]
        public static void EmitLoadConstantString([NotNull] this ILGenerator il, string value)
            => il.Emit(OpCodes.Ldstr, value);

        /// <summary>
        /// Converts a <see cref="MethodInfo"/> token to its runtime representation, pushing it onto the evaluation
        /// stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="method">The method.</param>
        [PublicAPI]
        public static void EmitLoadToken([NotNull] this ILGenerator il, [NotNull] MethodInfo method)
            => il.Emit(OpCodes.Ldtoken, method);

        /// <summary>
        /// Converts a <see cref="FieldInfo"/> token to its runtime representation, pushing it onto the evaluation
        /// stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="field">The field.</param>
        [PublicAPI]
        public static void EmitLoadToken([NotNull] this ILGenerator il, [NotNull] FieldInfo field)
            => il.Emit(OpCodes.Ldtoken, field);

        /// <summary>
        /// Converts a <see cref="Type"/> token to its runtime representation, pushing it onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="type">The type.</param>
        [PublicAPI]
        public static void EmitLoadToken([NotNull] this ILGenerator il, [NotNull] Type type)
            => il.Emit(OpCodes.Ldtoken, type);

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
        /// Exits a protected region of code, unconditionally transferring control to a specific target instruction.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instructionToExitAt">The instruction.</param>
        [PublicAPI]
        public static void EmitLeaveProtectedRegion([NotNull] this ILGenerator il, Label instructionToExitAt)
            => il.Emit(OpCodes.Leave, instructionToExitAt);

        /// <summary>
        /// Exits a protected region of code, unconditionally transferring control to a target instruction (short form).
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instructionToExitAt">The instruction.</param>
        [PublicAPI]
        public static void EmitShortLeaveProtectedRegion([NotNull] this ILGenerator il, Label instructionToExitAt)
            => il.Emit(OpCodes.Leave_S, instructionToExitAt);

        /// <summary>
        /// Allocates a certain number of bytes from the local dynamic memory pool and pushes the address (a transient
        /// pointer, type <strong>*</strong>) of the first allocated byte onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitLocalAllocateBytes([NotNull] this ILGenerator il) => il.Emit(OpCodes.Localloc);

        /// <summary>
        /// Pushes a typed reference to an instance of a specific type onto the evaluation stack.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitMakeReferenceOfType<T>([NotNull] this ILGenerator il)
            => il.EmitMakeReferenceOfType(typeof(T));

        /// <summary>
        /// Pushes a typed reference to an instance of a specific type onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="type">The type to create a reference to.</param>
        [PublicAPI]
        public static void EmitMakeReferenceOfType([NotNull] this ILGenerator il, [NotNull] Type type)
            => il.Emit(OpCodes.Mkrefany, type);

        /// <summary>
        /// Multiplies two values and pushes the result on the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitMultiply([NotNull] this ILGenerator il) => il.Emit(OpCodes.Mul);

        /// <summary>
        /// Multiplies two integer values, performs an overflow check, and pushes the result onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitMultiplyChecked([NotNull] this ILGenerator il) => il.Emit(OpCodes.Mul_Ovf);

        /// <summary>
        /// Multiplies two unsigned integer values, performs an overflow check, and pushes the result onto the
        /// evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitUnsignedMultiplyChecked([NotNull] this ILGenerator il) => il.Emit(OpCodes.Mul_Ovf_Un);

        /// <summary>
        /// Negates a value and pushes the result onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitNegate([NotNull] this ILGenerator il) => il.Emit(OpCodes.Neg);

        /// <summary>
        /// Pushes an object reference to a new zero-based, one-dimensional array whose elements are of a specific type
        /// onto the evaluation stack.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitNewArray<T>([NotNull] this ILGenerator il) => il.EmitNewArray(typeof(T));

        /// <summary>
        /// Pushes an object reference to a new zero-based, one-dimensional array whose elements are of a specific type
        /// onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="arrayElementType">The element type of the array.</param>
        [PublicAPI]
        public static void EmitNewArray([NotNull] this ILGenerator il, [NotNull] Type arrayElementType)
            => il.Emit(OpCodes.Newarr, arrayElementType);

        /// <summary>
        /// Creates a new object or a new instance of a value type, pushing an object reference
        /// (type <strong>O</strong>) onto the evaluation stack.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitNewObject<T>([NotNull] this ILGenerator il)
        {
            var parameterlessConstructor = typeof(T).GetConstructor(new Type[] { });
            if (parameterlessConstructor is null)
            {
                throw new ArgumentException($"The type {typeof(T).Name} does not contain a parameterless constructor.");
            }

            il.EmitNewObject(parameterlessConstructor);
        }

        /// <summary>
        /// Creates a new object or a new instance of a value type, pushing an object reference
        /// (type <strong>O</strong>) onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="constructor">The constructor to use.</param>
        [PublicAPI]
        public static void EmitNewObject([NotNull] this ILGenerator il, ConstructorInfo constructor)
            => il.Emit(OpCodes.Newobj, constructor);

        /// <summary>
        /// Fills space if opcodes are patched. No meaningful operation is performed although a processing cycle can be
        /// consumed.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitNoOperation([NotNull] this ILGenerator il) => il.Emit(OpCodes.Nop);

        /// <summary>
        /// Computes the bitwise complement of the integer value on top of the stack and pushes the result onto the
        /// evaluation stack as the same type.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitBitwiseNot([NotNull] this ILGenerator il) => il.Emit(OpCodes.Not);

        /// <summary>
        /// Compute the bitwise complement of the two integer values on top of the stack and pushes the result onto the
        /// evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitBitwiseOr([NotNull] this ILGenerator il) => il.Emit(OpCodes.Or);

        /// <summary>
        /// Computes the bitwise XOR of the top two values on the evaluation stack, pushing the result onto the
        /// evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitBitwiseXor([NotNull] this ILGenerator il) => il.Emit(OpCodes.Xor);

        /// <summary>
        /// Removes the value currently on top of the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitPop([NotNull] this ILGenerator il) => il.Emit(OpCodes.Pop);

        /// <summary>
        /// Specifies that the subsequent array address operation performs no type check at run time, and that it
        /// returns a managed pointer whose mutability is restricted.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitReadonlyArrayAddressAccessPrefix([NotNull] this ILGenerator il)
            => il.Emit(OpCodes.Readonly);

        /// <summary>
        /// Retrieves the type token embedded in a typed reference.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitRefAnyType([NotNull] this ILGenerator il) => il.Emit(OpCodes.Refanytype);

        /// <summary>
        /// Retrieves the address (type <strong>&amp;</strong>) embedded in a typed reference.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitRefAnyVal<T>([NotNull] this ILGenerator il) => il.EmitRefAnyVal(typeof(T));

        /// <summary>
        /// Retrieves the address (type <strong>&amp;</strong>) embedded in a typed reference.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="refType">The type of the reference.</param>
        [PublicAPI]
        public static void EmitRefAnyVal([NotNull] this ILGenerator il, [NotNull] Type refType)
            => il.Emit(OpCodes.Refanyval, refType);

        /// <summary>
        /// Divides two values and pushes the remainder onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitRemainder([NotNull] this ILGenerator il) => il.Emit(OpCodes.Rem);

        /// <summary>
        /// Divides two unsigned values and pushes the remainder onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitRemainderUnsigned([NotNull] this ILGenerator il) => il.Emit(OpCodes.Rem_Un);

        /// <summary>
        /// Returns from the current method, pushing a return value (if present) from the callee's evaluation stack onto the caller's evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitReturn([NotNull] this ILGenerator il) => il.Emit(OpCodes.Ret);

        /// <summary>
        /// Rethrows the current exception.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitRethrow([NotNull] this ILGenerator il) => il.Emit(OpCodes.Rethrow);

        /// <summary>
        /// Shifts an integer value to the left (in zeroes) by a specified number of bits, pushing the result onto the
        /// evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitShiftLeft([NotNull] this ILGenerator il) => il.Emit(OpCodes.Shl);

        /// <summary>
        /// Shifts an integer value (in sign) to the right by a specified number of bits, pushing the result onto the
        /// evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitShiftRight([NotNull] this ILGenerator il) => il.Emit(OpCodes.Shr);

        /// <summary>
        /// Shifts an unsigned integer value (in zeroes) to the right by a specified number of bits, pushing the result
        /// onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitShiftRightUnsigned([NotNull] this ILGenerator il) => il.Emit(OpCodes.Shr_Un);

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
        /// Stores the value on top of the evaluation stack in the argument slot at a specified index. This method will
        /// use the short-optimized instruction, if applicable.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="argumentIndex">The index of the argument.</param>
        [PublicAPI]
        public static void EmitStoreArgument([NotNull] this ILGenerator il, short argumentIndex)
        {
            if (argumentIndex >= 4 && argumentIndex <= 255)
            {
                il.Emit(OpCodes.Starg_S, (byte)argumentIndex);
            }
            else
            {
                il.Emit(OpCodes.Starg);
            }
        }

        /// <summary>
        /// Replaces the array element at a given index with the value or object ref valueon the evaluation stack,
        /// whose type is specified in the instruction. This method will use the appropriate type-optimized instruction,
        /// if applicable.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitSetArrayElement<T>([NotNull] this ILGenerator il) => il.EmitSetArrayElement(typeof(T));

        /// <summary>
        /// Replaces the array element at a given index with the value or object ref valueon the evaluation stack,
        /// whose type is specified in the instruction. This method will use the appropriate type-optimized instruction,
        /// if applicable.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="arrayElementType">The type of the array elements.</param>
        [PublicAPI]
        public static void EmitSetArrayElement([NotNull] this ILGenerator il, [NotNull] Type arrayElementType)
        {
            switch (arrayElementType)
            {
                case var _ when arrayElementType == typeof(IntPtr):
                {
                    il.Emit(OpCodes.Stelem_I);
                    break;
                }
                case var _ when arrayElementType == typeof(sbyte):
                {
                    il.Emit(OpCodes.Stelem_I1);
                    break;
                }
                case var _ when arrayElementType == typeof(short):
                {
                    il.Emit(OpCodes.Stelem_I2);
                    break;
                }
                case var _ when arrayElementType == typeof(int):
                {
                    il.Emit(OpCodes.Stelem_I4);
                    break;
                }
                case var _ when arrayElementType == typeof(long):
                {
                    il.Emit(OpCodes.Stelem_I8);
                    break;
                }
                case var _ when arrayElementType == typeof(float):
                {
                    il.Emit(OpCodes.Stelem_R4);
                    break;
                }
                case var _ when arrayElementType == typeof(double):
                {
                    il.Emit(OpCodes.Stelem_R8);
                    break;
                }
                case var _ when !arrayElementType.IsValueType:
                {
                    il.Emit(OpCodes.Stelem_Ref);
                    break;
                }
                default:
                {
                    il.Emit(OpCodes.Stelem, arrayElementType);
                    break;
                }
            }
        }

        /// <summary>
        /// Replaces the value stored in the field of an object reference or pointer with a new value.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="field">The field.</param>
        [PublicAPI]
        public static void EmitSetField([NotNull] this ILGenerator il, [NotNull] FieldInfo field)
            => il.Emit(OpCodes.Stfld, field);

        /// <summary>
        /// Stores a value or an object reference at a supplied address.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="indirectType">The type of the object to store.</param>
        [PublicAPI]
        public static void EmitSetIndirect([NotNull] this ILGenerator il, [NotNull] Type indirectType)
        {
            switch (indirectType)
            {
                case var _ when indirectType == typeof(IntPtr):
                {
                    il.Emit(OpCodes.Stind_I);
                    break;
                }
                case var _ when indirectType == typeof(sbyte):
                {
                    il.Emit(OpCodes.Stind_I1);
                    break;
                }
                case var _ when indirectType == typeof(short):
                {
                    il.Emit(OpCodes.Stind_I2);
                    break;
                }
                case var _ when indirectType == typeof(int):
                {
                    il.Emit(OpCodes.Stind_I4);
                    break;
                }
                case var _ when indirectType == typeof(long):
                {
                    il.Emit(OpCodes.Stind_I8);
                    break;
                }
                case var _ when indirectType == typeof(float):
                {
                    il.Emit(OpCodes.Stind_R4);
                    break;
                }
                case var _ when indirectType == typeof(double):
                {
                    il.Emit(OpCodes.Stind_R8);
                    break;
                }
                case var _ when !indirectType.IsValueType:
                {
                    il.Emit(OpCodes.Stind_Ref);
                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException
                    (
                        nameof(indirectType),
                        $"Invalid type \"{indirectType.Name}\"."
                    );
                }
            }
        }

        /// <summary>
        /// Pops the current value from the top of the evaluation stack and stores it in a the local variable list at a
        /// specified index. This method will use the appropriate constant-optimized instruction, if applicable.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="localIndex">The index of the local variable.</param>
        [PublicAPI]
        public static void EmitSetLocalVariable([NotNull] this ILGenerator il, short localIndex)
        {
            switch (localIndex)
            {
                case 0:
                {
                    il.Emit(OpCodes.Stloc_0);
                    break;
                }
                case 1:
                {
                    il.Emit(OpCodes.Stloc_1);
                    break;
                }
                case 2:
                {
                    il.Emit(OpCodes.Stloc_2);
                    break;
                }
                case 3:
                {
                    il.Emit(OpCodes.Stloc_3);
                    break;
                }
                default:
                {
                    if (localIndex >= 4 && localIndex <= 255)
                    {
                        il.Emit(OpCodes.Stloc_S, (byte)localIndex);
                    }
                    else
                    {
                        il.Emit(OpCodes.Stloc, localIndex);
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Copies a value of a specified type from the evaluation stack into a supplied memory address.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitSetObject<T>([NotNull] this ILGenerator il) => il.EmitSetObject(typeof(T));

        /// <summary>
        /// Copies a value of a specified type from the evaluation stack into a supplied memory address.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="objectType">The type of the object.</param>
        [PublicAPI]
        public static void EmitSetObject([NotNull] this ILGenerator il, [NotNull] Type objectType)
            => il.Emit(OpCodes.Stobj, objectType);

        /// <summary>
        /// Replaces the value of a static field with a value from the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="field">The field.</param>
        [PublicAPI]
        public static void EmitSetStaticField([NotNull] this ILGenerator il, [NotNull] FieldInfo field)
            => il.Emit(OpCodes.Stsfld, field);

        /// <summary>
        /// Subtracts one value from another and pushes the result onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitSubtract([NotNull] this ILGenerator il) => il.Emit(OpCodes.Sub);

        /// <summary>
        /// Subtracts one integer value from another, performs an overflow check, and pushes the result onto the
        /// evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitSubtractChecked([NotNull] this ILGenerator il) => il.Emit(OpCodes.Sub_Ovf);

        /// <summary>
        /// Subtracts one unsigned integer value from another, performs an overflow check, and pushes the result onto
        /// the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitUnsignedSubtractChecked([NotNull] this ILGenerator il) => il.Emit(OpCodes.Sub_Ovf_Un);

        /// <summary>
        /// Implements a jump table.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="jumpTable">The table of jump labels.</param>
        [PublicAPI]
        public static void EmitSwitch([NotNull] this ILGenerator il, [NotNull] Label[] jumpTable)
            => il.Emit(OpCodes.Switch, jumpTable);

        /// <summary>
        /// Performs a postfixed method call instruction such that the current method's stack frame is removed before
        /// the actual call instruction is executed.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitTailcall([NotNull] this ILGenerator il) => il.Emit(OpCodes.Tailcall);

        /// <summary>
        /// Throws the exception object currently on the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitThrow([NotNull] this ILGenerator il) => il.Emit(OpCodes.Throw);

        /// <summary>
        /// Indicates that an address currently atop the evaluation stack might not be aligned to the natural size of
        /// the immediately following <strong>ldind</strong>, <strong>stind</strong>, <strong>ldfld</strong>,
        /// <strong>stfld</strong>, <strong>ldobj</strong>, <strong>stobj</strong>, <strong>initblk</strong>, or
        /// <strong>cpblk</strong> instruction.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitUnalignedPrefix([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Unaligned, instruction);

        /// <summary>
        /// Indicates that an address currently atop the evaluation stack might not be aligned to the natural size of
        /// the immediately following <strong>ldind</strong>, <strong>stind</strong>, <strong>ldfld</strong>,
        /// <strong>stfld</strong>, <strong>ldobj</strong>, <strong>stobj</strong>, <strong>initblk</strong>, or
        /// <strong>cpblk</strong> instruction.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="offset">The instruction offset.</param>
        [PublicAPI]
        public static void EmitUnalignedPrefix([NotNull] this ILGenerator il, byte offset)
            => il.Emit(OpCodes.Unaligned, offset);

        /// <summary>
        /// Converts the boxed representation of a value type to its unboxed form.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitUnbox<T>([NotNull] this ILGenerator il) => il.EmitUnbox(typeof(T));

        /// <summary>
        /// Converts the boxed representation of a value type to its unboxed form.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="type">The type to unbox.</param>
        [PublicAPI]
        public static void EmitUnbox([NotNull] this ILGenerator il, [NotNull] Type type)
            => il.Emit(OpCodes.Unbox, type);

        /// <summary>
        /// Converts the boxed representation of a type specified in the instruction to its unboxed form.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitUnboxAny<T>([NotNull] this ILGenerator il) => il.EmitUnboxAny(typeof(T));

        /// <summary>
        /// Converts the boxed representation of a type specified in the instruction to its unboxed form.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="type">The type to unbox.</param>
        [PublicAPI]
        public static void EmitUnboxAny([NotNull] this ILGenerator il, [NotNull] Type type)
            => il.Emit(OpCodes.Unbox_Any, type);

        /// <summary>
        /// Specifies that an address currently atop the evaluation stack might be volatile, and the results of reading
        /// that location cannot be cached or that multiple stores to that location cannot be suppressed.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitVolatilePrefix([NotNull] this ILGenerator il) => il.Emit(OpCodes.Volatile);
    }
}
