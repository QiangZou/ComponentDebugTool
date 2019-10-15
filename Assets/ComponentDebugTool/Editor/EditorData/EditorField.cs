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

        public static void GUI(EditorField info)
        {
            //info.fieldData.RefreshValue();//重要 字段初始化有可能未空 没有引用
            EditorObject.GUI(info.editorObjectInfo);
        }
    }

}

