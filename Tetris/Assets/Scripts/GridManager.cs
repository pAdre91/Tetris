using System;
using UnityEngine;
namespace Tetris
{
	public class GridManager : IGridManager
	{
		private float m_scale = 0.436f;             //Тут ли его хранить? //Убрать хардкод!

		IGridModel m_gridController;
		ILineChecker m_lineChecker;
		ILineCollector m_lineCollector;

		public GridManager()
		{
			m_gridController = new GridModel(10,20);			//Убрать хардкод!
		}

		public bool ValidateShapeMove(GameObject shape, Vector3 direction)
		{
			foreach (Transform children in shape.transform)
			{
				TranslateCoordinateToGridNumbers(children, out byte x, out byte y, direction);
				if (!m_gridController.IsAreaFree(x, y))
					return false;
			}
			return true;
		}

		public void AddShapeToGrid(GameObject shape)
		{
			foreach (Transform children in shape.transform)
			{
				TranslateCoordinateToGridNumbers(children, out byte x, out byte y, Vector3.zero);
				m_gridController.SetArea(x, y, children);
			}
		}

		private void TranslateCoordinateToGridNumbers(Transform gameObject, out byte x, out byte y, Vector3 direction)
		{
			float childrenPositionX = (gameObject.position.x + (direction.x * m_scale)) / m_scale;
			float childrenPositionY = (gameObject.position.y + (direction.y * m_scale)) / m_scale;

			x = (byte)Math.Floor(childrenPositionX);
			y = (byte)Math.Floor(childrenPositionY);
		}
	}
}
