using UnityEngine;

interface IShapePositionCoordinator
{
	IShape CurrentShape { set; get; }
	void HorizontalMoveShape(Vector3 direction, float speed);
	void VerticalMoveShape(Vector3 direction, float speed);
	void RotateShape(int angle);
	bool IsShapeCanFallByTime(float speed);
	bool IsCurrentShapeNew();
}
