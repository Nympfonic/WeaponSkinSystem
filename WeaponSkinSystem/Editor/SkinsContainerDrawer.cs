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

            SerializedProperty skinsProperty = property.FindPropertyRelative("skins");

            var skinsRect = new Rect(
                position.x,
                position.y,
                position.width,
                position.height
            );

            EditorGUI.PropertyField(skinsRect, skinsProperty, GUIContent.none);

            EditorGUI.EndProperty();
        }
    }
}
