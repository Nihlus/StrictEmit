//
//  ILGeneratorExtensions.ControlFlow.cs
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

using System.Reflection;
using System.Reflection.Emit;
using JetBrains.Annotations;

namespace StrictEmit
{
    public static partial class ILGeneratorExtensions
    {
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
        public static void EmitBranchGreaterThanOrEqualUnsigned([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Bge_Un, instruction);

        /// <summary>
        /// Transfers control to a target instruction (short form) if the first value is greater than the second value,
        /// when comparing unsigned integer values or unordered float values.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortBranchGreaterThanOrEqualUnsigned([NotNull] this ILGenerator il, Label instruction)
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
        public static void EmitBranchLessThanOrEqualUnsigned([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Ble_Un, instruction);

        /// <summary>
        /// Transfers control to a target instruction (short form) if the first value is less than or equal to the
        /// second value, when comparing unsigned integer values or unordered float values.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortBranchLessThanOrEqualUnsigned([NotNull] this ILGenerator il, Label instruction)
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
        public static void EmitBranchLessThanUnsigned([NotNull] this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Blt_Un, instruction);

        /// <summary>
        /// Transfers control to a target instruction (short form) if the first value is less than the second value,
        /// when comparing unsigned integer values or unordered float values.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortBranchLessThanUnsigned([NotNull] this ILGenerator il, Label instruction)
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
        /// Exits current method and jumps to specified method.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="method">The method.</param>
        [PublicAPI]
        public static void EmitJump([NotNull] this ILGenerator il, [NotNull] MethodInfo method)
            => il.Emit(OpCodes.Jmp, method);

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
        /// Implements a jump table.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="jumpTable">The table of jump labels.</param>
        [PublicAPI]
        public static void EmitSwitch([NotNull] this ILGenerator il, [NotNull] Label[] jumpTable)
            => il.Emit(OpCodes.Switch, jumpTable);
    }
}
