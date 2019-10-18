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

        MemberFilter memberFilter = MemberFilter.All;
        AccessModifier accessModifier = AccessModifier.All;

        string searchKeyword = string.Empty;

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

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            memberFilter = (MemberFilter)EditorGUILayout.EnumPopup("成员过滤", memberFilter);

            accessModifier = (AccessModifier)EditorGUILayout.EnumPopup("修饰符过滤", accessModifier);

            searchKeyword = EditorGUILayout.TextField("搜索过滤", searchKeyword);

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            EditorClass.GUI(info, memberFilter, accessModifier, searchKeyword.ToLower());
        }
    }
}

