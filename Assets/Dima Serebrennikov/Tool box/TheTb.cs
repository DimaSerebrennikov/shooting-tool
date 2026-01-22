// TheTb.csC:\GameDev\Halette\Assets\SereDim\Script\Game\WhenSmokeIsDone\TheTb.csTheTb.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public static class TheTb {
        static string FOLDER_PATH = TheFile.AssureFolderAtPersistentPath("ToolBox");
        public static void Add(params string[] path) {
            string currentPath = FOLDER_PATH;
            foreach (string folderName in path) {
                currentPath = Path.Combine(currentPath, folderName);
                Directory.CreateDirectory(currentPath);
            }
        }
        public static void Remove(params string[] path) {
            string currentPath = FOLDER_PATH;
            foreach (string folderName in path) {
                currentPath = Path.Combine(currentPath, folderName);
            }
            if (Directory.Exists(currentPath)) {
                Directory.Delete(currentPath, true);
            }
        }
        public static void Update(params string[] path) {
            string[] pathWithoutLast = path.Length > 0 ? path[..^1] : Array.Empty<string>();
            Remove(pathWithoutLast);
            Add(path);
        }
        public static void Clear(params string[] path) {
            string currentPath = FOLDER_PATH;
            foreach (string folderName in path) {
                currentPath = Path.Combine(currentPath, folderName);
            }
            if (Directory.Exists(currentPath)) {
                foreach (string file in Directory.GetFiles(currentPath)) {
                    File.Delete(file);
                }
                foreach (string dir in Directory.GetDirectories(currentPath)) {
                    Directory.Delete(dir, true);
                }
            }
        }
    }
}
