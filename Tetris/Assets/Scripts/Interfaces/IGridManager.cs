using UnityEngine;

interface IGridManager
{
	bool ValidateShapeMove(GameObject shape, Vector3 direction);
	bool ValidateShapeRotate(GameObject shape, Vector3 aroundPoint, int angle);
	void AddShapeToGrid(GameObject shape);
}
