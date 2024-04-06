//
//  SPDX-FileName: ILGeneratorExtensions.Objects.cs
//  SPDX-FileCopyrightText: Copyright (c) Jarl Gullberg
//  SPDX-License-Identifier: GPL-3.0-or-later
//

using System;
using System.Reflection;
using System.Reflection.Emit;
using JetBrains.Annotations;

namespace StrictEmit;

public static partial class ILGeneratorExtensions
{
    /// <summary>
    /// Creates a new object or a new instance of a value type, pushing an object reference
    /// (type <strong>O</strong>) onto the evaluation stack.
    /// </summary>
    /// <typeparam name="T">The type of object to create an instance of.</typeparam>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitNewObject<T>(this ILGenerator il)
    {
        var parameterlessConstructor = typeof(T).GetConstructor([]);
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
    /// <typeparam name="T">The type of object to create an instance of.</typeparam>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    /// <param name="parameterTypes">The parameter types that the constructor accepts.</param>
    [PublicAPI]
    public static void EmitNewObject<T>(this ILGenerator il, params Type[] parameterTypes)
    {
        var constructor = typeof(T).GetConstructor(parameterTypes);
        if (constructor is null)
        {
            throw new ArgumentException
            (
                $"The type {typeof(T).Name} does not contain a constructor with those parameter types."
            );
        }

        il.EmitNewObject(constructor);
    }

    /// <summary>
    /// Creates a new object or a new instance of a value type, pushing an object reference
    /// (type <strong>O</strong>) onto the evaluation stack.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    /// <param name="constructor">The constructor to use.</param>
    [PublicAPI]
    public static void EmitNewObject(this ILGenerator il, ConstructorInfo constructor)
        => il.Emit(OpCodes.Newobj, constructor);

    /// <summary>
    /// Copies a value of a specified type from the evaluation stack into a supplied memory address.
    /// </summary>
    /// <typeparam name="T">The type of object to set.</typeparam>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitSetObject<T>(this ILGenerator il)
        => il.EmitSetObject(typeof(T));

    /// <summary>
    /// Copies a value of a specified type from the evaluation stack into a supplied memory address.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    /// <param name="objectType">The type of the object.</param>
    [PublicAPI]
    public static void EmitSetObject(this ILGenerator il, Type objectType)
        => il.Emit(OpCodes.Stobj, objectType);

    /// <summary>
    /// Tests whether an object reference (type <strong>O</strong>) is an instance of a particular class.
    /// </summary>
    /// <typeparam name="T">The object type to test against.</typeparam>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    [PublicAPI]
    public static void EmitIsInstance<T>(this ILGenerator il)
        => il.EmitIsInstance(typeof(T));

    /// <summary>
    /// Tests whether an object reference (type <strong>O</strong>) is an instance of a particular class.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    /// <param name="typeToCheck">The object type to test against.</param>
    [PublicAPI]
    public static void EmitIsInstance(this ILGenerator il, Type typeToCheck)
        => il.Emit(OpCodes.Isinst, typeToCheck);
}
