﻿using UnityEngine;

namespace Tetris
{
	public interface IShape
	{
		GameObject ShapeGameObject { get; }
		Vector3 RotationPoint { get; }
		void Move(Vector3 direction);
		void Rotate(int angle);
		bool IsShapeNew();
	}
}
