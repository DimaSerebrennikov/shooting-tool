using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    [Serializable]
    public class FilterColorData {
        /*--RESOURCE--*/
        [SerializeField] Material _enemyMaterial;
        [SerializeField] MeshRenderer _mr;
        float _curH;
        Color _curColor;
        Action<FilterColorData> _onChangeColor;
        int _index;
        /*--DELEGATION--*/
        public Material EnemyMaterial {
            get => _enemyMaterial;
            set => _enemyMaterial = value;
        }
        public MeshRenderer Mr {
            get => _mr;
            set => _mr = value;
        }
        public float CurH {
            get => _curH;
            set => _curH = value;
        }
        public Color CurColor {
            get => _curColor;
            set => _curColor = value;
        }
        public Action<FilterColorData> OnChangeColor {
            get => _onChangeColor;
            set => _onChangeColor = value;
        }
        public int Index {
            get => _index;
            set => _index = value;
        }
        public void SetColorData(Color color,
            float H) {
            CurH = H;
            CurColor = color;
            Mr.material.color = color;
        }
    }
}
