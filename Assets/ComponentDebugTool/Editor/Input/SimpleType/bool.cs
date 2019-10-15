using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

namespace Zq.Tool
{
    public static partial class InputTool
    {
        public static void InputBool(string describe, ref object value, ref bool isChange)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(describe);

            bool newValue = false;

            if (value != null)
            {
                newValue = (bool)value;
            }

            InputBool(ref newValue, ref isChange);

            if (isChange)
            {
                value = newValue;
            }

            EditorGUILayout.EndHorizontal();
        }

        public static void InputBool(ref bool value, ref bool isChange)
        {

            bool newValue = EditorGUILayout.Toggle(value);

            if (newValue != value)
            {
                value = newValue;
                isChange = true;
            }
        }
    }

}

