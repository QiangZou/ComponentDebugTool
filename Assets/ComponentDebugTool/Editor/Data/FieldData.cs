using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Zq.Tool
{
    public class FieldData
    {
        public object instance;
        public FieldInfo fieldInfo;
        public int level;
        public ObjectData objectinfo;

        public FieldData(object instance, FieldInfo fieldInfo, int index)
        {
            this.instance = instance;
            this.fieldInfo = fieldInfo;
            level = index;

            object value = GetValue();
            objectinfo = new ObjectData(value, fieldInfo.FieldType, fieldInfo.Name, GetValue, SetValue, false, level);
        }

        public object GetValue()
        {
            if (instance == null)
            {
                return null;
            }
            return fieldInfo.GetValue(instance);
        }

        public void SetValue(object obj)
        {
            fieldInfo.SetValue(instance, obj);
        }
    }



}

