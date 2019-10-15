using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

namespace Zq.Tool
{
    public static partial class InputTool
    {
        public static void InputInt(string describe, ref object value, ref bool isChange)
        {
            int newValue = 0;

            if (value != null)
            {
                newValue = (int)value;
            }

            InputInt(describe, ref newValue, ref isChange);

            if (isChange)
            {
                value = newValue;
            }
        }

        public static void InputInt(string describe, ref int value, ref bool isChange)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(describe);

            InputInt(ref value, ref isChange);

            EditorGUILayout.EndHorizontal();
        }

        public static void InputInt(ref int value, ref bool isChange)
        {
            int newValue = EditorGUILayout.DelayedIntField(value);

            if (newValue != value)
            {
                value = newValue;

                isChange = true;
            }
        }
    }

}

