using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

namespace Zq.Tool
{
    public static partial class InputTool
    {
        public static void InputFloat(string describe, ref object value, ref bool isChange)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(describe);

            float newValue = 0;

            if (value != null)
            {
                newValue = (float)value;
            }

            InputFloat(describe, ref newValue, ref isChange);

            if (isChange)
            {
                value = newValue;

            }

            EditorGUILayout.EndHorizontal();
        }

        public static void InputFloat(string describe, ref float value, ref bool isChange)
        {
            float newValue = EditorGUILayout.DelayedFloatField(value);

            if (newValue != value)
            {
                value = newValue;
                isChange = true;
            }
        }
    }

}

