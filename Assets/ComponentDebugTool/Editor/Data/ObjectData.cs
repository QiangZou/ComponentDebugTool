using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Zq.Tool
{
    public class ObjectData
    {
        public delegate object GetValueHandle();
        public delegate void SetValueHandle(object value);


        public object value;
        public Type type;
        public string name;
        public event GetValueHandle getValueHandler;
        public event SetValueHandle setValueHandler;
        public int level;

        public object originalValue;//源数据   引用类型不行  会被修改

        public ListData listData;
        public ArrayData arrayData;
        public ClassData classData;

        public ObjectData(object value, Type type, string name, GetValueHandle getValueHandler, SetValueHandle setValueHandler, bool isInit, int index)
        {
            this.value = value;
            this.type = type;
            this.name = name;
            this.getValueHandler = getValueHandler;
            this.setValueHandler = setValueHandler;
            level = index;

            originalValue = value;

            if (isInit)
            {
                Init();
            }

            //支持类型
            if (TypeTool.IsSupported(type))
            {
                return;
            }

            //定制化类型
            if (type.IsArray && type.GetArrayRank() == 1)
            {
                arrayData = new ArrayData(this.value, this.type, this.name, this.getValueHandler, this.setValueHandler);
                return;
            }
            if (TypeTool.IsList(type))
            {
                listData = new ListData(this.value, this.type, this.name, this.getValueHandler, this.setValueHandler);
                return;
            }

            //不进一步解析Unity自带类型
            if (type.Namespace != null && type.Namespace.Contains("UnityEngine"))
            {
                return;
            }

            if (type.IsArray)
            {
                //不解析非一维数组
            }
            else if (TypeTool.IsDictionary(type))
            {
                //不解析字典
            }
            else if (type == typeof(object))
            {
                //不解析object
            }
            else
            {
                //最多迭代10层
                if (level >= 10)
                {
                    return;
                }

                //Debug.LogError(name);
                //Debug.LogError(type.Name);
                classData = new ClassData(this.value, this.type, level + 1);
            }

        }

        public void Init()
        {
            value = CreateInstanceTool.Create(type);

            SetValue(value);
        }

        public object GetValue()
        {
            if (getValueHandler != null)
            {
                value = getValueHandler.Invoke();
            }

            return value;
        }

        public void SetValue(object obj)
        {
            value = obj;

            if (setValueHandler != null)
            {
                setValueHandler(value);
            }
        }
    }

}

