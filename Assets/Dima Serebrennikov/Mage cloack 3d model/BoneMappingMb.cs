using System.Collections.Generic;
using UnityEngine;
namespace Serebrennikov {
    /// Handles mapping and reassigning bones from a main SkinnedMeshRenderer
    /// to a costume mesh so that both share the same skeleton structure.
    /// Intended for dynamic character customization or costume attachment systems.
    public class BoneMappingMb : MonoBehaviour {
        [SerializeField] SkinnedMeshRenderer _source;
        [SerializeField] SkinnedMeshRenderer _targetSkin;
        public void SetBones() {
            Dictionary<string, Transform> boneMap = new Dictionary<string, Transform>();
            foreach (Transform bone in _source.bones) {
                boneMap[bone.gameObject.name] = bone;
            }
            Transform[] newBones = new Transform[_targetSkin.bones.Length];
            for (int i = 0; i < _targetSkin.bones.Length; i++) {
                GameObject bone = _targetSkin.bones[i].gameObject;
                if (!boneMap.TryGetValue(bone.name, out newBones[i])) {
                    Debug.Log("Failed to map bones " + bone.name);
                    continue;
                }
            }
            _targetSkin.bones = newBones;
        }
    }
}
