using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace DependenciesHunter {
    public static class CommonUtilities {
        public static string GetReadableSize(long bytesSize) {
            string[] sizes = {
                "B",
                "KB",
                "MB",
                "GB",
                "TB"
            };
            double len = bytesSize;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1) {
                order++;
                len = len / 1024;
            }
            return $"{len:0.##} {sizes[order]}";
        }

        public static bool IsAssetAddressable(string assetPath) {
#if HUNT_ADDRESSABLES
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            var entry = settings.FindAssetEntry(AssetDatabase.AssetPathToGUID(assetPath));
            return entry != null;
#else
            return false;
#endif
        }
    }
}