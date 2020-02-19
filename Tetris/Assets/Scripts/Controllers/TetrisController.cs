using UnityEngine;

namespace Tetris
{
	public class TetrisController : ITetrisController
	{
		private	IShapeQueueController		m_shapeQueueController;
		private	IShapeSpawner				m_shapeSpawner;
		private	IShapePositionCoordinator	m_shapePositionCoordinator;
		private	IGridManager				m_gridManager;
		private	ISwitcher					m_switcher;

		public TetrisController()
		{
			m_shapeQueueController		=	new	ShapeQueueController		();
			m_shapePositionCoordinator	=	new	ShapePositionCoordinator	();
			m_gridManager				=	new	GridManager					();
			m_switcher					=	new	Switcher					();

			m_shapeSpawner				=	GameObject.FindGameObjectWithTag("Spawner").GetComponent<IShapeSpawner>();
		}

		public void SpawnNewShape()
		{
			GameObject shapeFromQueue = m_shapeQueueController.GetNewShape();
			m_shapeQueueController.AddRandomShape();

			m_shapePositionCoordinator.CurrentShape = m_shapeSpawner.SpawnShape(shapeFromQueue).GetComponent<IShape>();
		}

		public bool MoveShapeVerticalByKey()
		{
			GameObject shapeGO = m_shapePositionCoordinator.CurrentShape.ShapeGameObject;

			if (!m_gridManager.ValidateShapeMove(shapeGO, Vector3.down) && m_shapePositionCoordinator.IsShapeCanFallByTime(GetFallTime()/3))
				return false;

			m_shapePositionCoordinator.VerticalMoveShape(Vector3.down * 0.4f, GetFallTime()/3);
			return true;
		}

		public bool AutoMoveShapeVertical()
		{
			GameObject shapeGO = m_shapePositionCoordinator.CurrentShape.ShapeGameObject;

			if (!m_gridManager.ValidateShapeMove(shapeGO, Vector3.down) && m_shapePositionCoordinator.IsShapeCanFallByTime(GetFallTime()))
				return false;

			m_shapePositionCoordinator.VerticalMoveShape(Vector3.down * 0.4f, GetFallTime());
			return true;
		}

		public void MoveShapeHorizontal(float horizontalMove)
		{
			Vector3 horizontalDirection = new Vector3(horizontalMove, 0, 0);
			GameObject shapeGO = m_shapePositionCoordinator.CurrentShape.ShapeGameObject;

			if (horizontalDirection == Vector3.zero)
				return;

			if (m_gridManager.ValidateShapeMove(shapeGO, horizontalDirection))
				m_shapePositionCoordinator.HorizontalMoveShape(horizontalDirection * 0.4f, GetFallTime()/3);        //Магические числа
		}

		public void Rotate(int angle)
		{
			if (m_gridManager.ValidateShapeRotate(m_shapePositionCoordinator.CurrentShape.ShapeGameObject, m_shapePositionCoordinator.CurrentShape.RotationPoint, angle))
			{
				m_shapePositionCoordinator.RotateShape(angle);
			}
		}

		public void AddShapeToGrid()
		{
			m_gridManager.AddShapeToGrid(m_shapePositionCoordinator.CurrentShape.ShapeGameObject);
		}

		public void CheckFilledLines()
		{
			int countFieldLines = m_gridManager.RemoveFilledLines();

			if (countFieldLines == 0)
				return;

			m_switcher.EarnPoints(countFieldLines);
			m_switcher.SwitchSpeed();
		}

		public float GetFallTime()
		{
			return (float)1 / m_switcher.GetSpeed();
		}

		public void ChangeSpeed(float sign)
		{
			if(sign > 0)		//Считать первый бит
				m_switcher.ChangeSpeed(true);
			else
				m_switcher.ChangeSpeed(false);
		}

		public bool IsCurrentShapeNew()
		{
			return m_shapePositionCoordinator.IsCurrentShapeNew();
		}
	}
}
