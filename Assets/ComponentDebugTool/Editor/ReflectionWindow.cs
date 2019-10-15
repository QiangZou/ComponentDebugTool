using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Zq.Tool
{
    public class ReflectionWindow : EditorWindow
    {
        [MenuItem("CONTEXT/Component/反射")]
        private static void NewOpenForRigidBody(MenuCommand command)
        {
            Object context = command.context;

            Component target = context as Component;

            ReflectionMonoBehaviour reflectionMonoBehaviour = target.gameObject.AddComponent<ReflectionMonoBehaviour>();

            reflectionMonoBehaviour.target = target;
        }
    }

}

