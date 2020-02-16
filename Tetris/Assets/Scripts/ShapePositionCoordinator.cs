using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapePositionCoordinator : IShapePositionCoordinator
{
	public IShape CurrentShape { set; get; }            //Может убрать, а  метода просто передавать конкретную фигуру?

	private float previousVerticalTime = 0f;
	private float previousHorizontalTime = 0f;

	public void HorizontalMoveShape(Vector3 direction, float speed)
	{
		if (Time.time - previousHorizontalTime < 0.2/speed)     //Магические числа! //Коэффициент увеличения скорости
			return;

		previousHorizontalTime = Time.time;
		CurrentShape.Move(direction);
	}

	public void VerticalMoveShape(Vector3 direction, float speed)
	{
		if (Time.time - previousVerticalTime < 0.2 / speed)			//Магические числа!
			return;
		previousVerticalTime = Time.time;
		CurrentShape.Move(direction);
	}
}
