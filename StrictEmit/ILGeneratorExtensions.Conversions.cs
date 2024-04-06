//
//  SPDX-FileName: ILGeneratorExtensions.Conversions.cs
//  SPDX-FileCopyrightText: Copyright (c) Jarl Gullberg
//  SPDX-License-Identifier: GPL-3.0-or-later
//

using System.Reflection.Emit;
using JetBrains.Annotations;

namespace StrictEmit;

public static partial class ILGeneratorExtensions
{
    /// <summary>
    /// Converts the value on top of the evaluation stack to <strong>native int</strong>.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertToNativeInt(this ILGenerator il)
        => il.Emit(OpCodes.Conv_I);

    /// <summary>
    /// Converts the value on top of the evaluation stack to <strong>int8</strong>, then extends (pads) it to
    /// <strong>int32</strong>.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertToByte(this ILGenerator il)
        => il.Emit(OpCodes.Conv_I1);

    /// <summary>
    /// Converts the value on top of the evaluation stack to <strong>int16</strong>, then extends (pads) it to
    /// <strong>int32</strong>.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertToShort(this ILGenerator il)
        => il.Emit(OpCodes.Conv_I2);

    /// <summary>
    /// Converts the value on top of the evaluation stack to <strong>int32</strong>.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertToInt(this ILGenerator il)
        => il.Emit(OpCodes.Conv_I4);

    /// <summary>
    /// Converts the value on top of the evaluation stack to <strong>int64</strong>.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertToLong(this ILGenerator il)
        => il.Emit(OpCodes.Conv_I8);

    /// <summary>
    /// Converts the signed value on top of the evaluation stack to signed <strong>native int</strong>, throwing
    /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
    /// on overflow.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertToNativeIntChecked(this ILGenerator il)
        => il.Emit(OpCodes.Conv_Ovf_I);

    /// <summary>
    /// Converts the signed value on top of the evaluation stack to signed <strong>int8</strong> and extends it to
    /// <strong>int32</strong>, throwing
    /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
    /// on overflow.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertToByteChecked(this ILGenerator il)
        => il.Emit(OpCodes.Conv_Ovf_I1);

    /// <summary>
    /// Converts the signed value on top of the evaluation stack to signed <strong>int16</strong> and extending it
    /// to <strong>int32</strong>, throwing
    /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
    /// on overflow.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertToShortChecked(this ILGenerator il)
        => il.Emit(OpCodes.Conv_Ovf_I2);

    /// <summary>
    /// Converts the signed value on top of the evaluation stack to signed <strong>int32</strong>, throwing
    /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
    /// on overflow.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertToIntChecked(this ILGenerator il)
        => il.Emit(OpCodes.Conv_Ovf_I4);

    /// <summary>
    /// Converts the signed value on top of the evaluation stack to signed <strong>int64</strong>, throwing
    /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
    /// on overflow.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertToLongChecked(this ILGenerator il)
        => il.Emit(OpCodes.Conv_Ovf_I8);

    /// <summary>
    /// Converts the unsigned value on top of the evaluation stack to signed <strong>native int</strong>, throwing
    /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
    /// on overflow.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertUnsignedToNativeIntChecked(this ILGenerator il)
        => il.Emit(OpCodes.Conv_Ovf_I_Un);

    /// <summary>
    /// Converts the unsigned value on top of the evaluation stack to signed <strong>int8</strong> and extends it to
    /// <strong>int32</strong>, throwing
    /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
    /// on overflow.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertUnsignedToByteChecked(this ILGenerator il)
        => il.Emit(OpCodes.Conv_Ovf_I1_Un);

    /// <summary>
    /// Converts the unsigned value on top of the evaluation stack to signed <strong>int16</strong> and extends it
    /// to <strong>int32</strong>, throwing
    /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
    /// on overflow.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertUnsignedToShortChecked(this ILGenerator il)
        => il.Emit(OpCodes.Conv_Ovf_I2_Un);

    /// <summary>
    /// Converts the unsigned value on top of the evaluation stack to signed <strong>int32</strong>, throwing
    /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
    /// on overflow.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertUnsignedToIntChecked(this ILGenerator il)
        => il.Emit(OpCodes.Conv_Ovf_I4_Un);

    /// <summary>
    /// Converts the unsigned value on top of the evaluation stack to signed <strong>int64</strong>, throwing
    /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
    /// on overflow.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertUnsignedToLongChecked(this ILGenerator il)
        => il.Emit(OpCodes.Conv_Ovf_I8_Un);

    /// <summary>
    /// Converts the value on top of the evaluation stack to <strong>unsigned native int</strong>, and extends it to
    /// <strong>native int</strong>.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertToUnsignedNativeInt(this ILGenerator il)
        => il.Emit(OpCodes.Conv_U);

    /// <summary>
    /// Converts the value on top of the evaluation stack to <strong>unsigned int8</strong>, and extends it to
    /// <strong>int32</strong>.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertToUByte(this ILGenerator il)
        => il.Emit(OpCodes.Conv_U1);

    /// <summary>
    /// Converts the value on top of the evaluation stack to <strong>unsigned int16</strong>, and extends it to
    /// <strong>int32</strong>.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertToUShort(this ILGenerator il)
        => il.Emit(OpCodes.Conv_U2);

    /// <summary>
    /// Converts the value on top of the evaluation stack to <strong>unsigned int32</strong>, and extends it to
    /// <strong>int32</strong>.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertToUInt(this ILGenerator il)
        => il.Emit(OpCodes.Conv_U4);

    /// <summary>
    /// Converts the value on top of the evaluation stack to <strong>unsigned int64</strong>, and extends it to
    /// <strong>int64</strong>.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertToULong(this ILGenerator il)
        => il.Emit(OpCodes.Conv_U8);

    /// <summary>
    /// Converts the signed value on top of the evaluation stack to <strong>unsigned native int</strong>, throwing
    /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
    /// on overflow.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertToUnsignedNativeIntChecked(this ILGenerator il)
        => il.Emit(OpCodes.Conv_Ovf_U);

    /// <summary>
    /// Converts the signed value on top of the evaluation stack to <strong>unsigned int8</strong> and extends it to
    /// <strong>int32</strong>, throwing
    /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
    /// on overflow.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertToUByteChecked(this ILGenerator il)
        => il.Emit(OpCodes.Conv_Ovf_U1);

    /// <summary>
    /// Converts the signed value on top of the evaluation stack to <strong>unsigned int16</strong> and extends it
    /// to <strong>int32</strong>, throwing
    /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a> on
    /// overflow.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertToUShortChecked(this ILGenerator il)
        => il.Emit(OpCodes.Conv_Ovf_U2);

    /// <summary>
    /// Converts the signed value on top of the evaluation stack to <strong>unsigned int32</strong>, throwing
    /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
    /// on overflow.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertToUIntChecked(this ILGenerator il)
        => il.Emit(OpCodes.Conv_Ovf_U4);

    /// <summary>
    /// Converts the signed value on top of the evaluation stack to <strong>unsigned int64</strong>, throwing
    /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
    /// on overflow.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertToULongChecked(this ILGenerator il)
        => il.Emit(OpCodes.Conv_Ovf_U8);

    /// <summary>
    /// Converts the unsigned value on top of the evaluation stack to <strong>unsigned native int</strong>, throwing
    /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
    /// on overflow.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertUnsignedToUnsignedNativeIntChecked(this ILGenerator il)
        => il.Emit(OpCodes.Conv_Ovf_U_Un);

    /// <summary>
    /// Converts the unsigned value on top of the evaluation stack to <strong>unsigned int8</strong> and extends it
    /// to <strong>int32</strong>, throwing
    /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
    /// on overflow.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertUnsignedToUByteChecked(this ILGenerator il)
        => il.Emit(OpCodes.Conv_Ovf_U1_Un);

    /// <summary>
    /// Converts the unsigned value on top of the evaluation stack to <strong>unsigned int16</strong> and extends it
    /// to <strong>int32</strong>, throwing
    /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
    /// on overflow.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertUnsignedToUShortChecked(this ILGenerator il)
        => il.Emit(OpCodes.Conv_Ovf_U2_Un);

    /// <summary>
    /// Converts the unsigned value on top of the evaluation stack to <strong>unsigned int32</strong>, throwing
    /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
    /// on overflow.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertUnsignedToUIntChecked(this ILGenerator il)
        => il.Emit(OpCodes.Conv_Ovf_U4_Un);

    /// <summary>
    /// Converts the unsigned value on top of the evaluation stack to <strong>unsigned int64</strong>, throwing
    /// <a href="https://msdn.microsoft.com/en-us/library/system.overflowexception(v=vs.110).aspx">OverflowException</a>
    /// on overflow.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertUnsignedToULongChecked(this ILGenerator il)
        => il.Emit(OpCodes.Conv_Ovf_U8_Un);

    /// <summary>
    /// Converts the value on top of the evaluation stack to <strong>float32</strong>.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertToFloat(this ILGenerator il)
        => il.Emit(OpCodes.Conv_R4);

    /// <summary>
    /// Converts the value on top of the evaluation stack to <strong>float64</strong>.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertToDouble(this ILGenerator il)
        => il.Emit(OpCodes.Conv_R8);

    /// <summary>
    /// Converts the unsigned integer value on top of the evaluation stack to <strong>float32</strong>.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitConvertUnsignedIntegerToFloat(this ILGenerator il)
        => il.Emit(OpCodes.Conv_R_Un);
}
