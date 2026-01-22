using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor.Compilation;
using UnityEngine;
namespace Serebrennikov {
    class ProjectAssemblyController {
        List<string> _projectAssemblyList => TheModuler.Service.Get<SelectionComponentContext>().projectAssemblyList;
        public void Start() {
            _projectAssemblyList.AddRange(CompilationPipeline.GetAssemblies().
                /**/ Select(a => a.name).
                /**/ OrderBy(a => a).
                /**/ ToList());
        }
    }
}
