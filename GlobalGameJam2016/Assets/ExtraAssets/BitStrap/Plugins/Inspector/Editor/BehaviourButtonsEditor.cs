using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace BitStrap
{
    [CustomEditor( typeof( MonoBehaviour ), true, isFallback = true )]
    [CanEditMultipleObjects]
    public class BehaviourButtonsEditor : Editor
    {
        private static object[] emptyParamList = new object[0];

        private IList<MethodInfo> methods = new List<MethodInfo>();

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if( methods.Count > 0 )
            {
                EditorGUILayout.HelpBox( "Click to execute methods!", MessageType.None );
                ShowMethodButtons();
            }
        }

        private void OnEnable()
        {
            methods = target.GetType().GetMethods( BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance ).Where( m =>
                m.GetCustomAttributes( typeof( ButtonAttribute ), false ).Length == 1 &&
                m.GetParameters().Length == 0 &&
                !m.ContainsGenericParameters
            ).ToList();
        }

        private void ShowMethodButtons()
        {
            foreach( MethodInfo method in methods )
            {
                if( GUILayout.Button( method.Name ) )
                {
                    method.Invoke( target, emptyParamList );
                }
            }
        }
    }
}
