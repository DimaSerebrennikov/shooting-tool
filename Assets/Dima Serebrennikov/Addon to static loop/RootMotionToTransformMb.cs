// RootMotionToTransformMb.csC:\v1\Backup\Halette\Assets\SereDim\Script\Game\WhenSmokeIsDone\RootMotionToTransformMb.csNiger.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class RootMotionToTransformMb : MonoBehaviour {
        [SerializeField] Animator _animator;
        [SerializeField] Transform _playerTransform;
        void Reset() {
            _animator = GetComponent<Animator>();
            _playerTransform = TheFinder.FindInHierarchy(transform, "Player");
        }
        void OnAnimatorMove() {
            _playerTransform.position += _animator.deltaPosition;
            _playerTransform.rotation *= _animator.deltaRotation;
        }
    }
}
