using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Zq.Tool
{
    public class ClassData
    {
        public object instance;
        public Type type;
        public int level;
        public ClassData baseClassInfo;
        public List<FieldData> fields = new List<FieldData>();
        public List<MethodData> methods = new List<MethodData>();

        public ClassData(object obj, Type t, int index)
        {
            instance = obj;
            type = t;
            level = index;
        }

        public void InitBaseClassInfo()
        {
            if (type.BaseType != typeof(object) && type.BaseType != typeof(UnityEngine.Object))
            {
                baseClassInfo = new ClassData(instance, type.BaseType, level + 1);
            }
        }

        public void GetField()
        {
            fields = GetFields(instance, type, level);
        }

        public void GetMethod()
        {
            methods = GetMethods(instance, type);
        }

        public void RefreshInstance(object value)
        {
            instance = value;
        }

        public static List<FieldData> GetFields(object instance, Type type, int level)
        {
            List<FieldData> fields = new List<FieldData>();

            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);

            foreach (var item in fieldInfos)
            {
                FieldData field = new FieldData(instance, item, level + 1);

                fields.Add(field);
            }

            return fields;
        }

        public static List<MethodData> GetMethods(object instance, Type type)
        {
            List<MethodData> methods = new List<MethodData>();

            MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);

            foreach (var item in methodInfos)
            {
                MethodInfo methodInfo = item;

                MethodData method = new MethodData(instance, methodInfo);

                methods.Add(method);
            }

            return methods;
        }
    }

}

