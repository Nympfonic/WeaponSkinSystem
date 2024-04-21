using Aki.Reflection.Patching;
using EFT.UI.WeaponModding;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Arys.WeaponSkinSystem.Patches
{
    internal class WeaponModdingScreenClosePatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(WeaponModdingScreen), nameof(WeaponModdingScreen.Close));
        }

        [PatchPostfix]
        private static void PatchPostfix()
        {

        }
    }
}
