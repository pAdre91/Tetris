using UnityEngine;

public class ShapePositionCoordinator : IShapePositionCoordinator
{
	public IShape CurrentShape { set; get; }            //Может убрать, а  метода просто передавать конкретную фигуру?

	private	float	previousVerticalTime	=	0f;
	private	float	previousHorizontalTime	=	0f;

	public void HorizontalMoveShape(Vector3 direction, float fallTime)
	{
		if (Time.time - previousHorizontalTime < fallTime)     //Магические числа! //Коэффициент увеличения скорости
			return;

		previousHorizontalTime = Time.time;
		CurrentShape.Move(direction);
	}

	public void VerticalMoveShape(Vector3 direction, float fallTime)
	{
		if (!IsShapeCanFallByTime(fallTime))
			return;
		previousVerticalTime = Time.time;
		CurrentShape.Move(direction);
	}

	public void RotateShape(int angle)
	{
		CurrentShape.Rotate(angle);
	}

	public bool IsShapeCanFallByTime(float fallTime)
	{
		if (Time.time - previousVerticalTime < fallTime)         //Магические числа!
			return false;
		return true;
	}

	public bool IsCurrentShapeNew()
	{
		return CurrentShape.IsShapeNew();
	}
}
