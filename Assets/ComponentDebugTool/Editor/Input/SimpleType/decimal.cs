using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

namespace Zq.Tool
{
    public static partial class InputTool
    {
        public static void InputDecimal(string describe, ref object value, ref bool isChange)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(describe);

            decimal newValue = 0;

            if (value != null)
            {
                newValue = (decimal)value;
            }


            InputDecimal(ref newValue, ref isChange);
            if (isChange)
            {
                value = newValue;
            }

            EditorGUILayout.EndHorizontal();
        }

        public static void InputDecimal(ref decimal value, ref bool isChange)
        {
            string oldValue = value.ToString();
            string newValue = EditorGUILayout.DelayedTextField(oldValue);

            if (newValue != oldValue)
            {
                decimal.TryParse(newValue, out value);
                isChange = true;
            }
        }
    }

}

