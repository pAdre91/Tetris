using UnityEngine;

namespace Tetris
{
	class Shape : MonoBehaviour, IShape
	{
		[SerializeField]
		private Vector3 RotationPoint;

		public GameObject ShapeGameObject
		{
			get
			{
				return gameObject;
			}
		}

		public void Move(Vector3 direction)
		{
			transform.position += direction;
		}

		public void Rotate(int angle)			//точно ли нужен угол?
		{
			transform.RotateAround(transform.TransformPoint(RotationPoint), new Vector3(0, 0, 1), angle);
		}
	}
}
