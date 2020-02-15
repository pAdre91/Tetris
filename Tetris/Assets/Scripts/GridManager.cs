using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour, IGridManager
{
	IGridController m_gridController;
	ILineChecker m_lineChecker;
	ILineCollector m_lineCollector;
}
