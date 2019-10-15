using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Zq.Tool
{
    public class EditorArray
    {
        public ArrayData arrayData;

        public bool isFold = false;
        public int level = 0;
        public Dictionary<int, EditorObject> editorElements = new Dictionary<int, EditorObject>();

        public EditorArray(ArrayData data, int indentLevel)
        {
            arrayData = data;
            level = indentLevel;

            RefreshValue();
        }

        public void RefreshValue(ArrayData data)
        {
            arrayData = data;
        }

        public void RefreshValue()
        {
            arrayData.RefreshValue();

            for (int i = 0; i < arrayData.elements.Count; i++)
            {
                ObjectData objectData = arrayData.elements[i];

                EditorObject editorObjectInfo = null;

                if (editorElements.TryGetValue(i, out editorObjectInfo) == false)
                {
                    editorObjectInfo = new EditorObject(objectData, level, i.ToString());
                    editorElements.Add(i, editorObjectInfo);
                }
                else
                {
                    editorObjectInfo.RefreshValue(objectData, level, i.ToString());
                }
            }
        }

        public static void GUI(EditorArray info)
        {
            EditorGUI.indentLevel = info.level;

            info.isFold = EditorGUILayout.Foldout(info.isFold, info.arrayData.name);
            if (info.isFold == false)
            {
                return;
            }

            bool isChange = false;

            int size = info.arrayData.Count;

            InputTool.InputInt("Size", ref size, ref isChange);
            if (isChange)
            {
                info.arrayData.SetCount(size);
            }

            info.RefreshValue();

            for (int i = 0; i < size; i++)
            {
                EditorObject.GUI(info.editorElements[i]);
            }
        }
    }

}

