//
//  SPDX-FileName: ILGeneratorExtensions.Variables.cs
//  SPDX-FileCopyrightText: Copyright (c) Jarl Gullberg
//  SPDX-License-Identifier: GPL-3.0-or-later
//

#pragma warning disable SA1513

using System;
using System.Reflection;
using System.Reflection.Emit;
using JetBrains.Annotations;

namespace StrictEmit
{
    public static partial class ILGeneratorExtensions
    {
        /// <summary>
        /// Loads an argument (referenced by a specified index value) onto the stack. This method will use the
        /// appropriate constant- or short-optimized instruction, if applicable.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="argumentIndex">The argument index.</param>
        [PublicAPI]
        public static void EmitLoadArgument(this ILGenerator il, short argumentIndex)
        {
            switch (argumentIndex)
            {
                case 0:
                {
                    il.Emit(OpCodes.Ldarg_0);
                    break;
                }
                case 1:
                {
                    il.Emit(OpCodes.Ldarg_1);
                    break;
                }
                case 2:
                {
                    il.Emit(OpCodes.Ldarg_2);
                    break;
                }
                case 3:
                {
                    il.Emit(OpCodes.Ldarg_3);
                    break;
                }
                default:
                {
                    if (argumentIndex > 3 && argumentIndex <= 255)
                    {
                        il.Emit(OpCodes.Ldarg_S, (byte)argumentIndex);
                    }
                    else
                    {
                        il.Emit(OpCodes.Ldarg, argumentIndex);
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Load an argument address onto the evaluation stack. This method will use the appropriate short-optimized
        /// instruction, if applicable.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="argumentIndex">The argument index.</param>
        [PublicAPI]
        public static void EmitLoadArgumentAddress(this ILGenerator il, short argumentIndex)
        {
            if (argumentIndex >= 0 && argumentIndex <= 255)
            {
                il.Emit(OpCodes.Ldarga_S, (byte)argumentIndex);
            }
            else
            {
                il.Emit(OpCodes.Ldarga, argumentIndex);
            }
        }

        /// <summary>
        /// Finds the value of a field in the object whose reference is currently on the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="field">The field.</param>
        [PublicAPI]
        public static void EmitLoadField(this ILGenerator il, FieldInfo field)
            => il.Emit(OpCodes.Ldfld, field);

        /// <summary>
        /// Finds the address of a field in the object whose reference is currently on the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="field">The field.</param>
        [PublicAPI]
        public static void EmitLoadFieldAddress(this ILGenerator il, FieldInfo field)
            => il.Emit(OpCodes.Ldflda, field);

        /// <summary>
        /// Loads the local variable at a specific index onto the evaluation stack. This method will use the appropriate
        /// constant- or short-optimized instruction, if applicable.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="localIndex">The index of the local variable.</param>
        [PublicAPI]
        public static void EmitLoadLocalVariable(this ILGenerator il, short localIndex)
        {
            switch (localIndex)
            {
                case 0:
                {
                    il.Emit(OpCodes.Ldloc_0);
                    break;
                }
                case 1:
                {
                    il.Emit(OpCodes.Ldloc_1);
                    break;
                }
                case 2:
                {
                    il.Emit(OpCodes.Ldloc_2);
                    break;
                }
                case 3:
                {
                    il.Emit(OpCodes.Ldloc_3);
                    break;
                }
                default:
                {
                    if (localIndex > 3 && localIndex <= 255)
                    {
                        il.Emit(OpCodes.Ldloc_S, (byte)localIndex);
                    }
                    else
                    {
                        il.Emit(OpCodes.Ldloc, localIndex);
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Loads the specified local variable onto the evaluation stack.
        /// </summary>
        /// <remarks>
        /// The <see cref="LocalBuilder.LocalIndex"/> is used instead of the <see cref="LocalBuilder"/> itself in order to take
        /// advantage of the optimized instructions in <see cref="EmitLoadLocalVariable(ILGenerator, short)"/>
        /// </remarks>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="local">The local variable.</param>
        [PublicAPI]
        public static void EmitLoadLocalVariable(this ILGenerator il, LocalBuilder local)
            => il.EmitLoadLocalVariable((short)local.LocalIndex);

        /// <summary>
        /// Loads the address of the local variable at a specific index onto the evaluation stack. This method will use
        /// the appropriate short-optimized instruction, if applicable.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="localIndex">The index of the variable.</param>
        [PublicAPI]
        public static void EmitLoadLocalVariableAddress(this ILGenerator il, short localIndex)
        {
            if (localIndex >= 0 && localIndex <= 255)
            {
                il.Emit(OpCodes.Ldloca_S, (byte)localIndex);
            }
            else
            {
                il.Emit(OpCodes.Ldloca, localIndex);
            }
        }

        /// <summary>
        /// Loads the address of the local variable at a specific index onto the evaluation stack.
        /// </summary>
        /// <remarks>
        /// The <see cref="LocalBuilder.LocalIndex"/> is used instead of the <see cref="LocalBuilder"/> itself in order to take
        /// advantage of the optimized instructions in <see cref="EmitLoadLocalVariableAddress(ILGenerator, short)"/>
        /// </remarks>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="local">The local variable.</param>
        [PublicAPI]
        public static void EmitLoadLocalVariableAddress(this ILGenerator il, LocalBuilder local)
            => il.EmitLoadLocalVariableAddress((short)local.LocalIndex);

        /// <summary>
        /// Copies the value type object pointed to by an address to the top of the evaluation stack.
        /// </summary>
        /// <typeparam name="T">The type of object to load.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitLoadObject<T>(this ILGenerator il)
            => il.EmitLoadObject(typeof(T));

        /// <summary>
        /// Copies the value type object pointed to by an address to the top of the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="valueType">The type of object to load.</param>
        [PublicAPI]
        public static void EmitLoadObject(this ILGenerator il, Type valueType)
            => il.Emit(OpCodes.Ldobj, valueType);

        /// <summary>
        /// Pushes the value of a static field onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="field">The field.</param>
        [PublicAPI]
        public static void EmitLoadStaticField(this ILGenerator il, FieldInfo field)
        {
            if (!field.IsStatic)
            {
                throw new ArgumentException("The given field was not static.", nameof(field));
            }

            il.Emit(OpCodes.Ldsfld, field);
        }

        /// <summary>
        /// Pushes the address of a static field onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="field">The field.</param>
        [PublicAPI]
        public static void EmitLoadStaticFieldAddress(this ILGenerator il, FieldInfo field)
        {
            if (!field.IsStatic)
            {
                throw new ArgumentException("The given field was not static.", nameof(field));
            }

            il.Emit(OpCodes.Ldsflda, field);
        }

        /// <summary>
        /// Stores the value on top of the evaluation stack in the argument slot at a specified index. This method will
        /// use the short-optimized instruction, if applicable.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="argumentIndex">The index of the argument.</param>
        [PublicAPI]
        public static void EmitStoreArgument(this ILGenerator il, short argumentIndex)
        {
            if (argumentIndex >= 0 && argumentIndex <= 255)
            {
                il.Emit(OpCodes.Starg_S, (byte)argumentIndex);
            }
            else
            {
                il.Emit(OpCodes.Starg);
            }
        }

        /// <summary>
        /// Replaces the value stored in the field of an object reference or pointer with a new value.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="field">The field.</param>
        [PublicAPI]
        public static void EmitSetField(this ILGenerator il, FieldInfo field)
            => il.Emit(OpCodes.Stfld, field);

        /// <summary>
        /// Pops the current value from the top of the evaluation stack and stores it in the local variable at a
        /// specified index. This method will use the appropriate constant-optimized instruction, if applicable.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="localIndex">The index of the local variable.</param>
        [PublicAPI]
        public static void EmitSetLocalVariable(this ILGenerator il, short localIndex)
        {
            switch (localIndex)
            {
                case 0:
                {
                    il.Emit(OpCodes.Stloc_0);
                    break;
                }
                case 1:
                {
                    il.Emit(OpCodes.Stloc_1);
                    break;
                }
                case 2:
                {
                    il.Emit(OpCodes.Stloc_2);
                    break;
                }
                case 3:
                {
                    il.Emit(OpCodes.Stloc_3);
                    break;
                }
                default:
                {
                    if (localIndex > 3 && localIndex <= 255)
                    {
                        il.Emit(OpCodes.Stloc_S, (byte)localIndex);
                    }
                    else
                    {
                        il.Emit(OpCodes.Stloc, localIndex);
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Pops the current value from the top of the evaluation stack and stores it in the specified local variable.
        /// </summary>
        /// <remarks>
        /// The <see cref="LocalBuilder.LocalIndex"/> is used instead of the <see cref="LocalBuilder"/> itself in order to take
        /// advantage of the optimized instructions in <see cref="EmitSetLocalVariable(ILGenerator, short)"/>
        /// </remarks>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="local">The local variable.</param>
        [PublicAPI]
        public static void EmitSetLocalVariable(this ILGenerator il, LocalBuilder local)
            => il.EmitSetLocalVariable((short)local.LocalIndex);

        /// <summary>
        /// Replaces the value of a static field with a value from the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="field">The field.</param>
        [PublicAPI]
        public static void EmitSetStaticField(this ILGenerator il, FieldInfo field)
            => il.Emit(OpCodes.Stsfld, field);

        /// <summary>
        /// Indicates that an address currently atop the evaluation stack might not be aligned to the natural size of
        /// the immediately following <strong>ldind</strong>, <strong>stind</strong>, <strong>ldfld</strong>,
        /// <strong>stfld</strong>, <strong>ldobj</strong>, <strong>stobj</strong>, <strong>initblk</strong>, or
        /// <strong>cpblk</strong> instruction.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="instruction">The instruction.</param>
        [PublicAPI]
        public static void EmitUnalignedPrefix(this ILGenerator il, Label instruction)
            => il.Emit(OpCodes.Unaligned, instruction);

        /// <summary>
        /// Indicates that an address currently atop the evaluation stack might not be aligned to the natural size of
        /// the immediately following <strong>ldind</strong>, <strong>stind</strong>, <strong>ldfld</strong>,
        /// <strong>stfld</strong>, <strong>ldobj</strong>, <strong>stobj</strong>, <strong>initblk</strong>, or
        /// <strong>cpblk</strong> instruction.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="offset">The instruction offset.</param>
        [PublicAPI]
        public static void EmitUnalignedPrefix(this ILGenerator il, byte offset)
            => il.Emit(OpCodes.Unaligned, offset);

        /// <summary>
        /// Declares a local of type T.
        /// </summary>
        /// <typeparam name="T">The type of the newly generated local.</typeparam>
        /// <param name="il">The generator where the local is to be declared.</param>
        /// <param name="pinned">true to pin the object in memory; otherwise, false.</param>
        /// <returns>The LocalBuilder declared with type T.</returns>
        [PublicAPI]
        public static LocalBuilder DeclareLocal<T>(this ILGenerator il, bool pinned = false)
            => il.DeclareLocal(typeof(T), pinned);
    }
}
