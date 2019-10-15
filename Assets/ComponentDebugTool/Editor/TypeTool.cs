using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zq.Tool
{
    public static class TypeTool
    {
        static List<Type> typeList = new List<Type>()
        {
            //值类型
            typeof(sbyte),
            typeof(byte),
            typeof(short),
            typeof(ushort),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(float),
            typeof(double),
            typeof(decimal),
            typeof(char),
            typeof(bool),

            typeof(string),

            typeof(Vector2),
            typeof(Vector3),
            typeof(Vector4),
            typeof(Color),
        };

        public static bool IsSupported(Type type)
        {
            for (int i = 0; i < typeList.Count; i++)
            {
                if (type == typeList[i])
                {
                    return true;
                }
            }

            if (type.IsEnum)
            {
                return true;
            }

            if (type == typeof(GameObject))
            {
                return true;
            }

            if (IsComponent(type))
            {
                return true;
            }

            return false;
        }

        public static bool IsCreateInstance(Type type)
        {
            for (int i = 0; i < typeList.Count; i++)
            {
                if (type == typeList[i])
                {
                    return true;
                }
            }

            if (type.IsEnum)
            {
                return true;
            }

            return false;
        }

        public static bool IsList(Type type)
        {
            if (type.IsGenericType == false)
            {
                return false;
            }
            for (int i = 0; i < type.GetInterfaces().Length; i++)
            {
                Type interfaces = type.GetInterfaces()[i];

                if (interfaces == typeof(IList))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsDictionary(Type type)
        {
            for (int i = 0; i < type.GetInterfaces().Length; i++)
            {
                Type interfaces = type.GetInterfaces()[i];

                if (interfaces == typeof(IDictionary))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsComponent(Type type)
        {
            if (type.BaseType == null)
            {
                return false;
            }

            if (type.BaseType == typeof(Component))
            {
                return true;
            }

            return IsComponent(type.BaseType);
        }
    }

}
