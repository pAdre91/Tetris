using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapePositionCoordinator : MonoBehaviour, IShapePositionCoordinator
{
	IShape m_currentShape;
	IScaler m_scaler;
}
