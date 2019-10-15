using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

namespace Zq.Tool
{
    public static partial class InputTool
    {
        public static void InputUint(string describe, ref object value, ref bool isChange)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(describe);

            uint newValue = 0;

            if (value != null)
            {
                newValue = (uint)value;
            }


            InputUint(ref newValue, ref isChange);

            if (isChange)
            {
                value = newValue;

            }
            EditorGUILayout.EndHorizontal();
        }

        public static void InputUint(ref uint value, ref bool isChange)
        {
            string oldValue = value.ToString();
            string newValue = EditorGUILayout.DelayedTextField(oldValue);

            if (newValue != oldValue)
            {
                uint.TryParse(newValue, out value);
                isChange = true;
            }
        }


    }

}

