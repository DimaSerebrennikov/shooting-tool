// TheFile.csC:\GameDev\Halette\Assets\SereDim\Script\Game\WhenSmokeIsDone\TheFile.csTheFile.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public static class TheFile {
        public static string AssureFolderAtPersistentPath(string folderName) {
            string folderPath = Path.Combine(Application.persistentDataPath, folderName);
            if (!Directory.Exists(folderPath)) {
                Directory.CreateDirectory(folderPath);
            }
            return folderPath;
        }
        public static string[] GetSubfolders(string folderName) {
            string folderPath = AssureFolderAtPersistentPath(folderName);
            return Directory.GetDirectories(folderPath);
        }
        public static void RenameDirectory(string fullPath, string newDirectoryName) {
            if (Directory.Exists(fullPath)) {
                string parent = Path.GetDirectoryName(fullPath);
                string newFullPath = Path.Combine(parent, newDirectoryName);
                Directory.Move(fullPath, newFullPath);
            }
        }
    }
}
