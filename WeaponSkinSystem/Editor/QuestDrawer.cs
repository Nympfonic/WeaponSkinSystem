using Arys.WeaponSkinSystem.Models;
using UnityEditor;
using UnityEngine;

namespace Arys.WeaponSkinSystem.Editor
{
    [CustomPropertyDrawer(typeof(Quest))]
    public class QuestDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            SerializedProperty idProperty = property.FindPropertyRelative("id");

            var idRect = new Rect(
                position.x,
                position.y,
                position.width,
                EditorGUIUtility.singleLineHeight
            );

            EditorGUI.PropertyField(idRect, idProperty, GUIContent.none);

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
        }
    }
}
