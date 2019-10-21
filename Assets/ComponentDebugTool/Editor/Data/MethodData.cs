using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Zq.Tool
{
    public class MethodData
    {
        public object instance;
        public MethodInfo methodInfo;
        public string name = string.Empty;
        public AccessModifier accessModifier = AccessModifier.None;
        public InstanceType instanceType = InstanceType.None;
        public bool isGet = false;
        public bool isSet = false;
        public List<ParameterData> parameters = new List<ParameterData>();

        public MethodData(object instance, MethodInfo methodInfo)
        {
            this.instance = instance;
            this.methodInfo = methodInfo;
            name = methodInfo.Name;

            if (this.methodInfo.IsPublic)
            {
                accessModifier = AccessModifier.Public;
            }
            else if (this.methodInfo.IsPrivate)
            {
                accessModifier = AccessModifier.Private;
            }

            if (this.methodInfo.IsStatic)
            {
                instanceType = InstanceType.Static;
            }
            else
            {
                instanceType = InstanceType.Instance;
            }

            if (name.StartsWith("get_"))
            {
                isGet = true;
            }

            if (name.StartsWith("set_"))
            {
                isSet = true;
            }

            ParameterInfo[] parameters = methodInfo.GetParameters();
            foreach (var item in parameters)
            {
                ParameterData parameter = new ParameterData(item);
                this.parameters.Add(parameter);
            }
        }

        public object[] GetParameters()
        {
            List<object> value = new List<object>();

            for (int i = 0; i < parameters.Count; i++)
            {
                value.Add(parameters[i].value);
            }

            return value.ToArray();
        }
    }

}

