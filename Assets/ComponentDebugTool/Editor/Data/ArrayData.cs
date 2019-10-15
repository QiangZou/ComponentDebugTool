using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zq.Tool
{
    public class ArrayData
    {
        public object instance;
        public Type type;
        public string name;
        public event ObjectData.GetValueHandle getValueHandler;
        public event ObjectData.SetValueHandle setValueHandler;

        public Array array;
        public Type elementType;
        public List<ObjectData> elements = new List<ObjectData>();

        public int Count
        {
            get
            {
                if (instance == null) { return 0; }
                return array.Length;
            }
        }

        public ArrayData(object value, Type t, string describe, ObjectData.GetValueHandle getHandler, ObjectData.SetValueHandle setHandler)
        {
            instance = value;
            type = t;
            name = describe;
            getValueHandler = getHandler;
            setValueHandler = setHandler;

            array = instance as Array;
            elementType = type.GetElementType();
            elements = GetElements();
        }

        public void SetCount(int size)
        {
            object value = instance;

            if (value == null)
            {
                value = Activator.CreateInstance(type, 0);
            }

            Array newArray = value as Array;

            value = newArray.SetCount(size);

            SetValue(value);
        }

        public object GetValue()
        {
            if (getValueHandler == null)
            {
                return null;
            }
            return getValueHandler.Invoke();
        }

        public void SetValue(object value)
        {
            instance = value;
            array = instance as Array;

            if (setValueHandler != null)
            {
                setValueHandler(instance);
            }
        }

        List<ObjectData> GetElements()
        {
            List<ObjectData> list = new List<ObjectData>();

            if (instance == null)
            {
                return list;
            }

            for (int i = 0; i < array.Length; i++)
            {
                object value = array.GetValue(i);

                object index = i;//重要

                ObjectData objectInfo = new ObjectData(value, elementType, elementType.Name,
                    () =>
                    {
                        return array.GetValue((int)index);
                    },
                    (go) =>
                    {
                        array.SetValue(go, (int)index);

                        SetValue(array);
                    }, true, 0);

                list.Add(objectInfo);
            }
            return list;
        }

        public void RefreshValue()
        {
            instance = GetValue();

            array = instance as Array;

            elements = GetElements();
        }




    }

}

