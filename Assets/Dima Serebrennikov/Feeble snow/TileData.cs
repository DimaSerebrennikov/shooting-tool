using System;
using System.Collections.Generic;
using Serebrennikov;
using UnityEngine;
namespace Serebrennikov {
	public class TileData : ITile {
		public Vector2Int IndexPosition { get; set; }
		public bool IsExisting { get; set; }
		public GameObject Instance { get; set; }
		public float Size { get; set; }
		public List<IGhost> Ghosts { get; set; } = new();
		public Subject OnRemove { get; set; } = new();
	}
}
