// TheFinder.csC:\v1\Backup\Halette\Assets\SereDim\Script\Game\WhenSmokeIsDone\TheFinder.csTheFinder.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class TheFinder {
        public static Transform FindInHierarchy(Transform start, string targetName) {
            Transform root = start;
            while (root.parent != null) root = root.parent;
            return TheFinder.FindRecursive(root, targetName);
        }
        static Transform FindRecursive(Transform parent, string targetName) {
            if (parent.name == targetName) return parent;
            foreach (Transform child in parent) {
                Transform found = TheFinder.FindRecursive(child, targetName);
                if (found != null) return found;
            }
            return null;
        }
    }
}
