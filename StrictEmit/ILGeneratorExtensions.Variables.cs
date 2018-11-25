//
//  ILGeneratorExtensions.Variables.cs
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
        public static void EmitLoadArgument([NotNull] this ILGenerator il, short argumentIndex)
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
                    if (argumentIndex >= 4 && argumentIndex <= 255)
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
        public static void EmitLoadArgumentAddress([NotNull] this ILGenerator il, short argumentIndex)
        {
            if (argumentIndex >= 4 && argumentIndex <= 255)
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
        public static void EmitLoadField([NotNull] this ILGenerator il, [NotNull] FieldInfo field)
            => il.Emit(OpCodes.Ldfld, field);

        /// <summary>
        /// Finds the address of a field in the object whose reference is currently on the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="field">The field.</param>
        [PublicAPI]
        public static void EmitLoadFieldAddress([NotNull] this ILGenerator il, [NotNull] FieldInfo field)
            => il.Emit(OpCodes.Ldflda, field);

        /// <summary>
        /// Loads the local variable at a specific index onto the evaluation stack. This method will use the appropriate
        /// constant- or short-optimized instruction, if applicable.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="localIndex">The index of the local variable.</param>
        [PublicAPI]
        public static void EmitLoadLocalVariable([NotNull] this ILGenerator il, short localIndex)
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
                    if (localIndex >= 4 && localIndex <= 255)
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
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="local">The local variable.</param>
        [PublicAPI]
        public static void EmitLoadLocalVariable([NotNull] this ILGenerator il, [NotNull] LocalBuilder local)
            => il.Emit(OpCodes.Ldloc, local);

        /// <summary>
        /// Loads the address of the local variable at a specific index onto the evaluation stack. This method will use
        /// the appropriate short-optimized instruction, if applicable.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="localIndex">The index of the variable.</param>
        [PublicAPI]
        public static void EmitLoadLocalVariableAddress([NotNull] this ILGenerator il, int localIndex)
        {
            if (localIndex >= 4 && localIndex <= 255)
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
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="local">The local variable.</param>
        [PublicAPI]
        public static void EmitLoadLocalVariableAddress([NotNull] this ILGenerator il, [NotNull] LocalBuilder local)
            => il.Emit(OpCodes.Ldloca, local);

        /// <summary>
        /// Copies the value type object pointed to by an address to the top of the evaluation stack.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitLoadObject<T>([NotNull] this ILGenerator il)
            => il.EmitLoadObject(typeof(T));

        /// <summary>
        /// Copies the value type object pointed to by an address to the top of the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="valueType">The type.</param>
        [PublicAPI]
        public static void EmitLoadObject([NotNull] this ILGenerator il, [NotNull] Type valueType)
            => il.Emit(OpCodes.Ldobj, valueType);

        /// <summary>
        /// Pushes the value of a static field onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="field">The field.</param>
        [PublicAPI]
        public static void EmitLoadStaticField([NotNull] this ILGenerator il, [NotNull] FieldInfo field)
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
        public static void EmitLoadStaticFieldAddress([NotNull] this ILGenerator il, [NotNull] FieldInfo field)
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
        public static void EmitStoreArgument([NotNull] this ILGenerator il, short argumentIndex)
        {
            if (argumentIndex >= 4 && argumentIndex <= 255)
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
        public static void EmitSetField([NotNull] this ILGenerator il, [NotNull] FieldInfo field)
            => il.Emit(OpCodes.Stfld, field);

        /// <summary>
        /// Pops the current value from the top of the evaluation stack and stores it in the local variable at a
        /// specified index. This method will use the appropriate constant-optimized instruction, if applicable.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="localIndex">The index of the local variable.</param>
        [PublicAPI]
        public static void EmitSetLocalVariable([NotNull] this ILGenerator il, short localIndex)
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
                    if (localIndex >= 4 && localIndex <= 255)
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
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="local">The local variable.</param>
        [PublicAPI]
        public static void EmitSetLocalVariable([NotNull] this ILGenerator il, [NotNull] LocalBuilder local)
            => il.Emit(OpCodes.Stloc, local);

        /// <summary>
        /// Replaces the value of a static field with a value from the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="field">The field.</param>
        [PublicAPI]
        public static void EmitSetStaticField([NotNull] this ILGenerator il, [NotNull] FieldInfo field)
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
        public static void EmitUnalignedPrefix([NotNull] this ILGenerator il, Label instruction)
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
        public static void EmitUnalignedPrefix([NotNull] this ILGenerator il, byte offset)
            => il.Emit(OpCodes.Unaligned, offset);

        /// <summary>
        /// Declares a local of type T.
        /// </summary>
        /// <typeparam name="T">The type of the newly generated local.</typeparam>
        /// <param name="il">The generator where the local is to be declared.</param>
        /// <param name="pinned">true to pin the object in memory; otherwise, false.</param>
        /// <returns>The LocalBuilder declared with type T.</returns>
        [PublicAPI, NotNull]
        public static LocalBuilder DeclareLocal<T>([NotNull] this ILGenerator il, bool pinned = false) => il.DeclareLocal(typeof(T), pinned);
    }
}
