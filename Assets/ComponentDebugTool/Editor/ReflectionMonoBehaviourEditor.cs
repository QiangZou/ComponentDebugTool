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

        EditorInstance editorInstance;

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

            if (editorInstance == null)
            {
                editorInstance = new EditorInstance(instance.target);
            }
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Refresh();

            if (editorInstance == null)
            {
                return;
            }

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            editorInstance.memberFilter = (MemberFilter)EditorGUILayout.EnumPopup("成员过滤", editorInstance.memberFilter);

            editorInstance.accessModifier = (AccessModifier)EditorGUILayout.EnumPopup("修饰符过滤", editorInstance.accessModifier);

            editorInstance.instanceType = (InstanceType)EditorGUILayout.EnumPopup("实例静态过滤", editorInstance.instanceType);

            editorInstance.isGet = EditorGUILayout.Toggle("Get", editorInstance.isGet);
            editorInstance.isSet = EditorGUILayout.Toggle("Set", editorInstance.isSet);

            editorInstance.searchKeyword = EditorGUILayout.TextField("搜索过滤", editorInstance.searchKeyword);

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            EditorClass.GUI(editorInstance.info, editorInstance.searchKeyword.ToLower(), editorInstance.memberFilter, editorInstance.accessModifier, editorInstance.instanceType, editorInstance.isGet, editorInstance.isSet);
        }
    }
}

