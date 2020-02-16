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
			SpawnShape();
		}

		public void SpawnShape()
		{
			GameObject shapeFromQueue = m_shapeQueueGenerator.GetNewShape();
			m_shapeQueueGenerator.AddRandomShapeData();

			m_shapePositionCoordinator.CurrentShape = m_shapeSpawner.SpawnShape(shapeFromQueue).GetComponent<IShape>();
		}

		public void MoveShape(float horizontalMove, float verticalMove)
		{
			Vector3 horizontalDirection = new Vector3(horizontalMove, 0, 0);
			Vector3 verticalDirection = new Vector3(0, verticalMove, 0);

			if (horizontalDirection != Vector3.zero && m_gridManager.ValidateShapeMove(m_shapePositionCoordinator.CurrentShape.ShapeGameObject, horizontalDirection))
			{
				m_shapePositionCoordinator.HorizontalMoveShape(horizontalDirection * 0.436f, 1);        //Магические числа
			}
			if (verticalDirection != Vector3.zero && m_gridManager.ValidateShapeMove(m_shapePositionCoordinator.CurrentShape.ShapeGameObject, verticalDirection) && verticalMove < 0)
			{
				m_shapePositionCoordinator.VerticalMoveShape(verticalDirection * 0.44f, 1);     //Магические числа
			}
			else if (!m_gridManager.ValidateShapeMove(m_shapePositionCoordinator.CurrentShape.ShapeGameObject, verticalDirection))
			{
				m_gridManager.AddShapeToGrid(m_shapePositionCoordinator.CurrentShape.ShapeGameObject);      //А это точно тут должно быть?
				SpawnShape();																				//А это точно тут должно быть?
			}
		}

		/*private IEnumerator FallShape()
		{
			MoveShape(Vector3.down.x, Vector3.down.y);
			yield return new WaitForSeconds(1f);
		}*/
	}
}
