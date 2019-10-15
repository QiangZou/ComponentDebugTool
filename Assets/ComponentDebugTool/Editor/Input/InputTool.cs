using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

namespace Zq.Tool
{
    public static partial class InputTool
    {
        public static void Input(Type type, string describe, ref object value, ref bool isChange)
        {
            if (type == typeof(int))
            {
                InputInt(describe, ref value, ref isChange);
            }
            else if (type == typeof(string))
            {
                InputString(describe, ref value, ref isChange);
            }
            else if (type == typeof(float))
            {
                InputFloat(describe, ref value, ref isChange);
            }
            else if (type == typeof(sbyte))
            {
                InputSbyte(describe, ref value, ref isChange);
            }
            else if (type == typeof(byte))
            {
                InputByte(describe, ref value, ref isChange);
            }
            else if (type == typeof(short))
            {
                InputShort(describe, ref value, ref isChange);
            }
            else if (type == typeof(ushort))
            {
                InputUshort(describe, ref value, ref isChange);
            }
            else if (type == typeof(long))
            {
                InputLong(describe, ref value, ref isChange);
            }
            else if (type == typeof(ulong))
            {
                InputUlong(describe, ref value, ref isChange);
            }
            else if (type == typeof(double))
            {
                InputDouble(describe, ref value, ref isChange);
            }
            else if (type == typeof(decimal))
            {
                InputDecimal(describe, ref value, ref isChange);
            }
            else if (type == typeof(uint))
            {
                InputUint(describe, ref value, ref isChange);
            }
            else if (type == typeof(bool))
            {
                InputBool(describe, ref value, ref isChange);
            }
            else if (type == typeof(char))
            {
                InputChar(describe, ref value, ref isChange);
            }
            else if (TypeTool.IsComponent(type) || type == typeof(GameObject))
            {
                EditorGUILayout.BeginHorizontal();

                EditorGUILayout.LabelField(describe);

                UnityEngine.Object newValue = EditorGUILayout.ObjectField(value as UnityEngine.Object, type, true);
                if (newValue != value as UnityEngine.Object)
                {
                    isChange = true;
                    value = newValue;
                }

                EditorGUILayout.EndHorizontal();
            }
            else if (type == typeof(Vector2))
            {
                Vector2 newValue = EditorGUILayout.Vector2Field(describe, (Vector2)value);
                if (newValue != (Vector2)value)
                {
                    isChange = true;
                    value = newValue;
                }
            }
            else if (type == typeof(Vector3))
            {
                Vector3 newValue = EditorGUILayout.Vector3Field(describe, (Vector3)value);
                if (newValue != (Vector3)value)
                {
                    isChange = true;
                    value = newValue;
                }
            }
            else if (type == typeof(Vector4))
            {
                Vector4 newValue = EditorGUILayout.Vector4Field(describe, (Vector4)value);
                if (newValue != (Vector4)value)
                {
                    isChange = true;
                    value = newValue;
                }
            }
            else if (type == typeof(Color))
            {
                Color newValue = EditorGUILayout.ColorField(describe, (Color)value);
                if (newValue != (Color)value)
                {
                    isChange = true;
                    value = newValue;
                }
            }
            else if (type.IsEnum)
            {
                Enum a = value as Enum;

                EditorGUILayout.BeginHorizontal();

                EditorGUILayout.LabelField(describe);

                Enum newValue = EditorGUILayout.EnumPopup(a);
                if (newValue != a)
                {
                    isChange = true;
                    value = newValue;
                }

                EditorGUILayout.EndHorizontal();
            }
            else
            {
                EditorGUILayout.BeginHorizontal();

                EditorGUILayout.LabelField(describe + " 尚未解析该类型 :" + type.Name);

                EditorGUILayout.EndHorizontal();
            }
        }
    }

}

