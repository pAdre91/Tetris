using UnityEngine;

public interface IShape
{
	GameObject ShapeGameObject { get; }
	void Move(Vector3 direction);
	void Rotate(int angle);
}
