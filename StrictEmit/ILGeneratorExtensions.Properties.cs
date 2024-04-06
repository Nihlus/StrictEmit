//
//  ILGeneratorExtensions.Properties.cs
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
using System.Reflection;
using System.Reflection.Emit;
using JetBrains.Annotations;

namespace StrictEmit
{
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
            [NotNull] this ILGenerator il,
            [NotNull] Type containingType,
            [NotNull] string propertyName,
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

            if (!property.CanWrite)
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
            [NotNull] this ILGenerator il,
            [NotNull] Type containingType,
            [NotNull] string propertyName
        )
        => il.EmitSetProperty(containingType, propertyName, BindingFlags.Instance | BindingFlags.Public);

        /// <summary>
        /// Pops the value on the evaluation stack, setting the named property's value to it.
        /// </summary>
        /// <typeparam name="T">The type in which the property is defined.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="propertyName">The name of the property.</param>
        [PublicAPI]
        public static void EmitSetProperty<T>([NotNull] this ILGenerator il, [NotNull] string propertyName)
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
            [NotNull] this ILGenerator il,
            [NotNull] string propertyName,
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
            [NotNull] this ILGenerator il,
            [NotNull] Type containingType,
            [NotNull] string propertyName,
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

            if (!property.CanRead)
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
            [NotNull] this ILGenerator il,
            [NotNull] Type containingType,
            [NotNull] string propertyName
        )
            => il.EmitGetProperty(containingType, propertyName, BindingFlags.Instance | BindingFlags.Public);

        /// <summary>
        /// Gets the value of the named property, placing it onto the evaluation stack.
        /// </summary>
        /// <typeparam name="T">The type in which the property is defined.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="propertyName">The name of the property.</param>
        [PublicAPI]
        public static void EmitGetProperty<T>([NotNull] this ILGenerator il, [NotNull] string propertyName)
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
            [NotNull] this ILGenerator il,
            [NotNull] string propertyName,
            BindingFlags flags
        )
        => EmitGetProperty(il, typeof(T), propertyName, flags);
    }
}
