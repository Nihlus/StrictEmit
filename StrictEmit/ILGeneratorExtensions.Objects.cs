//
//  ILGeneratorExtensions.Objects.cs
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
        /// Creates a new object or a new instance of a value type, pushing an object reference
        /// (type <strong>O</strong>) onto the evaluation stack.
        /// </summary>
        /// <typeparam name="T">The type of object to create an instance of.</typeparam>
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
        /// <typeparam name="T">The type of object to create an instance of.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="parameterTypes">The parameter types that the constructor accepts.</param>
        [PublicAPI]
        public static void EmitNewObject<T>([NotNull] this ILGenerator il, params Type[] parameterTypes)
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
        public static void EmitNewObject([NotNull] this ILGenerator il, [NotNull] ConstructorInfo constructor)
            => il.Emit(OpCodes.Newobj, constructor);

        /// <summary>
        /// Copies a value of a specified type from the evaluation stack into a supplied memory address.
        /// </summary>
        /// <typeparam name="T">The type of object to set.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitSetObject<T>([NotNull] this ILGenerator il)
            => il.EmitSetObject(typeof(T));

        /// <summary>
        /// Copies a value of a specified type from the evaluation stack into a supplied memory address.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="objectType">The type of the object.</param>
        [PublicAPI]
        public static void EmitSetObject([NotNull] this ILGenerator il, [NotNull] Type objectType)
            => il.Emit(OpCodes.Stobj, objectType);

        /// <summary>
        /// Tests whether an object reference (type <strong>O</strong>) is an instance of a particular class.
        /// </summary>
        /// <typeparam name="T">The object type to test against.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitIsInstance<T>([NotNull] this ILGenerator il)
            => il.EmitIsInstance(typeof(T));

        /// <summary>
        /// Tests whether an object reference (type <strong>O</strong>) is an instance of a particular class.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="typeToCheck">The object type to test against.</param>
        [PublicAPI]
        public static void EmitIsInstance([NotNull] this ILGenerator il, [NotNull] Type typeToCheck)
            => il.Emit(OpCodes.Isinst, typeToCheck);
    }
}
