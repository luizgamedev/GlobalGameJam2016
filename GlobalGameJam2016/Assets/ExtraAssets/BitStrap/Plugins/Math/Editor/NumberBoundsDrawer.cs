using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace BitStrap
{
    [CustomPropertyDrawer( typeof( IntBounds ) )]
    [CustomPropertyDrawer( typeof( FloatBounds ) )]
    public class NumberBoundsDrawer : PropertyDrawer
    {
        public override void OnGUI( Rect position, SerializedProperty property, GUIContent label )
        {
            // Unity bugada.. hacks :(
            if( !property.type.EndsWith( "Bounds" ) )
                return;

            Rect labelPosition = new Rect( position );
            Rect minPosition = new Rect( position );
            Rect maxPosition = new Rect( position );

            labelPosition.width = EditorGUIUtility.labelWidth;
            minPosition.x = labelPosition.xMax;
            minPosition.width = ( minPosition.width - labelPosition.width ) * 0.5f;
            maxPosition.x = labelPosition.xMax + minPosition.width;
            maxPosition.width = minPosition.width;

            EditorGUI.LabelField( labelPosition, label );

            SerializedProperty max = property.FindPropertyRelative( "max" );
            SerializedProperty min = property.FindPropertyRelative( "min" );

            float originalLabelWidth = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = 32.0f;
            int originalIndentLevel = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            EditorGUI.BeginChangeCheck();
            EditorGUI.PropertyField( minPosition, min );
            EditorGUI.PropertyField( maxPosition, max );
            if( EditorGUI.EndChangeCheck() )
            {
                min.serializedObject.ApplyModifiedProperties();
                max.serializedObject.ApplyModifiedProperties();

                GetValue( property ).Validate();

                min.serializedObject.Update();
                max.serializedObject.Update();
            }

            EditorGUIUtility.labelWidth = originalLabelWidth;
            EditorGUI.indentLevel = originalIndentLevel;
        }

        private IValidatable GetValue( SerializedProperty property )
        {
            object instance = property.serializedObject.targetObject;

            if( property.depth > 0 )
            {
                string[] elements = property.propertyPath.Split( '.' );
                foreach( string element in elements.Take( property.depth ) )
                {
                    instance = GetInstance( instance, element );
                }
            }

            return fieldInfo.GetValue( instance ) as IValidatable;
        }

        private object GetInstance( object source, string fieldName )
        {
            if( source == null )
                return null;

            System.Type type = source.GetType();
            FieldInfo field = type.GetField( fieldName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance );

            if( field == null )
                return null;

            return field.GetValue( source );
        }
    }
}
