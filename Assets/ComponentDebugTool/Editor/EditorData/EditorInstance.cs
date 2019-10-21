using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zq.Tool
{
    public class EditorInstance
    {
        public EditorClass info;

        public MemberFilter memberFilter = MemberFilter.All;
        public AccessModifier accessModifier = AccessModifier.All;
        public InstanceType instanceType = InstanceType.Instance;
        public bool isGet = false;
        public bool isSet = true;

        public string searchKeyword = string.Empty;

        public EditorInstance(object context)
        {
            info = new EditorClass(context, context.GetType(), -1, true, context.GetType().Name);
            info.GetEditorField();
            info.GetEditorMethod();
        }
    }
}
