//
//  SPDX-FileName: ILGeneratorExtensions.Pointers.cs
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
    /// Stores a value or an object reference at a supplied address.
    /// </summary>
    /// <typeparam name="T">The type of the object to store.</typeparam>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitSet<T>(this ILGenerator il)
        => il.EmitSet(typeof(T));

    /// <summary>
    /// Stores a value or an object reference at a supplied address.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    /// <param name="type">The type of the object to store.</param>
    [PublicAPI]
    public static void EmitSet(this ILGenerator il, Type type)
    {
        switch (type)
        {
            case var _ when type == typeof(IntPtr):
            {
                il.Emit(OpCodes.Stind_I);
                break;
            }
            case var _ when type == typeof(sbyte):
            {
                il.Emit(OpCodes.Stind_I1);
                break;
            }
            case var _ when type == typeof(short):
            {
                il.Emit(OpCodes.Stind_I2);
                break;
            }
            case var _ when type == typeof(int):
            {
                il.Emit(OpCodes.Stind_I4);
                break;
            }
            case var _ when type == typeof(long):
            {
                il.Emit(OpCodes.Stind_I8);
                break;
            }
            case var _ when type == typeof(float):
            {
                il.Emit(OpCodes.Stind_R4);
                break;
            }
            case var _ when type == typeof(double):
            {
                il.Emit(OpCodes.Stind_R8);
                break;
            }
            case var _ when !type.IsValueType:
            {
                il.Emit(OpCodes.Stind_Ref);
                break;
            }
            default:
            {
                throw new ArgumentOutOfRangeException
                (
                    nameof(type),
                    $"Invalid type \"{type.Name}\"."
                );
            }
        }
    }

    /// <summary>
    /// Loads a value or object reference of the given type as a <strong>native int</strong> onto the evaluation
    /// stack ly.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitDereferencePointer<T>(this ILGenerator il)
        => il.EmitLoad<T>();

    /// <summary>
    /// Loads a value or object reference of the given type as a <strong>native int</strong> onto the evaluation
    /// stack ly.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    /// <param name="typeToDereference">The type.</param>
    [PublicAPI]
    public static void EmitDereferencePointer(this ILGenerator il, Type typeToDereference)
        => il.EmitLoad(typeToDereference);

    /// <summary>
    /// Loads a value or object reference of the given type as a <strong>native int</strong> onto the evaluation
    /// stack ly.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitLoad<T>(this ILGenerator il)
        => il.EmitLoad(typeof(T));

    /// <summary>
    /// Loads a value or object reference of the given type as a <strong>native int</strong> onto the evaluation
    /// stack ly.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    /// <param name="typeToLoad">The type.</param>
    [PublicAPI]
    public static void EmitLoad(this ILGenerator il, Type typeToLoad)
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
                throw new ArgumentOutOfRangeException(nameof(typeToLoad), "Unrecognized  type.");
            }
        }
    }

    /// <summary>
    /// Retrieves the type token embedded in a typed reference.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitRefAnyType(this ILGenerator il)
        => il.Emit(OpCodes.Refanytype);

    /// <summary>
    /// Retrieves the address (type <strong>&amp;</strong>) embedded in a typed reference.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitRefAnyVal<T>(this ILGenerator il)
        => il.EmitRefAnyVal(typeof(T));

    /// <summary>
    /// Retrieves the address (type <strong>&amp;</strong>) embedded in a typed reference.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    /// <param name="refType">The type of the reference.</param>
    [PublicAPI]
    public static void EmitRefAnyVal(this ILGenerator il, Type refType)
        => il.Emit(OpCodes.Refanyval, refType);

    /// <summary>
    /// Allocates a certain number of bytes from the local dynamic memory pool and pushes the address (a transient
    /// pointer, type <strong>*</strong>) of the first allocated byte onto the evaluation stack.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitLocalAllocateBytes(this ILGenerator il)
        => il.Emit(OpCodes.Localloc);

    /// <summary>
    /// Pushes a typed reference to an instance of a specific type onto the evaluation stack.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitMakeReferenceOfType<T>(this ILGenerator il)
        => il.EmitMakeReferenceOfType(typeof(T));

    /// <summary>
    /// Pushes a typed reference to an instance of a specific type onto the evaluation stack.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    /// <param name="type">The type to create a reference to.</param>
    [PublicAPI]
    public static void EmitMakeReferenceOfType(this ILGenerator il, Type type)
        => il.Emit(OpCodes.Mkrefany, type);
}
