using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor.Compilation;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    internal class ProjectAssemblyController {
        List<string> _projectAssemblyList;
        public ProjectAssemblyController(List<string> projectAssemblyList) {
            _projectAssemblyList = projectAssemblyList;
        }
        public void Start() {
            _projectAssemblyList.AddRange(CompilationPipeline.GetAssemblies().
                /**/ Select(a => a.name).
                /**/ OrderBy(a => a).
                /**/ ToList());
        }
    }
}