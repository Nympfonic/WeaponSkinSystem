using BepInEx;
using BepInEx.Logging;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Arys.WeaponSkinSystem
{
    [BepInPlugin("com.Arys.WeaponSkinSystem", "Arys' Weapon Skin System", "1.0.0")]
    [BepInDependency("com.Arys.CustomAssetImporter", "1.2.0")]
    public class Plugin : BaseUnityPlugin
    {
        internal static string Directory;
        internal static ManualLogSource LogSource;

        private static Task _currentTask;

        internal static Task CurrentTask
        {
            get => _currentTask;
            set
            {
                if (!value.IsCompleted || !value.IsCanceled || !value.IsFaulted)
                {
                    return;
                }

                _currentTask = value;
            }
        }

        private void Awake()
        {
            LogSource = Logger;
            Directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/";
        }
    }
}
