using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    class ModulerController {
        List<string> _filteredList => TheModuler.Service.Get<ModulerContext>().filteredList;
        ModulerLoading _modulerLoading => TheModuler.Service.Get<ModulerLoading>();
        public void RemoveFromFilteredList(int i) {
            _filteredList.RemoveAt(i);
            _modulerLoading.SaveFilteredAssemblies(_filteredList);
        }
    }
}
