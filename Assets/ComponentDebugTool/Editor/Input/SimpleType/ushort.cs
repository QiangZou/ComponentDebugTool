using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

namespace Zq.Tool
{
    public static partial class InputTool
    {
        public static void InputUshort(string describe, ref object value, ref bool isChange)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(describe);

            ushort newValue = 0;

            if (value != null)
            {
                newValue = (ushort)value;
            }

            InputUshort(ref newValue, ref isChange);

            if (isChange)
            {
                value = newValue;
            }

            EditorGUILayout.EndHorizontal();
        }

        public static void InputUshort(ref ushort value, ref bool isChange)
        {
            ushort newValue = (ushort)EditorGUILayout.DelayedIntField(value);

            if (newValue != value)
            {
                value = newValue;
                isChange = true;
            }
        }
    }

}

