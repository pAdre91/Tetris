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
			m_shapeSpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<IShapeSpawner>();
			Start();
		}

		public void Start()
		{
			m_shapeSpawner.SpawnShape(m_shapeQueueGenerator.GetNewShape());
		}


	}
}
