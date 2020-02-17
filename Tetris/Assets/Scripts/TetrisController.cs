using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris
{
	public class TetrisController : ITetrisController
	{
		private IShapeQueueGenerator		m_shapeQueueGenerator;
		private IShapeSpawner				m_shapeSpawner;
		private IShapePositionCoordinator	m_shapePositionCoordinator;
		private IGridManager				m_gridManager;
		private ISwitcher					m_switcher;

		public TetrisController()
		{
			m_shapeQueueGenerator = new ShapeQueueGenerator();
			m_shapePositionCoordinator = new ShapePositionCoordinator();
			m_gridManager = new GridManager();

			m_shapeSpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<IShapeSpawner>();
			SpawnNewShape();
		}

		public void SpawnNewShape()
		{
			GameObject shapeFromQueue = m_shapeQueueGenerator.GetNewShape();
			m_shapeQueueGenerator.AddRandomShapeData();

			m_shapePositionCoordinator.CurrentShape = m_shapeSpawner.SpawnShape(shapeFromQueue).GetComponent<IShape>();
		}

		public void MoveShape(float horizontalMove, float verticalMove)
		{
			Vector3 horizontalDirection = new Vector3(horizontalMove, 0, 0);
			Vector3 verticalDirection = new Vector3(0, verticalMove, 0);
			GameObject shapeGO = m_shapePositionCoordinator.CurrentShape.ShapeGameObject;

			if (horizontalDirection != Vector3.zero && m_gridManager.ValidateShapeMove(shapeGO, horizontalDirection))
			{
				m_shapePositionCoordinator.HorizontalMoveShape(horizontalDirection * 0.436f, 1);        //Магические числа
			}
			if (verticalDirection != Vector3.zero && m_gridManager.ValidateShapeMove(shapeGO, verticalDirection) && verticalMove < 0)
			{
				m_shapePositionCoordinator.VerticalMoveShape(verticalDirection * 0.44f, 1);     //Магические числа
			}	/*Если фигура может упасть, так как КД падения прошел, но под ней что-то есть*/
			else if (!m_gridManager.ValidateShapeMove(shapeGO, verticalDirection) && m_shapePositionCoordinator.IsShapeCanFallByTime(1))
			{
				m_gridManager.AddShapeToGrid(shapeGO);      //А это точно тут должно быть?
				m_gridManager.RemoveFilledLines();
				SpawnNewShape();																				//А это точно тут должно быть?
			}
		}

		public void Rotate(int angle)
		{
			if (m_gridManager.ValidateShapeRotate(m_shapePositionCoordinator.CurrentShape.ShapeGameObject, m_shapePositionCoordinator.CurrentShape.RotationPoint, angle))
			{
				m_shapePositionCoordinator.RotateShape(angle);
			}
		}

		public float GetFallTime()
		{
			return 1f;				//Заглушка
		}

		/*private IEnumerator FallShape()
		{
			MoveShape(Vector3.down.x, Vector3.down.y);
			yield return new WaitForSeconds(1f);
		}*/
	}
}
