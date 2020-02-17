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
				TranslateCoordinateToGridNumbers(children.position, out byte x, out byte y, direction);
				if (!m_gridController.IsAreaFree(x, y))
					return false;
			}
			return true;
		}

		public bool ValidateShapeRotate(GameObject shape, Vector3 aroundPoint, int angle)
		{
			foreach (Transform children in shape.transform)
			{
				Vector3 rotatedChildren = Rotate(children.transform.localPosition, aroundPoint, angle);
				Vector3 rotatedChildrenToWorldPoint = shape.transform.TransformPoint(rotatedChildren);

				TranslateCoordinateToGridNumbers(rotatedChildrenToWorldPoint, out byte x, out byte y, Vector3.zero);

				if(!m_gridController.IsAreaFree(x,y))
					return false;
			}
			return true;
		}

		public void AddShapeToGrid(GameObject shape)
		{
			foreach (Transform children in shape.transform)
			{
				TranslateCoordinateToGridNumbers(children.position, out byte x, out byte y, Vector3.zero);		//Проверка и логи
				m_gridController.SetArea(x, y, children);
			}
		}

		/*Перевод глобавльной координаты в координату сетки*/
		private void TranslateCoordinateToGridNumbers(Vector3 pos, out byte x, out byte y, Vector3 direction)
		{
			float childrenPositionX = (pos.x + (direction.x * m_scale)) / m_scale;
			float childrenPositionY = (pos.y + (direction.y * m_scale)) / m_scale;

			x = (byte)Math.Floor(childrenPositionX);
			y = (byte)Math.Floor(childrenPositionY);
		}

		/*Вращение вектора вокруг точки*/
		private Vector2 Rotate(Vector2 rotatedPoint, Vector2 aroundPoint, float angle)
		{
			Vector2 resultPoint;
			Vector2 rotatedVector = rotatedPoint - aroundPoint;

			float cos = (float)Math.Round(Math.Cos(angle * Math.PI / 180), 1);
			float sin = (float)Math.Round(Math.Sin(angle * Math.PI / 180), 1);

			resultPoint.x = rotatedVector.x * cos - rotatedVector.y * sin;
			resultPoint.y = rotatedVector.x * sin + rotatedVector.y * cos;

			return resultPoint;
		}
	}
}
