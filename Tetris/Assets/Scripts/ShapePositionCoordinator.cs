using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapePositionCoordinator : IShapePositionCoordinator
{
	public IShape CurrentShape { set; get; }			//Может убрать, а  метода просто передавать конкретную фигуру?

	/*public IShape GetMovedShapeGameobjects(Vector3 direction)
	{
		IShape tempShape = CurrentShape;
		tempShape.Move(direction);
		return tempShape;
	}*/

	public void MoveShape(Vector3 direction)
	{
		CurrentShape.Move(direction);
	}
}
