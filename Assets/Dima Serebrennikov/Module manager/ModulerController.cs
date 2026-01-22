using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    class ModulerController {
        List<string> _filteredList;
        ModulerLoading _modulerLoading;
        public ModulerController(List<string> filteredList, ModulerLoading modulerLoading) {
            _filteredList = filteredList;
            _modulerLoading = modulerLoading;
        }
        public void RemoveFromFilteredList(int i) {
            _filteredList.RemoveAt(i);
            _modulerLoading.SaveFilteredAssemblies(_filteredList);
        }
    }
}
