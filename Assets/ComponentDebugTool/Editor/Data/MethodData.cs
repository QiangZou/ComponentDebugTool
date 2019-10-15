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
        public List<ParameterData> parameters = new List<ParameterData>();

        public MethodData(object instance, MethodInfo methodInfo)
        {
            this.instance = instance;
            this.methodInfo = methodInfo;
            name = methodInfo.Name;

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

