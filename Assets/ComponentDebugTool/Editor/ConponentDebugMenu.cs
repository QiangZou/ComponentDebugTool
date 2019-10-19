using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Zq.Tool
{
    public class ConponentDebugMenu : EditorWindow
    {
        [MenuItem("CONTEXT/Component/调试")]
        private static void ReflectionMonoBehaviourInspector(MenuCommand command)
        {
            Object context = command.context;

            Component target = context as Component;

            ReflectionMonoBehaviour reflectionMonoBehaviour = target.gameObject.AddComponent<ReflectionMonoBehaviour>();

            reflectionMonoBehaviour.target = target;
        }

        [MenuItem("CONTEXT/Component/调试（窗口模式）")]
        private static void ReflectionMonoBehaviourWindow(MenuCommand command)
        {
            ConponentDebugWindow window = GetWindow<ConponentDebugWindow>();
            window.instance = command.context;
        }
    }

}

