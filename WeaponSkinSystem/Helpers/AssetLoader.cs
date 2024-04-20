using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Arys.WeaponSkinSystem.Helpers
{
    internal static class AssetLoader
    {
        internal static readonly Dictionary<string, AssetBundle> LoadedBundles = [];
        internal static readonly Dictionary<string, AssetBundle> LoadedBundlesInRaid = [];

        /// <summary>
        /// This method is in newer releases of .NET but not .NET Framework 4.7.1
        /// </summary>
        /// <param name="relativeTo">The full path of the source directory</param>
        /// <param name="path">The full path of the destination directory</param>
        internal static string GetRelativePath(string relativeTo, string path)
        {
            var uri = new Uri(relativeTo);
            var rel = Uri.UnescapeDataString(uri.MakeRelativeUri(new Uri(path)).ToString()).Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            if (!rel.Contains(Path.DirectorySeparatorChar.ToString()))
            {
                rel = $".{Path.DirectorySeparatorChar}{rel}";
            }
            return rel;
        }

        /// <param name="path">Relative path from <see cref="Plugin.Directory"/></param>
        /// <returns>A string array containing relative paths for all bundles found within the specified path.</returns>
        internal static string[] GetBundlePathsFromDirectory(string path)
        {
            return Directory.GetFiles(Plugin.Directory + path, "*.bundle", SearchOption.AllDirectories);
        }

        /// <summary>
        /// Asynchronous version of <see cref="LoadAsset(string, string, IDictionary{string, AssetBundle})"/>.
        /// </summary>
        internal static async Task<GameObject> LoadAssetAsync(string bundle, string assetName = null, IDictionary<string, AssetBundle> targetDictionary = null)
        {
            return await LoadAssetAsync<GameObject>(bundle, assetName, targetDictionary);
        }

        internal static async Task<T> LoadAssetAsync<T>(string bundle, string assetName = null, IDictionary<string, AssetBundle> targetDictionary = null)
            where T : Object
        {
            var assetBundle = await LoadBundleAsync(bundle, targetDictionary);

            var assetBundleRequest = string.IsNullOrEmpty(assetName)
                ? assetBundle.LoadAllAssetsAsync<T>()
                : assetBundle.LoadAssetAsync<T>(assetName);
            while (!assetBundleRequest.isDone)
            {
                await Task.Yield();
            }

            if (assetBundleRequest.allAssets.Length == 0)
            {
                Plugin.LogSource.LogError($"Could not load object from bundle: {bundle}, asset list is empty");
                return null;
            }

            return (T)assetBundleRequest.allAssets[0];
        }

        internal static async Task<GameObject[]> LoadAllAssetsAsync(string bundle, IDictionary<string, AssetBundle> targetDictionary = null)
        {
            return await LoadAllAssetsAsync<GameObject>(bundle, targetDictionary);
        }

        internal static async Task<T[]> LoadAllAssetsAsync<T>(string bundle, IDictionary<string, AssetBundle> targetDictionary = null)
            where T : Object
        {
            var assetBundle = await LoadBundleAsync(bundle, targetDictionary);

            var assetBundleRequest = assetBundle.LoadAllAssetsAsync<T>();
            while (!assetBundleRequest.isDone)
            {
                await Task.Yield();
            }

            if (assetBundleRequest.allAssets.Length == 0)
            {
                Plugin.LogSource.LogError($"Could not load objects from bundle: {bundle}, asset list is empty");
                return null;
            }

            return (T[])assetBundleRequest.allAssets;
        }

        internal static void UnloadAllBundles(bool unloadAllLoadedObjects, IDictionary<string, AssetBundle> targetDictionary)
        {
            foreach (var bundle in targetDictionary.Values)
            {
                bundle.Unload(unloadAllLoadedObjects);
            }

            targetDictionary.Clear();
        }

        private static async Task<AssetBundle> LoadBundleAsync(string bundleName, IDictionary<string, AssetBundle> targetDictionary = null)
        {
            string bundlePath = bundleName;
            targetDictionary ??= LoadedBundles;

            bundleName = Regex.Match(bundleName, @"[^//]*$").Value;
            if (targetDictionary.TryGetValue(bundleName, out var bundle))
            {
                return bundle;
            }

            var bundleRequest = AssetBundle.LoadFromFileAsync(Plugin.Directory + bundlePath);
            while (!bundleRequest.isDone)
            {
                await Task.Yield();
            }

            var requestedBundle = bundleRequest.assetBundle;
            if (requestedBundle != null)
            {
                targetDictionary.Add(bundleName, requestedBundle);
                return requestedBundle;
            }

            Plugin.LogSource.LogError($"Could not load bundle: {bundlePath}");
            return null;
        }
    }
}
