using BepInEx;
using BepInEx.Logging;
using System.IO;
using System.Reflection;

namespace Arys.WeaponSkinSystem
{
    [BepInPlugin("com.Arys.WeaponSkinSystem", "Arys' Weapon Skin System", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        internal static string Directory;
        internal static ManualLogSource LogSource;

        private void Awake()
        {
            LogSource = Logger;
            Directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/";
        }
    }
}
