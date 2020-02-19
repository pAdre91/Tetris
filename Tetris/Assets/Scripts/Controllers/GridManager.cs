using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris        //Grid?
{
	public class GridManager : IGridManager
	{
		private float m_scale = 0.436f;             //Тут ли его хранить? //Убрать хардкод!

		IGridModel		m_gridModel;
		ILineChecker	m_lineChecker;
		ILineScorer		m_lineScorer;

		public GridManager()
		{
			m_gridModel		=	new	GridModel	(10, 20);         //Убрать хардкод!
			m_lineChecker	=	new	LineChecker	();
			m_lineScorer	=	new	LineScorer	(); 
		}

		public bool ValidateShapeMove(GameObject shape, Vector3 direction)
		{
			foreach (Transform children in shape.transform)
			{
				TranslateCoordinateToGridNumbers(children.position, out byte x, out byte y, direction);
				if (!m_gridModel.IsAreaFree(x, y))
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

				if (!m_gridModel.IsAreaFree(x, y))
					return false;
			}
			return true;
		}

		public void AddShapeToGrid(GameObject shape)
		{
			foreach (Transform children in shape.transform)
			{
				TranslateCoordinateToGridNumbers(children.position, out byte x, out byte y, Vector3.zero);
				m_gridModel.SetArea(x, y, children);
			}
		}

		public int RemoveFilledLines()
		{
			Stack<byte> filledLines = m_lineChecker.GetNumbersFilledLines(m_gridModel.PlayFieldGrid);
			int gridWidth = m_gridModel.PlayFieldGrid.GetLength(0);
			int gridHeight = m_gridModel.PlayFieldGrid.GetLength(1);

			if (filledLines.Count <= 0)
				return 0;

			foreach (byte numberLine in filledLines)
			{
				for (byte j = 0; j < gridWidth; j++)
					m_gridModel.RemoveArea(j, numberLine);
				RowDown(numberLine, gridWidth, gridHeight);
			}

			m_lineScorer.AddNewLines(filledLines.Count);
			return filledLines.Count;
		}

		private void RowDown(byte startNumberLine, int gridWidth, int gridHeight)
		{
			for (byte rowLine = startNumberLine; rowLine < gridHeight; rowLine++)
			{
				for (byte rowColumn = 0; rowColumn < gridWidth; rowColumn++)
				{
					if (!m_gridModel.IsAreaFree(rowColumn, rowLine))
						m_gridModel.ReplaceAreaFromGrid(rowColumn, rowLine, rowColumn, rowLine - 1, Vector3.down * m_scale);
				}
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
