using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    internal class DesignService {
        Label _designText;
        ListView _listView;
        public DesignService(Label designText, ListView listView) {
            _designText = designText;
            _listView = listView;
        }
        public void Start() {
            _listView.selectionChanged += _ => {
                if (_listView.selectedItem == null) return;
                string assemblyName = (string)_listView.selectedItem;
                string asmdefGuid = AssetDatabase.FindAssets($"{assemblyName} t:asmdef").FirstOrDefault();
                if (asmdefGuid == null) {
                    _designText.text = $"Asmdef not found for assembly:\n{assemblyName}";
                    return;
                }
                string asmdefPath = AssetDatabase.GUIDToAssetPath(asmdefGuid);
                string asmdefDir = Path.GetDirectoryName(asmdefPath);
                string designDir = Path.Combine(asmdefDir, "Design");
                if (!Directory.Exists(designDir)) {
                    _designText.text = $"Design folder not found:\n{designDir}";
                    return;
                }
                string mdPath = Directory.EnumerateFiles(designDir, "*.md").FirstOrDefault();
                _designText.text = mdPath != null ? File.ReadAllText(mdPath) : $"No .md file found in:\n{designDir}";
            };
        }
    }
}