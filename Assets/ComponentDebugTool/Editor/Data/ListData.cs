using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zq.Tool
{
    public class ListData
    {
        public object instance;
        public Type type;
        public string name;
        public event ObjectData.GetValueHandle getValueHandler;
        public event ObjectData.SetValueHandle setValueHandler;

        public IList iList;
        public Type elementType;
        public List<ObjectData> elements = new List<ObjectData>();

        public int Count
        {
            get
            {
                if (iList == null) { return 0; }
                return iList.Count;
            }
        }

        public ListData(object value, Type t, string describe, ObjectData.GetValueHandle getHandler, ObjectData.SetValueHandle setHandler)
        {
            instance = value;
            type = t;
            name = describe;
            getValueHandler = getHandler;
            setValueHandler = setHandler;

            iList = instance as IList;
            elementType = type.GetGenericArguments()[0];
            elements = GetElements();
        }

        public void SetCount(int size)
        {
            if (iList == null)
            {
                instance = Activator.CreateInstance(type);
                SetValue(instance);
            }

            iList.SetCount(size, Activator.CreateInstance(elementType));

            SetValue(instance);
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
            iList = instance as IList;

            if (setValueHandler != null)
            {
                setValueHandler(instance);
            }
        }

        List<ObjectData> GetElements()
        {
            List<ObjectData> list = new List<ObjectData>();

            if (iList == null)
            {
                return list;
            }

            for (int i = 0; i < iList.Count; i++)
            {
                object value = iList[i];

                object index = i;

                ObjectData objectInfo = new ObjectData(value, elementType, elementType.Name,
                   () =>
                   {
                       return iList[(int)index];
                   },
                   (obj) =>
                   {
                       iList[(int)index] = obj;
                   }, true, 0);

                list.Add(objectInfo);
            }
            return list;
        }

        public void RefreshValue()
        {
            instance = GetValue();

            iList = instance as IList;

            elements = GetElements();
        }
    }

}

