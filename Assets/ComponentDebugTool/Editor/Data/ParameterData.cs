using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Zq.Tool
{
    public class ParameterData
    {
        public ParameterInfo parameterInfo;
        public string name = string.Empty;
        public Type type;
        public object value;
        public ObjectData objectInfo;

        public ParameterData(ParameterInfo parameterInfo)
        {
            this.parameterInfo = parameterInfo;

            name = parameterInfo.Name;
            type = parameterInfo.ParameterType;
            objectInfo = new ObjectData(value, type, name, GetValue, SetValue, true, 0);
        }

        public object GetValue()
        {
            return value;
        }

        public void SetValue(object obj)
        {
            value = obj;
        }
    }
}

