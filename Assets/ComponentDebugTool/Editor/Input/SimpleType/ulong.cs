using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

namespace Zq.Tool
{
    public static partial class InputTool
    {
        public static void InputUlong(string describe, ref object value, ref bool isChange)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(describe);

            ulong newValue = 0;

            if (value != null)
            {
                newValue = (ulong)value;
            }

            InputUlong(ref newValue, ref isChange);

            if (isChange)
            {
                value = newValue;
            }

            EditorGUILayout.EndHorizontal();
        }

        public static void InputUlong(ref ulong value, ref bool isChange)
        {
            string oldValue = value.ToString();
            string newValue = EditorGUILayout.DelayedTextField(oldValue);

            if (newValue != oldValue)
            {
                ulong.TryParse(newValue, out value);
                isChange = true;
            }
        }
    }

}

