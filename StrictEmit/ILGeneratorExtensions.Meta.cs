//
//  SPDX-FileName: ILGeneratorExtensions.Meta.cs
//  SPDX-FileCopyrightText: Copyright (c) Jarl Gullberg
//  SPDX-License-Identifier: GPL-3.0-or-later
//

using System.Reflection;
using System.Reflection.Emit;
using JetBrains.Annotations;

namespace StrictEmit
{
    public static partial class ILGeneratorExtensions
    {
        /// <summary>
        /// Emits a set of IL instructions which will retrieve the current method, and get the argument specified by the
        /// given index, pushing it as a <see cref="ParameterInfo"/> onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="argumentIndex">The index of the argument to get.</param>
        [PublicAPI]
        public static void EmitGetCurrentMethodArgumentByIndex(this ILGenerator il, int argumentIndex)
        {
            if (argumentIndex == 0)
            {
                il.EmitGetCurrentMethodReturnParameter();
            }
            else
            {
                il.EmitGetCurrentMethodParameterByIndex(argumentIndex - 1);
            }
        }

        /// <summary>
        /// Emits a set of IL instructions which will retrieve the current method, get its parameters, and then get the
        /// parameter at the given index, pushing it onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        /// <param name="parameterIndex">The index of the parameter to get in the parameter array.</param>
        [PublicAPI]
        public static void EmitGetCurrentMethodParameterByIndex(this ILGenerator il, int parameterIndex)
        {
            il.EmitCallDirect<MethodBase>(nameof(MethodBase.GetCurrentMethod));
            il.EmitCallVirtual<MethodBase>(nameof(MethodBase.GetParameters));
            il.EmitConstantInt(parameterIndex);
            il.EmitLoadArrayElement(typeof(MethodBase));
        }

        /// <summary>
        /// Emits a set of IL instructions which will retrieve the current method, get its return value parameter, and
        /// push it onto the evaluation stack.
        /// </summary>
        /// <param name="il">The generator where the IL is to be emitted.</param>
        [PublicAPI]
        public static void EmitGetCurrentMethodReturnParameter(this ILGenerator il)
        {
            var getReturnParamFunc = typeof(MethodInfo)
                .GetProperty(nameof(MethodInfo.ReturnParameter), BindingFlags.Public | BindingFlags.Instance)!
                .GetMethod!;

            il.EmitCallDirect<MethodBase>(nameof(MethodBase.GetCurrentMethod));
            il.EmitCallVirtual(getReturnParamFunc);
        }
    }
}
