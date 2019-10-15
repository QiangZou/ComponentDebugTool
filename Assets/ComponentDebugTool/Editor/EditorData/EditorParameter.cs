using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Zq.Tool
{
    public class EditorParameter
    {
        public ParameterData parameterData;
        public int level = 0;

        public EditorObject editorObjectInfo;

        public EditorParameter(ParameterData data, int indentLevel)
        {
            parameterData = data;
            level = indentLevel;

            EditorInit();
        }

        void EditorInit()
        {
            editorObjectInfo = new EditorObject(parameterData.objectInfo, level, parameterData.name);
        }

        public static void GUI(EditorParameter info)
        {
            EditorObject.GUI(info.editorObjectInfo);
        }
    }

}

