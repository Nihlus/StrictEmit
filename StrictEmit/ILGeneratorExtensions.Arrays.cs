//
//  SPDX-FileName: ILGeneratorExtensions.Arrays.cs
//  SPDX-FileCopyrightText: Copyright (c) Jarl Gullberg
//  SPDX-License-Identifier: GPL-3.0-or-later
//

using System;
using System.Reflection.Emit;
using JetBrains.Annotations;

namespace StrictEmit;

public static partial class ILGeneratorExtensions
{
    /// <summary>
    /// Loads the element at a specified array index onto the top of the evaluation stack as the specified type, or
    /// as an object reference.
    /// </summary>
    /// <typeparam name="T">The element type of the array.</typeparam>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitLoadArrayElement<T>(this ILGenerator il)
        => il.EmitLoadArrayElement(typeof(T));

    /// <summary>
    /// Loads the element at a specified array index onto the top of the evaluation stack as the specified type, or
    /// as an object reference.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    /// <param name="arrayElementType">The element type of the array.</param>
    [PublicAPI]
    public static void EmitLoadArrayElement(this ILGenerator il, Type arrayElementType)
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
    /// <typeparam name="T">The element type of the array.</typeparam>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitLoadArrayElementAddress<T>(this ILGenerator il)
        => il.EmitLoadArrayElementAddress(typeof(T));

    /// <summary>
    /// Loads the address of the array element at a specified array index onto the top of the evaluation stack as
    /// type <strong>&amp;</strong> (managed pointer).
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    /// <param name="arrayElementType">The element type of the array.</param>
    [PublicAPI]
    public static void EmitLoadArrayElementAddress(this ILGenerator il, Type arrayElementType)
        => il.Emit(OpCodes.Ldelema, arrayElementType);

    /// <summary>
    /// Pushes the number of elements of a zero-based, one-dimensional array onto the evaluation stack.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitLoadArrayLength(this ILGenerator il)
        => il.Emit(OpCodes.Ldlen);

    /// <summary>
    /// Pushes an object reference to a new zero-based, one-dimensional array of the given length whose elements are
    /// of a specific type onto the evaluation stack.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    /// <param name="elementType">The element type of the array.</param>
    /// <param name="elementCount">The number of elements in the array.</param>
    [PublicAPI]
    public static void EmitNewArray(this ILGenerator il, Type elementType, int elementCount)
    {
        il.EmitConstantInt(elementCount);
        il.EmitNewArray(elementType);
    }

    /// <summary>
    /// Pushes an object reference to a new zero-based, one-dimensional array of the given length whose elements are
    /// of a specific type onto the evaluation stack.
    /// </summary>
    /// <typeparam name="T">The element type of the array.</typeparam>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    /// <param name="elementCount">The number of elements in the array.</param>
    [PublicAPI]
    public static void EmitNewArray<T>(this ILGenerator il, int elementCount)
        => il.EmitNewArray(typeof(T), elementCount);

    /// <summary>
    /// Pushes an object reference to a new zero-based, one-dimensional array whose elements are of a specific type
    /// onto the evaluation stack.
    /// </summary>
    /// <typeparam name="T">The element type of the array.</typeparam>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitNewArray<T>(this ILGenerator il)
        => il.EmitNewArray(typeof(T));

    /// <summary>
    /// Pushes an object reference to a new zero-based, one-dimensional array whose elements are of a specific type
    /// onto the evaluation stack.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    /// <param name="arrayElementType">The element type of the array.</param>
    [PublicAPI]
    public static void EmitNewArray(this ILGenerator il, Type arrayElementType)
        => il.Emit(OpCodes.Newarr, arrayElementType);

    /// <summary>
    /// Replaces the array element at a given index with the value or object ref valueon the evaluation stack,
    /// whose type is specified in the instruction. This method will use the appropriate type-optimized instruction,
    /// if applicable.
    /// </summary>
    /// <typeparam name="T">The element type of the array.</typeparam>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitSetArrayElement<T>(this ILGenerator il)
        => il.EmitSetArrayElement(typeof(T));

    /// <summary>
    /// Replaces the array element at a given index with the value or object ref valueon the evaluation stack,
    /// whose type is specified in the instruction. This method will use the appropriate type-optimized instruction,
    /// if applicable.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    /// <param name="arrayElementType">The element type of the array.</param>
    [PublicAPI]
    public static void EmitSetArrayElement(this ILGenerator il, Type arrayElementType)
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
    /// Specifies that the subsequent array address operation performs no type check at run time, and that it
    /// returns a managed pointer whose mutability is restricted.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitReadonlyArrayAddressAccessPrefix(this ILGenerator il)
        => il.Emit(OpCodes.Readonly);
}
