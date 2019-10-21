using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Zq.Tool
{
    public class EditorField
    {
        FieldData fieldData;

        public int level = 0;
        public bool isFold = true;
        public string name;
        public string typeName;
        public EditorObject editorObjectInfo;

        public EditorField(FieldData info, int indentLevel)
        {
            fieldData = info;
            level = indentLevel;

            EditorInit();
        }

        void EditorInit()
        {
            name = fieldData.fieldInfo.Name;
            typeName = fieldData.fieldInfo.FieldType.ToString();

            editorObjectInfo = new EditorObject(fieldData.objectinfo, level, name);
        }

        public static void GUI(EditorField info, string searchKeyword = "", AccessModifier accessModifier = AccessModifier.All, InstanceType instanceType = InstanceType.Instance)
        {
            //info.fieldData.RefreshValue();//重要 字段初始化有可能未空 没有引用
            if (accessModifier != AccessModifier.All && info.fieldData.accessModifier != accessModifier)
            {
                return;
            }

            if (instanceType != InstanceType.All && info.fieldData.instanceType != instanceType)
            {
                return;
            }

            if (searchKeyword != string.Empty && info.name.ToLower().Contains(searchKeyword) == false)
            {
                return;
            }



            EditorObject.GUI(info.editorObjectInfo);
        }
    }

}

