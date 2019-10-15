using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

namespace Zq.Tool
{
    public static partial class InputTool
    {
        public static void InputLong(string describe, ref object value, ref bool isChange)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(describe);

            long newValue = 0;

            if (value != null)
            {
                newValue = (long)value;
            }

            InputLong(describe, ref newValue, ref isChange);

            if (isChange)
            {
                value = newValue;

            }

            EditorGUILayout.EndHorizontal();
        }

        public static void InputLong(string describe, ref long value, ref bool isChange)
        {
            string oldValue = value.ToString();
            string newValue = EditorGUILayout.DelayedTextField(oldValue);

            if (newValue != oldValue)
            {
                long.TryParse(newValue, out value);
                isChange = true;
            }
        }
    }

}

