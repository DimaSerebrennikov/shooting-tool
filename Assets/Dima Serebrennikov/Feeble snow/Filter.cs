using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public interface IFilter {
        Transform FilterTransform { get; set; }
        FilterColorData FilterColor { get; set; }
        bool IsPlayerTriggered { get; set; }
        Vector3 DefaultPosition { get; set; }
    }
    public class Filter : MonoBehaviour, IFilter {
        /*------IMPLEMENTATION------*/
        /*------RESOURCES------*/
        [SerializeField] FilterData _data;
        /*------DELEGATION------*/
        public FilterData Data { get => _data; set => _data = value; }
        /*--DELEGATION--*/
        public Transform FilterTransform {
            get => _data.FilterTransform;
            set => _data.FilterTransform = value;
        }
        public FilterColorData FilterColor {
            get => _data.FilterColor;
            set => _data.FilterColor = value;
        }
        public bool IsPlayerTriggered {
            get => _data.IsPlayerTriggered;
            set => _data.IsPlayerTriggered = value;
        }
        public Vector3 DefaultPosition {
            get => _data.DefaultPosition;
            set => _data.DefaultPosition = value;
        }
    }
}
