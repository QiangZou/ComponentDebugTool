using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

namespace Zq.Tool
{
    public class EditorObject
    {
        public ObjectData objectData;

        public int level = 0;
        public string name;
        public bool isFold = false;

        public EditorList editorList;
        public EditorArray editorArray;
        public EditorClass editorClass;


        public EditorObject(ObjectData data, int indentLevel, string describe)
        {
            RefreshValue(data, indentLevel, describe);
        }

        public void RefreshValue(ObjectData data, int indentLevel, string describe)
        {
            objectData = data;
            name = describe;
            level = indentLevel;

            RefreshValue();
        }

        void RefreshValue()
        {
            if (objectData.listData != null)
            {
                if (editorList == null)
                {
                    editorList = new EditorList(objectData.listData, level + 1);
                }
                else
                {
                    editorList.RefreshValue(objectData.listData);
                }
            }
            else if (objectData.arrayData != null)
            {
                if (editorArray == null)
                {
                    editorArray = new EditorArray(objectData.arrayData, level + 1);
                }
                else
                {
                    editorArray.RefreshValue(objectData.arrayData);
                }
            }
            else if (objectData.classData != null)
            {
                if (editorClass == null)
                {
                    editorClass = new EditorClass(objectData.classData, level + 1, false, name);
                    editorClass.GetEditorField();
                }
                else
                {
                    editorClass.RefreshValue(objectData.classData);
                }
            }
        }

        public static void GUI(EditorObject info)
        {
            EditorGUI.indentLevel = info.level;

            if (info.editorList != null)
            {
                EditorList.GUI(info.editorList);
            }
            else if (info.editorArray != null)
            {
                EditorArray.GUI(info.editorArray);
            }
            else if (info.editorClass != null)
            {
                EditorClass.GUI(info.editorClass);
            }
            else
            {
                object value = info.objectData.GetValue();

                bool isChange = false;

                InputTool.Input(info.objectData.type, info.name, ref value, ref isChange);

                if (isChange)
                {
                    info.objectData.SetValue(value);
                }
            }

        }
    }

}

