using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

namespace Zq.Tool
{
    public static partial class InputTool
    {
        public static void InputChar(string describe, ref object value, ref bool isChange)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(describe);

            char newValue = char.MinValue;

            if (value != null)
            {
                newValue = (char)value;
            }

            InputChar(ref newValue, ref isChange);

            if (isChange)
            {
                value = newValue;
            }

            EditorGUILayout.EndHorizontal();
        }

        public static void InputChar(ref char value, ref bool isChange)
        {
            string oldValue = value.ToString();
            string newValue = EditorGUILayout.DelayedTextField(oldValue);

            if (newValue != oldValue)
            {
                char.TryParse(newValue, out value);
                isChange = true;
            }
        }
    }

}

