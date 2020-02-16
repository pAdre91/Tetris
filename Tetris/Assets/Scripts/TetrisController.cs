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
			m_shapePositionCoordinator.CurrentShape = m_shapeSpawner.SpawnShape(shapeFromQueue).GetComponent<IShape>();
		}

		public void MoveShape(float horizontalMove, float verticalMove)
		{
			Vector3 horizontalDirection = new Vector3(horizontalMove, 0, 0);			//Не забыть умножать на Scale
			Vector3 verticalDirection = new Vector3(0, verticalMove, 0);            //Добавить проверку на неположительность? Что бы фигуры вверх не двигались

			if (horizontalDirection != Vector3.zero && m_gridManager.ValidateShapeMove(m_shapePositionCoordinator.CurrentShape.ShapeGameObject, horizontalDirection))		//Разбить условия, это нечитаемо
				m_shapePositionCoordinator.HorizontalMoveShape(horizontalDirection*0.436f, 1);
			if (verticalDirection != Vector3.zero && m_gridManager.ValidateShapeMove(m_shapePositionCoordinator.CurrentShape.ShapeGameObject, verticalDirection) && verticalMove < 0)
				m_shapePositionCoordinator.VerticalMoveShape(verticalDirection * 0.44f, 1);
		}

	}
}
