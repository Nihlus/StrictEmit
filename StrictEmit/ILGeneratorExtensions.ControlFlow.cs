//
//  SPDX-FileName: ILGeneratorExtensions.ControlFlow.cs
//  SPDX-FileCopyrightText: Copyright (c) Jarl Gullberg
//  SPDX-License-Identifier: GPL-3.0-or-later
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
        public static void EmitBranchIfEqual(this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Beq, instruction);

        /// <summary>
        /// Transfers control to a target instruction (short form) if two values are equal.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortBranchIfEqual(this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Beq_S, instruction);

        /// <summary>
        /// Transfers control to a target instruction if the first value is greater than or equal to the second value.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitBranchGreaterThanOrEqual(this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Bge, instruction);

        /// <summary>
        /// Transfers control to a target instruction (short form) if the first value is greater than or equal to the
        /// second value.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortBranchGreaterThanOrEqual(this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Bge_S, instruction);

        /// <summary>
        /// Transfers control to a target instruction if the first value is greater than the second value, when
        /// comparing unsigned integer values or unordered float values.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitBranchGreaterThanOrEqualUnsigned(this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Bge_Un, instruction);

        /// <summary>
        /// Transfers control to a target instruction (short form) if the first value is greater than the second value,
        /// when comparing unsigned integer values or unordered float values.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortBranchGreaterThanOrEqualUnsigned(this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Bge_Un_S, instruction);

        /// <summary>
        /// Transfers control to a target instruction if the first value is greater than the second value.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitBranchGreaterThan(this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Bgt, instruction);

        /// <summary>
        /// Transfers control to a target instruction (short form) if the first value is greater than the second value.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortBranchGreaterThan(this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Bgt_S, instruction);

        /// <summary>
        /// Transfers control to a target instruction if the first value is greater than the second value, when
        /// comparing unsigned integer values or unordered float values.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitBranchGreaterThanUnsigned(this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Bgt_Un, instruction);

        /// <summary>
        /// Transfers control to a target instruction (short form) if the first value is greater than the second value,
        /// when comparing unsigned integer values or unordered float values.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortBranchGreaterThanUnsigned(this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Bgt_Un_S, instruction);

        /// <summary>
        /// Transfers control to a target instruction if the first value is less than or equal to the second value.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitBranchLessThanOrEqual(this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Ble, instruction);

        /// <summary>
        /// Transfers control to a target instruction (short form) if the first value is less than or equal to the
        /// second value.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortBranchLessThanOrEqual(this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Ble_S, instruction);

        /// <summary>
        /// Transfers control to a target instruction if the first value is less than or equal to the second value, when
        /// comparing unsigned integer values or unordered float values.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitBranchLessThanOrEqualUnsigned(this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Ble_Un, instruction);

        /// <summary>
        /// Transfers control to a target instruction (short form) if the first value is less than or equal to the
        /// second value, when comparing unsigned integer values or unordered float values.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortBranchLessThanOrEqualUnsigned(this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Ble_Un_S, instruction);

        /// <summary>
        /// Transfers control to a target instruction if the first value is less than the second value.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitBranchLessThan(this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Blt, instruction);

        /// <summary>
        /// Transfers control to a target instruction (short form) if the first value is less than the second value.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortBranchLessThan(this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Blt_S, instruction);

        /// <summary>
        /// Transfers control to a target instruction if the first value is less than the second value, when comparing
        /// unsigned integer values or unordered float values.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitBranchLessThanUnsigned(this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Blt_Un, instruction);

        /// <summary>
        /// Transfers control to a target instruction (short form) if the first value is less than the second value,
        /// when comparing unsigned integer values or unordered float values.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortBranchLessThanUnsigned(this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Blt_Un_S, instruction);

        /// <summary>
        /// Transfers control to a target instruction when two unsigned integer values or unordered float values are not
        /// equal.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitBranchNotEqualUnsigned(this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Bne_Un, instruction);

        /// <summary>
        /// Transfers control to a target instruction (short form) when two unsigned integer values or unordered float
        /// values are not equal.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortBranchNotEqualUnsigned(this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Bne_Un_S, instruction);

        /// <summary>
        /// Transfers control from the <strong>filter</strong> clause of an exception back to the Common Language
        /// Infrastructure (CLI) exception handler.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitEndFilter(this ILGenerator il)
            => il.Emit(OpCodes.Endfilter);

        /// <summary>
        /// Transfers control from the <strong>fault</strong> or <strong>finally</strong> clause of an exception block
        /// back to the Common Language Infrastructure (CLI) exception handler.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitEndFinally(this ILGenerator il)
            => il.Emit(OpCodes.Endfinally);

        /// <summary>
        /// Unconditionally transfers control to a target instruction.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitBranch(this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Br, instruction);

        /// <summary>
        /// Unconditionally transfers control to a target instruction (short form).
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortBranch(this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Br_S, instruction);

        /// <summary>
        /// Transfers control to a target instruction if <em>value</em> is <strong>false</strong>, a null reference
        /// (<strong>Nothing</strong> in Visual Basic), or zero.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitBranchFalse(this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Brfalse, instruction);

        /// <summary>
        /// Transfers control to a target instruction if <em>value</em> is <strong>false</strong>, a null reference,
        /// or zero.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortBranchFalse(this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Brfalse_S, instruction);

        /// <summary>
        /// Transfers control to a target instruction if <em>value</em> is <strong>true</strong>, not null, or non-zero.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitBranchTrue(this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Brtrue, instruction);

        /// <summary>
        /// Transfers control to a target instruction (short form) if <em>value</em> is <strong>true</strong>, not null,
        /// or non-zero.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitShortBranchTrue(this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Brtrue_S, instruction);

        /// <summary>
        /// Exits current method and jumps to specified method.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="method">The method.</param>
        [PublicAPI]
        public static void EmitJump(this ILGenerator il, MethodInfo method)
            => il.Emit(OpCodes.Jmp, method);

        /// <summary>
        /// Exits a protected region of code, unconditionally transferring control to a specific target instruction.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instructionToExitAt">The instruction.</param>
        [PublicAPI]
        public static void EmitLeaveProtectedRegion(this ILGenerator il, Label instructionToExitAt)
            => il.Emit(OpCodes.Leave, instructionToExitAt);

        /// <summary>
        /// Exits a protected region of code, unconditionally transferring control to a target instruction (short form).
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instructionToExitAt">The instruction.</param>
        [PublicAPI]
        public static void EmitShortLeaveProtectedRegion(this ILGenerator il, Label instructionToExitAt)
            => il.Emit(OpCodes.Leave_S, instructionToExitAt);

        /// <summary>
        /// Returns from the current method, pushing a return value (if present) from the callee's evaluation stack onto the caller's evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitReturn(this ILGenerator il)
            => il.Emit(OpCodes.Ret);

        /// <summary>
        /// Rethrows the current exception.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitRethrow(this ILGenerator il)
            => il.Emit(OpCodes.Rethrow);

        /// <summary>
        /// Performs a postfixed method call instruction such that the current method's stack frame is removed before
        /// the actual call instruction is executed.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitTailcall(this ILGenerator il)
            => il.Emit(OpCodes.Tailcall);

        /// <summary>
        /// Throws the exception object currently on the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitThrow(this ILGenerator il)
            => il.Emit(OpCodes.Throw);

        /// <summary>
        /// Implements a jump table.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="jumpTable">The table of jump labels.</param>
        [PublicAPI]
        public static void EmitSwitch(this ILGenerator il, Label[] jumpTable)
            => il.Emit(OpCodes.Switch, jumpTable);
    }
}
