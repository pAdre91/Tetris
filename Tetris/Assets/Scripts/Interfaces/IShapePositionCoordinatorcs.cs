using UnityEngine;

interface IShapePositionCoordinator
{
	IShape CurrentShape { set; get; }
	//IShape GetMovedShape(Vector3 direction);
	void MoveShape(Vector3 direction);
}
