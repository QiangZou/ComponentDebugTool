using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

namespace Zq.Tool
{
    public static partial class InputTool
    {
        public static void InputSbyte(string describe, ref object value, ref bool isChange)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(describe);

            sbyte newValue = 0;

            if (value != null)
            {
                newValue = (sbyte)value;
            }

            InputSbyte(describe, ref newValue, ref isChange);

            if (isChange)
            {
                value = newValue;
            }

            EditorGUILayout.EndHorizontal();
        }

        public static void InputSbyte(string describe, ref sbyte value, ref bool isChange)
        {
            sbyte newValue = (sbyte)EditorGUILayout.DelayedIntField(value);

            if (newValue != value)
            {
                value = newValue;
                isChange = true;
            }
        }
    }

}

