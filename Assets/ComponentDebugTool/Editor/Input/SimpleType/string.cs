using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

namespace Zq.Tool
{
    public static partial class InputTool
    {
        public static void InputString(string describe, ref object value, ref bool isChange)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(describe);

            if (value == null)
            {
                value = "null";
            }

            string newValue = (string)value;

            InputString(ref newValue, ref isChange);

            if (isChange)
            {
                value = newValue;
            }

            EditorGUILayout.EndHorizontal();
        }

        public static void InputString(string describe, ref string value, ref bool isChange)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(describe);

            InputString(ref value, ref isChange);

            EditorGUILayout.EndHorizontal();
        }

        public static void InputString(ref string value, ref bool isChange)
        {
            string newValue = EditorGUILayout.DelayedTextField(value);

            if (newValue != value)
            {
                value = newValue;

                if (value == "null")
                {
                    value = null;
                }

                isChange = true;
            }
        }
    }

}

