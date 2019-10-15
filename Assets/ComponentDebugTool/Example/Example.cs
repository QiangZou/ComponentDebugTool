using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Zq.Tool
{
    public enum 自定义枚举
    {
        枚举0,
        枚举1,
        枚举2,
        枚举3,
        枚举4,
    }

    [Serializable]
    public class Data
    {
        public int int类型;
        public string string类型;

        public override string ToString()
        {
            return "int类型 : " + int类型.ToString() + " string类型 : " + string类型;
        }
    }

    [Serializable]
    public class Data1
    {
        public int int类型;
        public string string类型;
        public Data data自定义类型;
    }

    public class Example : MonoBehaviour
    {
        static bool 静态bool类型;
        public int int类型;
        string 私有string类型;
        float float类型;
        double double类型;
        long long类型;
        sbyte sbyte类型;
        short short类型;
        byte byte类型;
        ushort ushort类型;
        uint uint类型;
        ulong ulong类型;
        char char类型;
        decimal decimal类型;

        自定义枚举 enum类型;

        public GameObject GameObject类型;
        Transform Transform类型;
        Color color类型;
        Vector2 Vector2类型;
        Vector3 Vector3类型;
        Vector4 Vector4类型;

        public Data Data自定义类型;
        Data1 Data1镶嵌自定义类型;


        public int[] int数组类型;
        string[] string数组类型;
        Data[] Data自定义数组类型;

        public List<int> List_int类型;
        List<string> List_string类型;
        List<Data> List_Data自定义列表类型;


        public void public无参数函数()
        {
            Debug.LogError("调用 public无参数函数()");
        }

        private void private无参数函数()
        {
            Debug.LogError("调用 private有参数函数()");
        }

        void 简单参数类型函数(int int类型)
        {
            Debug.LogError("调用 有参数函数() 参数类型 : int类型 值 : " + int类型.ToString());
        }

        void 自定义参数类型函数(Data Data自定义类型)
        {
            Debug.LogError("调用 自定义参数类型函数() 参数类型 : Data自定义类型 值 : " + Data自定义类型.ToString());
        }

        void 多参数函数(int int类型, string string类型)
        {
            Debug.LogError(string.Format("调用 多参数函数() 参数0 : {0} 参数1 : {1}", int类型.ToString(), string类型));
        }
    }
}


