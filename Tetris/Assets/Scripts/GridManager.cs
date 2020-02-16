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
				float childrenPositionX = (children.transform.position.x + (direction.x * m_scale))/ m_scale;
				float childrenPositionY = (children.transform.position.y + (direction.y * m_scale))/ m_scale;

				byte x = (byte)Math.Floor(childrenPositionX);
				byte y = (byte)Math.Floor(childrenPositionY);

				if (!m_gridController.IsAreaFree(x, y))
					return false;
			}

			return true;
		}
	}
}
