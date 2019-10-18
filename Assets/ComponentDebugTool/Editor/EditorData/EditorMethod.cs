using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace Zq.Tool
{
    public class EditorMethod
    {
        public MethodData methodData;
        public int level = 0;
        public List<EditorParameter> editorParameters = new List<EditorParameter>();

        public EditorMethod(MethodData data, int indentLevel)
        {
            methodData = data;
            level = indentLevel;

            EditorInit();
        }

        void EditorInit()
        {
            for (int i = 0; i < methodData.parameters.Count; i++)
            {
                ParameterData parameter = methodData.parameters[i];

                EditorParameter editorParameter = new EditorParameter(parameter, level);

                editorParameters.Add(editorParameter);
            }
        }

        public static void GUI(EditorMethod editorMethod, AccessModifier accessModifier = AccessModifier.All, string searchKeyword = "")
        {
            if (accessModifier != AccessModifier.All && editorMethod.methodData.accessModifier != accessModifier)
            {
                return;
            }

            if (searchKeyword != string.Empty && editorMethod.methodData.name.ToLower().Contains(searchKeyword) == false)
            {
                return;
            }

            for (int i = 0; i < editorMethod.editorParameters.Count; i++)
            {
                EditorParameter editorParameter = editorMethod.editorParameters[i];

                EditorParameter.GUI(editorParameter);
            }

            if (GUILayout.Button(editorMethod.methodData.name))
            {
                editorMethod.methodData.methodInfo.Invoke(editorMethod.methodData.instance, editorMethod.methodData.GetParameters());
            }
        }
    }

}

