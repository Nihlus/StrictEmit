//
//  ILGeneratorExtensions.Pointers.cs
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
using System.Reflection.Emit;
using JetBrains.Annotations;

namespace StrictEmit
{
    public static partial class ILGeneratorExtensions
    {
        /// <summary>
        /// Stores a value or an object reference at a supplied address.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="type">The type of the object to store.</param>
        [PublicAPI]
        public static void EmitSet([NotNull] this ILGenerator il, [NotNull] Type type)
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
        public static void EmitDereferencePointer<T>([NotNull] this ILGenerator il) => il.EmitLoad<T>();

        /// <summary>
        /// Loads a value or object reference of the given type as a <strong>native int</strong> onto the evaluation
        /// stack ly.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="typeToDereference">The type.</param>
        [PublicAPI]
        public static void EmitDereferencePointer([NotNull] this ILGenerator il, [NotNull] Type typeToDereference) =>
            il.EmitLoad(typeToDereference);

        /// <summary>
        /// Loads a value or object reference of the given type as a <strong>native int</strong> onto the evaluation
        /// stack ly.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitLoad<T>([NotNull] this ILGenerator il) => il.EmitLoad(typeof(T));

        /// <summary>
        /// Loads a value or object reference of the given type as a <strong>native int</strong> onto the evaluation
        /// stack ly.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="typeToLoad">The type.</param>
        [PublicAPI]
        public static void EmitLoad([NotNull] this ILGenerator il, [NotNull] Type typeToLoad)
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
    }
}
