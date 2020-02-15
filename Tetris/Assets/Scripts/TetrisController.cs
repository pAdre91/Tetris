using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisController : MonoBehaviour, ITetrisController
{
	private IShapeQueueGenerator m_shapeQueueGenerator;
	private IShapeSpawner m_shapeSpawner;
	private IShapePositionCoordinator m_shapePositionCoordinator;
	private IGridManager m_gridManager;
	private ISwitcher m_switcher;
}
