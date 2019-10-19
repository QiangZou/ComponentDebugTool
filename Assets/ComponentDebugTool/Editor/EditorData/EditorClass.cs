using System;
using System.Collections.Generic;
using UnityEditor;

namespace Zq.Tool
{
    public class EditorClass
    {
        public ClassData classInfo;

        public int level = -1;
        public bool isFold = true;
        public string name = string.Empty;
        public List<EditorField> editorFields = new List<EditorField>();
        public List<EditorMethod> editorMethods = new List<EditorMethod>();

        public EditorClass(ClassData info, int indentLevel, bool fold, string describe)
        {
            classInfo = info;
            level = indentLevel;
            isFold = fold;
            name = describe;
        }

        public EditorClass(object obj, Type t, int indentLevel, bool fold, string describe)
        {
            classInfo = new ClassData(obj, t, 0);
            level = indentLevel;
            isFold = fold;
            name = describe;
        }

        public void RefreshValue(ClassData info)
        {
            classInfo = info;
        }

        public void GetEditorField()
        {
            classInfo.GetField();

            for (int i = 0; i < classInfo.fields.Count; i++)
            {
                FieldData Field = classInfo.fields[i];

                EditorField editorField = new EditorField(Field, level + 1);

                editorFields.Add(editorField);
            }
        }

        public void GetEditorMethod()
        {
            classInfo.GetMethod();

            for (int i = 0; i < classInfo.methods.Count; i++)
            {
                MethodData method = classInfo.methods[i];

                EditorMethod editorMethod = new EditorMethod(method, level + 1);

                editorMethods.Add(editorMethod);
            }
        }

        public static void GUI(EditorClass info, MemberFilter memberFilter = MemberFilter.All, AccessModifier accessModifier = AccessModifier.All, InstanceType instanceType = InstanceType.Instance, string searchKeyword = "")
        {
            EditorGUI.indentLevel = info.level;

            if (info.level != -1)
            {
                info.isFold = EditorGUILayout.Foldout(info.isFold, info.name);
            }

            if (info.isFold)
            {
                if (memberFilter == MemberFilter.All || memberFilter == MemberFilter.Fields)
                {
                    for (int i = 0; i < info.editorFields.Count; i++)
                    {
                        EditorField editorField = info.editorFields[i];

                        EditorField.GUI(editorField, accessModifier, instanceType, searchKeyword);
                    }
                }

                if (memberFilter == MemberFilter.All || memberFilter == MemberFilter.Methods)
                {
                    for (int i = 0; i < info.editorMethods.Count; i++)
                    {
                        EditorMethod editorMethod = info.editorMethods[i];

                        EditorMethod.GUI(editorMethod, accessModifier, instanceType, searchKeyword);
                    }
                }
            }
        }
    }

}

