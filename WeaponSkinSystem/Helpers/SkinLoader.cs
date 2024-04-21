using CustomAssetImporter.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arys.WeaponSkinSystem.Helpers
{
    internal class SkinLoader
    {
        internal static readonly Dictionary<string, AssetBundle> LoadedSkinBundles = [];

        internal static void LoadSkinBundles()
        {
            Plugin.CurrentTask = Task.Run(() => AssetLoader.LoadAllAssetsAsync());
        }
    }
}
