// Loading.csC:\Feeble snow\Assets\Serebrennikov\Module manager\Loading.csLoading.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
namespace Serebrennikov {
    class ModulerLoading {
        const string FilteredAssembliesKey = "Serebrennikov.ModuleManager.FilteredAssemblies";
        List<string> _target;
        public ModulerLoading([Inject(Id = "filteredList")] List<string> target) {
            _target = target;
        }
        public void Start() {
            _target.Clear();
            if (!EditorPrefs.HasKey(FilteredAssembliesKey)) {
                return;
            }
            string storedValue = EditorPrefs.GetString(FilteredAssembliesKey);
            if (string.IsNullOrEmpty(storedValue)) {
                return;
            }
            string[] entries = storedValue.Split(';');
            foreach (string entry in entries) {
                if (!string.IsNullOrEmpty(entry)) {
                    _target.Add(entry);
                }
            }
        }
        public void SaveFilteredAssemblies(List<string> sourceList) {
            if (sourceList.Count == 0) {
                EditorPrefs.DeleteKey(FilteredAssembliesKey);
                return;
            }
            string storedValue = string.Join(";", sourceList);
            EditorPrefs.SetString(FilteredAssembliesKey, storedValue);
        }
    }
}
