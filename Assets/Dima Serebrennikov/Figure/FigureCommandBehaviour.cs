using UnityEngine;
namespace Serebrennikov {
	public abstract class FigureCommandBehaviour : MonoBehaviour {
		public abstract void Prepare(IFigure a);
	}
}