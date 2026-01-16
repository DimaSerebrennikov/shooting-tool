using System;
using Serebrennikov;
using UnityEngine;
using UnityEngine.Serialization;
namespace Serebrennikov {
	[Serializable]
	public class FilterData : IFilter {
		[SerializeField] Transform _filterTransform;
		[SerializeField] FilterColorData _filterColor;
		[SerializeField] Vector3 _defaultPosition;
		[SerializeField] bool _isPlayerTriggered;
		public Transform FilterTransform { get => _filterTransform; set => _filterTransform = value; }
		public FilterColorData FilterColor { get => _filterColor; set => _filterColor = value; }
		public bool IsPlayerTriggered { get => _isPlayerTriggered; set => _isPlayerTriggered = value; }
		public Vector3 DefaultPosition { get => _defaultPosition; set => _defaultPosition = value; }
	}
}
