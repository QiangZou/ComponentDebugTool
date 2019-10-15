using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

namespace Zq.Tool
{
    public static partial class InputTool
    {
        public static void InputByte(string describe, ref object value, ref bool isChange)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(describe);

            byte newValue = 0;

            if (value != null)
            {
                newValue = (byte)value;
            }

            InputByte(ref newValue, ref isChange);

            if (isChange)
            {
                value = newValue;
            }

            EditorGUILayout.EndHorizontal();
        }

        public static void InputByte(ref byte value, ref bool isChange)
        {
            byte newValue = (byte)EditorGUILayout.DelayedIntField(value);

            if (newValue != value)
            {
                value = newValue;
                isChange = true;
            }
        }
    }

}

