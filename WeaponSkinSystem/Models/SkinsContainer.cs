using UnityEngine;

namespace Arys.WeaponSkinSystem.Models
{
    [CreateAssetMenu(fileName = "MySkins", menuName = "Arys' WeaponSkinSystem/Skins Template", order = 1)]
    public class SkinsContainer : ScriptableObject
    {
        public Skin[] skins;
    }
}
