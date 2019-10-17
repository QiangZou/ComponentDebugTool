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

        AccessModifier accessModifier = AccessModifier.All;

        void OnEnable()
        {
            Refresh();
        }

        void Refresh()
        {
            if (target == null)
            {
                return;
            }

            if (instance == null)
            {
                instance = target as ReflectionMonoBehaviour;
            }

            if (info == null)
            {
                info = new EditorClass(instance.target, instance.target.GetType(), 0, true, instance.target.GetType().Name);
                info.GetEditorField();
                info.GetEditorMethod();
            }
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Refresh();

            if (info == null)
            {
                return;
            }

            accessModifier = (AccessModifier)EditorGUILayout.EnumPopup("访问修饰符", accessModifier);

            EditorClass.GUI(info, accessModifier);
        }

    }
}

