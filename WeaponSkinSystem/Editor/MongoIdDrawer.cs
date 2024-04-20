using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace Arys.WeaponSkinSystem.Editor
{
    [CustomPropertyDrawer(typeof(MongoIdAttribute))]
    public class MongoIdDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType == SerializedPropertyType.String)
            {
                EditorGUI.BeginChangeCheck();
                EditorGUI.PropertyField(position, property, GUIContent.none);
                if (EditorGUI.EndChangeCheck())
                {
                    property.stringValue = SanitiseString(property.stringValue);
                }
            }
        }

        private string SanitiseString(string str)
        {
            str = str.Trim();

            if (str.Length > 24)
            {
                str = str.Substring(0, 24);
            }

            var regexp = new Regex("^[a-fA-F0-9]*$");
            if (!regexp.IsMatch(str))
            {
                return MongoIdAttribute.ERROR_PLACEHOLDER;
            }

            return str;
        }
    }
}
