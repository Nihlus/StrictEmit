//
//  SPDX-FileName: ILGeneratorExtensions.Properties.cs
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
    /// Pops the value on the evaluation stack, setting the named property's value to it.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    /// <param name="containingType">The type in which the property is defined.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="flags">The binding flags to use.</param>
    [PublicAPI]
    public static void EmitSetProperty
    (
        this ILGenerator il,
        Type containingType,
        string propertyName,
        BindingFlags flags
    )
    {
            var property = containingType.GetProperty(propertyName, flags);
            if (property is null)
            {
                throw new ArgumentException
                (
                    $"The type {containingType.Name} did not contain a property with that name."
                );
            }

            if (!property.CanWrite || property.SetMethod is null)
            {
                throw new ArgumentException($"The property \"{property.Name}\" doesn't have a setter.");
            }

            il.EmitCallDirect(property.SetMethod);
        }

    /// <summary>
    /// Pops the value on the evaluation stack, setting the named property's value to it.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    /// <param name="containingType">The type in which the property is defined.</param>
    /// <param name="propertyName">The name of the property.</param>
    [PublicAPI]
    public static void EmitSetProperty
    (
        this ILGenerator il,
        Type containingType,
        string propertyName
    )
        => il.EmitSetProperty(containingType, propertyName, BindingFlags.Instance | BindingFlags.Public);

    /// <summary>
    /// Pops the value on the evaluation stack, setting the named property's value to it.
    /// </summary>
    /// <typeparam name="T">The type in which the property is defined.</typeparam>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    /// <param name="propertyName">The name of the property.</param>
    [PublicAPI]
    public static void EmitSetProperty<T>(this ILGenerator il, string propertyName)
        => EmitSetProperty(il, typeof(T), propertyName);

    /// <summary>
    /// Pops the value on the evaluation stack, setting the named property's value to it.
    /// </summary>
    /// <typeparam name="T">The type in which the property is defined.</typeparam>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="flags">The binding flags to use.</param>
    [PublicAPI]
    public static void EmitSetProperty<T>
    (
        this ILGenerator il,
        string propertyName,
        BindingFlags flags
    )
        => EmitSetProperty(il, typeof(T), propertyName, flags);

    /// <summary>
    /// Gets the value of the named property, placing it onto the evaluation stack.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    /// <param name="containingType">The type in which the property is defined.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="flags">The binding flags to use.</param>
    [PublicAPI]
    public static void EmitGetProperty
    (
        this ILGenerator il,
        Type containingType,
        string propertyName,
        BindingFlags flags
    )
    {
            var property = containingType.GetProperty(propertyName, flags);
            if (property is null)
            {
                throw new ArgumentException
                (
                    $"The type {containingType.Name} did not contain a property with that name."
                );
            }

            if (!property.CanRead || property.GetMethod is null)
            {
                throw new ArgumentException($"The property \"{property.Name}\" doesn't have a getter.");
            }

            il.EmitCallDirect(property.GetMethod);
        }

    /// <summary>
    /// Gets the value of the named property, placing it onto the evaluation stack.
    /// </summary>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    /// <param name="containingType">The type in which the property is defined.</param>
    /// <param name="propertyName">The name of the property.</param>
    [PublicAPI]
    public static void EmitGetProperty
    (
        this ILGenerator il,
        Type containingType,
        string propertyName
    )
        => il.EmitGetProperty(containingType, propertyName, BindingFlags.Instance | BindingFlags.Public);

    /// <summary>
    /// Gets the value of the named property, placing it onto the evaluation stack.
    /// </summary>
    /// <typeparam name="T">The type in which the property is defined.</typeparam>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    /// <param name="propertyName">The name of the property.</param>
    [PublicAPI]
    public static void EmitGetProperty<T>(this ILGenerator il, string propertyName)
        => EmitGetProperty(il, typeof(T), propertyName);

    /// <summary>
    /// Gets the value of the named property, placing it onto the evaluation stack.
    /// </summary>
    /// <typeparam name="T">The type in which the property is defined.</typeparam>
    /// <param name="il">The generator where the IL is to be emitted.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="flags">The binding flags to use.</param>
    [PublicAPI]
    public static void EmitGetProperty<T>
    (
        this ILGenerator il,
        string propertyName,
        BindingFlags flags
    )
        => EmitGetProperty(il, typeof(T), propertyName, flags);
}
