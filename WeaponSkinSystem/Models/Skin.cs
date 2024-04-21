using Arys.WeaponSkinSystem.Editor;
using System;
using UnityEngine;

namespace Arys.WeaponSkinSystem.Models
{
    [Serializable]
    public class Skin
    {
        public string modderNote;

        [MongoId] public string itemId;

        public string skinName;
        public Texture2D skinTexture;

        public bool isLockedBehindPrerequisite;

        public bool mustBeLevel;
        [Range(1, 79)] public int levelRequirement = 1;

        public bool mustBeLoyaltyLevelWithTrader;
        [Range(0, 4)] public int loyaltyLevelRequirement = 0;
        [MongoId] public string traderId;

        public bool mustHaveCompletedQuest;
        public Quest[] questRequirements;
    }
}
