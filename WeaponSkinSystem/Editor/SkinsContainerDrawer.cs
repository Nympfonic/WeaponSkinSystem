using Arys.WeaponSkinSystem.Models;
using UnityEditor;
using UnityEngine;

namespace Arys.WeaponSkinSystem.Editor
{
    [CustomPropertyDrawer(typeof(SkinsContainer))]
    public class SkinsContainerDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            // Don't indent child fields
            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            SerializedProperty skinsProperty = property.FindPropertyRelative("skins");

            // Draw
            for (int i = 0; i < skinsProperty.arraySize; i++)
            {
                var skinsRect = new Rect(
                    position.x,
                    position.y + i * 6f * EditorGUIUtility.singleLineHeight + 10f * EditorGUIUtility.standardVerticalSpacing,
                    position.width,
                    5f * EditorGUIUtility.singleLineHeight
                );

                EditorGUI.PropertyField(skinsRect, skinsProperty, GUIContent.none);
            }

            var addSkinButtonRect = new Rect(
                position.x,
                //position.y + EditorGUIUtility.singleLineHeight + skinsProperty.arraySize * 6f * EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing,
                position.y,
                0.2f * position.width,
                EditorGUIUtility.singleLineHeight
            );
            var removeSkinButtonRect = new Rect(
                addSkinButtonRect.x + addSkinButtonRect.width,
                addSkinButtonRect.y,
                0.2f * position.width,
                EditorGUIUtility.singleLineHeight
            );
            
            if (property.isExpanded)
            {
                if (GUI.Button(addSkinButtonRect, "Add Skin"))
                {
                    skinsProperty.arraySize++;
                }

                if (GUI.Button(removeSkinButtonRect, "Remove Skin"))
                {
                    skinsProperty.arraySize--;
                }
            }
            
            // Reset identation
            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            int totalLines = 3;

            SerializedProperty skinsProperty = property.FindPropertyRelative("skins");

            if (property.isExpanded && skinsProperty.arraySize > 0)
            {
                totalLines += skinsProperty.arraySize * 5;
            }

            return EditorGUIUtility.singleLineHeight * totalLines + EditorGUIUtility.standardVerticalSpacing * (totalLines - 1);
        }
    }
}
