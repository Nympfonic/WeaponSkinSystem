using Arys.WeaponSkinSystem.Models;
using UnityEditor;
using UnityEngine;

namespace Arys.WeaponSkinSystem.Editor
{
    [CustomPropertyDrawer(typeof(Skin))]
    public class SkinDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            int row = 1;
            float horizontalSpacing = 10f * EditorGUIUtility.standardVerticalSpacing;

            // Calculate rects
            // Row 1
            var modderNoteLabelRect = new Rect(
                position.x,
                position.y + 10f * EditorGUIUtility.standardVerticalSpacing,
                0.3f * position.width,
                EditorGUIUtility.singleLineHeight
            );
            var modderNoteRect = new Rect(
                modderNoteLabelRect.x + modderNoteLabelRect.width,
                modderNoteLabelRect.y,
                0.55f * position.width,
                EditorGUIUtility.singleLineHeight
            );

            // Row 2
            var itemIdLabelRect = new Rect(
                position.x,
                position.y + row * EditorGUIUtility.singleLineHeight + (10f + row * 4f) * EditorGUIUtility.standardVerticalSpacing,
                0.1f * position.width,
                EditorGUIUtility.singleLineHeight
            );
            var itemIdRect = new Rect(
                itemIdLabelRect.x + itemIdLabelRect.width,
                itemIdLabelRect.y,
                0.3f * position.width,
                EditorGUIUtility.singleLineHeight
            );
            var skinTextureLabelRect = new Rect(
                itemIdRect.x + itemIdRect.width + horizontalSpacing,
                itemIdRect.y,
                0.15f * position.width,
                EditorGUIUtility.singleLineHeight
            );
            var skinTextureRect = new Rect(
                skinTextureLabelRect.x + skinTextureLabelRect.width,
                skinTextureLabelRect.y,
                0.27f * position.width,
                EditorGUIUtility.singleLineHeight
            );
            row++;

            // Row 3
            var isLockedBehindPrerequisiteLabelRect = new Rect(
                position.x,
                position.y + row * EditorGUIUtility.singleLineHeight + (10f + row * 4f) * EditorGUIUtility.standardVerticalSpacing,
                0.3f * position.width,
                EditorGUIUtility.singleLineHeight
            );
            var isLockedBehindPrerequisiteRect = new Rect(
                isLockedBehindPrerequisiteLabelRect.x + isLockedBehindPrerequisiteLabelRect.width,
                isLockedBehindPrerequisiteLabelRect.y,
                0.1f * position.width,
                EditorGUIUtility.singleLineHeight
            );
            row++;

            // Row 4
            var mustBeLevelLabelRect = new Rect(
                position.x,
                position.y + row * EditorGUIUtility.singleLineHeight + (10f + row * 4f) * EditorGUIUtility.standardVerticalSpacing,
                0.25f * position.width,
                EditorGUIUtility.singleLineHeight
            );
            var mustBeLevelRect = new Rect(
                mustBeLevelLabelRect.x + mustBeLevelLabelRect.width,
                mustBeLevelLabelRect.y,
                0.1f * position.width,
                EditorGUIUtility.singleLineHeight
            );
            var levelRequirementLabelRect = new Rect(
                mustBeLevelRect.x + mustBeLevelRect.width,
                mustBeLevelRect.y,
                0.2f * position.width,
                EditorGUIUtility.singleLineHeight
            );
            var levelRequirementRect = new Rect(
                levelRequirementLabelRect.x + levelRequirementLabelRect.width,
                levelRequirementLabelRect.y,
                0.3f * position.width,
                EditorGUIUtility.singleLineHeight
            );
            row++;

            // Row 5
            var mustBeLoyaltyLevelWithTraderLabelRect = new Rect(
                position.x,
                position.y + row * EditorGUIUtility.singleLineHeight + (10f + row * 4f) * EditorGUIUtility.standardVerticalSpacing,
                0.25f * position.width,
                EditorGUIUtility.singleLineHeight
            );
            var mustBeLoyaltyLevelWithTraderRect = new Rect(
                mustBeLoyaltyLevelWithTraderLabelRect.x + mustBeLoyaltyLevelWithTraderLabelRect.width,
                mustBeLoyaltyLevelWithTraderLabelRect.y,
                0.1f * position.width,
                EditorGUIUtility.singleLineHeight
            );
            var loyaltyLevelRequirementLabelRect = new Rect(
                mustBeLoyaltyLevelWithTraderRect.x + mustBeLoyaltyLevelWithTraderRect.width,
                mustBeLoyaltyLevelWithTraderRect.y,
                0.2f * position.width,
                EditorGUIUtility.singleLineHeight
            );
            var loyaltyLevelRequirementRect = new Rect(
                loyaltyLevelRequirementLabelRect.x + loyaltyLevelRequirementLabelRect.width,
                loyaltyLevelRequirementLabelRect.y,
                0.3f * position.width,
                EditorGUIUtility.singleLineHeight
            );
            row++;

            // Row 6 (Trader extended)
            var traderIdLabelRect = new Rect(
                mustBeLoyaltyLevelWithTraderRect.x + mustBeLoyaltyLevelWithTraderRect.width,
                position.y + row * EditorGUIUtility.singleLineHeight + (10f + row * 4f) * EditorGUIUtility.standardVerticalSpacing,
                0.2f * position.width,
                EditorGUIUtility.singleLineHeight
            );
            var traderIdRect = new Rect(
                traderIdLabelRect.x + traderIdLabelRect.width,
                traderIdLabelRect.y,
                0.3f * position.width,
                EditorGUIUtility.singleLineHeight
            );

            // Draw
            EditorGUI.LabelField(modderNoteLabelRect, "Item name (reminder/optional):");
            EditorGUI.PropertyField(modderNoteRect, property.FindPropertyRelative("modderNote"), GUIContent.none);

            EditorGUI.LabelField(itemIdLabelRect, "Item ID:");
            EditorGUI.PropertyField(itemIdRect, property.FindPropertyRelative("itemId"), GUIContent.none);
            EditorGUI.LabelField(skinTextureLabelRect, "Skin texture:");
            EditorGUI.PropertyField(skinTextureRect, property.FindPropertyRelative("skinTexture"), GUIContent.none);

            SerializedProperty prerequisiteToggle = property.FindPropertyRelative("isLockedBehindPrerequisite");
            EditorGUI.LabelField(isLockedBehindPrerequisiteLabelRect, "Locked behind prerequisite(s)?");
            EditorGUI.PropertyField(isLockedBehindPrerequisiteRect, prerequisiteToggle, GUIContent.none);

            if (prerequisiteToggle.boolValue)
            {
                SerializedProperty levelToggle = property.FindPropertyRelative("mustBeLevel");
                EditorGUI.LabelField(mustBeLevelLabelRect, "Level requirement?");
                EditorGUI.PropertyField(mustBeLevelRect, levelToggle, GUIContent.none);

                if (levelToggle.boolValue)
                {
                    EditorGUI.LabelField(levelRequirementLabelRect, "Required level:");
                    EditorGUI.PropertyField(levelRequirementRect, property.FindPropertyRelative("levelRequirement"), GUIContent.none);
                }

                SerializedProperty traderLoyaltyLevelToggle = property.FindPropertyRelative("mustBeLoyaltyLevelWithTrader");
                EditorGUI.LabelField(mustBeLoyaltyLevelWithTraderLabelRect, "Trader LL requirement?");
                EditorGUI.PropertyField(mustBeLoyaltyLevelWithTraderRect, traderLoyaltyLevelToggle, GUIContent.none);

                if (traderLoyaltyLevelToggle.boolValue)
                {
                    EditorGUI.LabelField(loyaltyLevelRequirementLabelRect, "Required level:");
                    EditorGUI.PropertyField(loyaltyLevelRequirementRect, property.FindPropertyRelative("loyaltyLevelRequirement"), GUIContent.none);
                    EditorGUI.LabelField(traderIdLabelRect, "Trader ID:");
                    EditorGUI.PropertyField(traderIdRect, property.FindPropertyRelative("traderId"), GUIContent.none);
                }
            }

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 6f + (10f + 4f * 6f) * EditorGUIUtility.standardVerticalSpacing;
        }
    }
}
