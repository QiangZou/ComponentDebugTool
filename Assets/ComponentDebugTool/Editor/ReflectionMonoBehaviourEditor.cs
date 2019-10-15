using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace Zq.Tool
{
    [CustomEditor(typeof(ReflectionMonoBehaviour))]
    public class ReflectionMonoBehaviourEditor : Editor
    {
        ReflectionMonoBehaviour instance;

        EditorClass info;

        void OnEnable()
        {
            if (instance == null)
            {
                instance = target as ReflectionMonoBehaviour;

                info = new EditorClass(instance.target, instance.target.GetType(), 0, true, instance.target.GetType().Name);
                info.GetEditorField();
                info.GetEditorMethod();
            }
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();


            if (instance == null)
            {
                return;
            }

            if (instance.target == null)
            {
                return;
            }

            if (info == null)
            {
                info = new EditorClass(instance.target, instance.target.GetType(), 0, true, instance.target.GetType().Name);
            }

            EditorClass.GUI(info);
        }

    }
}

