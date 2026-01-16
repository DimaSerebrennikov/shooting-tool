using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
namespace DependenciesHunter {
    public class AssetData {
        public static AssetData Create(string path, int referencesCount, string warning) {
            Type type = AssetDatabase.GetMainAssetTypeAtPath(path);
            string typeName;
            if (type != null) {
                typeName = type.ToString();
                typeName = typeName.Replace("UnityEngine.", string.Empty);
                typeName = typeName.Replace("UnityEditor.", string.Empty);
            } else {
                typeName = "Unknown Type";
            }
            bool isAddressable = CommonUtilities.IsAssetAddressable(path);
            long bytesSize = 0L;
            try {
                FileInfo fileInfo = new(path);
                bytesSize = fileInfo.Length;
            }
            catch (Exception e) {
                Debug.LogWarning($"Error reading file {path} with error: {e}. Unable to detect its size.");
            }
            return new AssetData(path, type, typeName, bytesSize,
                CommonUtilities.GetReadableSize(bytesSize), isAddressable, referencesCount, warning);
        }

        AssetData(string path, Type type, string typeName, long bytesSize,
            string readableSize, bool addressable, int referencesCount, string warning) {
            Path = path;
            ShortPath = Path.Replace("Assets/", string.Empty);
            Type = type;
            TypeName = typeName;
            BytesSize = bytesSize;
            ReadableSize = readableSize;
            IsAddressable = addressable;
            ReferencesCount = referencesCount;
            Warning = warning;
        }

        public string Path { get; }
        public string ShortPath { get; }
        public Type Type { get; }
        public string TypeName { get; }
        public long BytesSize { get; }
        public string ReadableSize { get; }
        public bool IsAddressable { get; }
        public int ReferencesCount { get; }
        public string Warning { get; }
        public bool ValidType => Type != null;
        public bool Foldout { get; set; }
    }
}