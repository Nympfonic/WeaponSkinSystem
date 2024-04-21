using Aki.Reflection.Patching;
using Arys.WeaponSkinSystem.Helpers;
using EFT.UI.WeaponModding;
using HarmonyLib;
using System.Reflection;
using System.Threading.Tasks;

namespace Arys.WeaponSkinSystem.Patches
{
    internal class WeaponModdingScreenShowPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.FirstMethod(typeof(WeaponModdingScreen), IsTargetMethod);
        }

        private bool IsTargetMethod(MethodInfo mi)
        {
            ParameterInfo[] parameters = mi.GetParameters();

            return mi.Name == "Show"
                && parameters.Length == 3;
        }

        [PatchPrefix]
        private static void PatchPrefix(WeaponModdingScreen __instance)
        {
            // Async load bundles
            
        }
    }
}
