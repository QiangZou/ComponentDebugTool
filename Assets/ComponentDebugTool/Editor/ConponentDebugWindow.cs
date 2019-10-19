using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Zq.Tool
{
    public class ConponentDebugWindow : EditorWindow
    {
        public object instance;
        EditorInstance editorInstance;

        Vector2 scrollPosition = Vector2.zero;
        public ConponentDebugWindow()
        {
            minSize = new Vector2(400,600);
            titleContent = new GUIContent("组件调试窗口");
        }

        void OnGUI()
        {
            EditorGUILayout.ObjectField(instance as UnityEngine.Object, instance.GetType(), true);

            if (editorInstance == null)
            {
                editorInstance = new EditorInstance(instance);
            }

            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            editorInstance.memberFilter = (MemberFilter)EditorGUILayout.EnumPopup("成员过滤", editorInstance.memberFilter);

            editorInstance.accessModifier = (AccessModifier)EditorGUILayout.EnumPopup("修饰符过滤", editorInstance.accessModifier);

            editorInstance.instanceType = (InstanceType)EditorGUILayout.EnumPopup("实例静态过滤", editorInstance.instanceType);

            editorInstance.searchKeyword = EditorGUILayout.TextField("搜索过滤", editorInstance.searchKeyword);

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            EditorClass.GUI(editorInstance.info, editorInstance.memberFilter, editorInstance.accessModifier, editorInstance.instanceType, editorInstance.searchKeyword.ToLower());
            
            EditorGUILayout.EndScrollView();
        }
    }
}
