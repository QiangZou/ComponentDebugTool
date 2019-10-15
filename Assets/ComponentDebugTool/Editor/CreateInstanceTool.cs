using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

namespace Zq.Tool
{
    public static class CreateInstanceTool
    {
        public static object Create(Type type)
        {
            object instance = null;

            if (TypeTool.IsCreateInstance(type) == false)
            {
                return instance;
            }

            instance = CreateCustomType(type);

            if (instance != null)
            {
                return instance;
            }

            if (type.IsValueType == true)//如果是值类型 结构体
            {
                instance = Activator.CreateInstance(type, true);

                return instance;
            }

            if (IsNoArgumentsConstructor(type) == true)
            {
                instance = Activator.CreateInstance(type, true);

                return instance;
            }

            ConstructorInfo constructorInfo = GetMinConstructor(type);

            ParameterInfo[] parameterInfos = constructorInfo.GetParameters();

            object[] parameters = new object[parameterInfos.Length];

            for (int i = 0; i < parameterInfos.Length; i++)
            {
                parameters[i] = Create(parameterInfos[i].ParameterType);
            }

            instance = constructorInfo.Invoke(parameters);

            if (instance == null)
            {
                Debug.LogError("创建实例失败 ：" + type.ToString());
            }

            return instance;
        }



        public static object CreateCustomType(Type type)
        {
            if (type == typeof(string))
            {
                return "字符串";
            }

            return null;
        }

        public static bool IsNoArgumentsConstructor(Type type)
        {
            ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);//| BindingFlags.Static

            for (int i = 0; i < constructors.Length; i++)
            {
                ConstructorInfo constructorInfo = constructors[i];
                ParameterInfo[] parameters = constructorInfo.GetParameters();
                if (parameters.Length == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static ConstructorInfo GetMinConstructor(Type type)
        {
            int number = -1;
            int index = 0;

            ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            for (int i = 0; i < constructors.Length; i++)
            {
                ConstructorInfo constructorInfo = constructors[i];
                ParameterInfo[] Parameters = constructorInfo.GetParameters();
                if (Parameters.Length > number)
                {
                    index = i;
                }
            }

            return constructors[index];
        }
    }

}

