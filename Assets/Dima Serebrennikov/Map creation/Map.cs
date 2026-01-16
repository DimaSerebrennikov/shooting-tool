// MapManager.csC:\Feeble snow\Assets\Serebrennikov\Map creation\MapManager.csMapManager.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class Map : MonoBehaviour {
        [SerializeField] TileContext _contextAsset;
        [SerializeField] RandomComponentCreator _creatorAsset;
        [SerializeField] List<Component> _creation;
        [SerializeField] MapContext _mapContextAsset;
        void Awake() {
            _creatorAsset = TheUnityObject.InstanceFromAsset(_creatorAsset);
            _contextAsset = TheUnityObject.InstanceFromAsset(_contextAsset);
            _mapContextAsset = TheUnityObject.InstanceFromAsset(_mapContextAsset);
        }
        public void Update() {
            for (int i = 0; i < _contextAsset.Revealed.Count; i++) {
                FigureRevealingData reveal = _contextAsset.Revealed[i];
                for (int j = 0; j < _creatorAsset.History.Count; j++) {
                    FigureStyle n = _creatorAsset.History[j];
                    if (n.Id == reveal.Id) {
                        Component created = Instantiate(_creation[n.Style], _contextAsset.Revealed[i].Position, Quaternion.identity);
                        _mapContextAsset.Created(created);
                        _creatorAsset.History.RemoveAt(j);
                        break;
                    }
                }
            }
        }
    }
}
