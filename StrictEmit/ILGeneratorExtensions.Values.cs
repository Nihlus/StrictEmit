﻿//
//  SPDX-FileName: ILGeneratorExtensions.Values.cs
//  SPDX-FileCopyrightText: Copyright (c) Jarl Gullberg
//  SPDX-License-Identifier: GPL-3.0-or-later
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
        /// Returns an unmanaged pointer to the argument list of the current method.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitGetArglistPointer(this ILGenerator il)
            => il.Emit(OpCodes.Arglist);

        /// <summary>
        /// Converts a value type to an object reference (type <strong>O</strong>).
        /// </summary>
        /// <typeparam name="T">The type to box into an object reference.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitBox<T>(this ILGenerator il)
            => il.EmitBox(typeof(T));

        /// <summary>
        /// Converts a value type to an object reference (type <strong>O</strong>).
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="typeToBox">The type to box into an object reference.</param>
        [PublicAPI]
        public static void EmitBox(this ILGenerator il, Type typeToBox)
        {
            if (!typeToBox.IsValueType)
            {
                throw new ArgumentException("The type to box must be a value type.", nameof(typeToBox));
            }

            il.Emit(OpCodes.Box, typeToBox);
        }

        /// <summary>
        /// Copies a specified number bytes from a source address to a destination address.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitCopyBlock(this ILGenerator il)
            => il.Emit(OpCodes.Cpblk);

        /// <summary>
        /// Copies the value type located at the address of an object (type <strong>&amp;</strong>, <strong>*</strong>
        /// or <strong>native int</strong>) to the address of the destination object (type <strong>&amp;</strong>,
        /// <strong>*</strong> or <strong>native int</strong>).
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitCopyObject<T>(this ILGenerator il)
            => il.EmitCopyObject(typeof(T));

        /// <summary>
        /// Copies the value type located at the address of an object (type <strong>&amp;</strong>, <strong>*</strong>
        /// or <strong>native int</strong>) to the address of the destination object (type <strong>&amp;</strong>,
        /// <strong>*</strong> or <strong>native int</strong>).
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="objectType">The type.</param>
        [PublicAPI]
        public static void EmitCopyObject(this ILGenerator il, Type objectType)
            => il.Emit(OpCodes.Cpobj, objectType);

        /// <summary>
        /// Copies the current topmost value on the evaluation stack, and then pushes the copy onto the evaluation
        /// stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitDuplicate(this ILGenerator il)
            => il.Emit(OpCodes.Dup);

        /// <summary>
        /// Initializes a specified block of memory at a specific address to a given size and initial value.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitInitBlock(this ILGenerator il)
            => il.Emit(OpCodes.Initblk);

        /// <summary>
        /// Initializes each field of the value type at a specified address to a null reference or a 0 of the
        /// appropriate primitive type.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitInitObject<T>(this ILGenerator il)
            => il.EmitInitObject(typeof(T));

        /// <summary>
        /// Initializes each field of the value type at a specified address to a null reference or a 0 of the
        /// appropriate primitive type.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="objectType">The type.</param>
        [PublicAPI]
        public static void EmitInitObject(this ILGenerator il, Type objectType)
            => il.Emit(OpCodes.Initobj, objectType);

        /// <summary>
        /// Pushes a supplied value onto the evaluation stack as an <strong>int32</strong>. This method will use the
        /// appropriate constant- or short-optimized instruction, if applicable.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="value">The value.</param>
        [PublicAPI]
        public static void EmitConstantInt(this ILGenerator il, int value)
        {
            switch (value)
            {
                case -1:
                {
                    il.Emit(OpCodes.Ldc_I4_M1);
                    break;
                }
                case 0:
                {
                    il.Emit(OpCodes.Ldc_I4_0);
                    break;
                }
                case 1:
                {
                    il.Emit(OpCodes.Ldc_I4_1);
                    break;
                }
                case 2:
                {
                    il.Emit(OpCodes.Ldc_I4_2);
                    break;
                }
                case 3:
                {
                    il.Emit(OpCodes.Ldc_I4_3);
                    break;
                }
                case 4:
                {
                    il.Emit(OpCodes.Ldc_I4_4);
                    break;
                }
                case 5:
                {
                    il.Emit(OpCodes.Ldc_I4_5);
                    break;
                }
                case 6:
                {
                    il.Emit(OpCodes.Ldc_I4_6);
                    break;
                }
                case 7:
                {
                    il.Emit(OpCodes.Ldc_I4_7);
                    break;
                }
                case 8:
                {
                    il.Emit(OpCodes.Ldc_I4_8);
                    break;
                }
                default:
                {
                    if (value > 8 && value <= 255)
                    {
                        il.Emit(OpCodes.Ldc_I4_S, (byte)value);
                    }
                    else
                    {
                        il.Emit(OpCodes.Ldc_I4, value);
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Pushes a supplied value of type <strong>int64</strong> onto the evaluation stack as an <strong>int64</strong>.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="value">The value.</param>
        [PublicAPI]
        public static void EmitConstantLong(this ILGenerator il, long value)
            => il.Emit(OpCodes.Ldc_I8, value);

        /// <summary>
        /// Pushes a supplied value of type <strong>float32</strong> onto the evaluation stack as type
        /// <strong>F</strong> (float).
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="value">The value.</param>
        [PublicAPI]
        public static void EmitConstantFloat(this ILGenerator il, float value)
            => il.Emit(OpCodes.Ldc_R4, value);

        /// <summary>
        /// Pushes a supplied value of type <strong>float64</strong> onto the evaluation stack as type
        /// <strong>F</strong> (float).
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="value">The value.</param>
        [PublicAPI]
        public static void EmitConstantDouble(this ILGenerator il, double value)
            => il.Emit(OpCodes.Ldc_R8, value);

        /// <summary>
        /// Pushes a null reference (type <strong>O</strong>) onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitLoadNull(this ILGenerator il)
            => il.Emit(OpCodes.Ldnull);

        /// <summary>
        /// Pushes a new object reference to a string literal stored in the metadata.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="value">The string value.</param>
        [PublicAPI]
        public static void EmitConstantString(this ILGenerator il, string value)
            => il.Emit(OpCodes.Ldstr, value);

        /// <summary>
        /// Converts a <see cref="MethodInfo"/> token to its runtime representation, pushing it onto the evaluation
        /// stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="method">The method.</param>
        [PublicAPI]
        public static void EmitLoadToken(this ILGenerator il, MethodInfo method)
            => il.Emit(OpCodes.Ldtoken, method);

        /// <summary>
        /// Converts a <see cref="FieldInfo"/> token to its runtime representation, pushing it onto the evaluation
        /// stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="field">The field.</param>
        [PublicAPI]
        public static void EmitLoadToken(this ILGenerator il, FieldInfo field)
            => il.Emit(OpCodes.Ldtoken, field);

        /// <summary>
        /// Converts a <see cref="Type"/> token to its runtime representation, pushing it onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="type">The type to convert to its runtime representation.</param>
        [PublicAPI]
        public static void EmitLoadToken(this ILGenerator il, Type type)
            => il.Emit(OpCodes.Ldtoken, type);

        /// <summary>
        /// Converts the boxed representation of a value type to its unboxed form.
        /// </summary>
        /// <typeparam name="T">The type to unbox.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitUnbox<T>(this ILGenerator il)
            => il.EmitUnbox(typeof(T));

        /// <summary>
        /// Converts the boxed representation of a value type to its unboxed form.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="type">The type to unbox.</param>
        [PublicAPI]
        public static void EmitUnbox(this ILGenerator il, Type type)
            => il.Emit(OpCodes.Unbox, type);

        /// <summary>
        /// Converts the boxed representation of a type specified in the instruction to its unboxed form.
        /// </summary>
        /// <typeparam name="T">The type to unbox.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitUnboxAny<T>(this ILGenerator il)
            => il.EmitUnboxAny(typeof(T));

        /// <summary>
        /// Converts the boxed representation of a type specified in the instruction to its unboxed form.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="type">The type to unbox.</param>
        [PublicAPI]
        public static void EmitUnboxAny(this ILGenerator il, Type type)
            => il.Emit(OpCodes.Unbox_Any, type);
    }
}
