﻿using UnityEngine;
using Auxiliary;

namespace Tetris
{
	public class ShapePositionCoordinator : IShapePositionCoordinator
	{
		public	IShape CurrentShape { set; get; }

		private	float	previousVerticalTime	=	0f;
		private	float	previousHorizontalTime	=	0f;

		public void HorizontalMoveShape(Vector3 direction)
		{
			if (Time.time - previousHorizontalTime < Сonstants.m_timeHorizontMove)
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
			if (Time.time - previousVerticalTime < fallTime)
				return false;
			return true;
		}

		public bool IsCurrentShapeNew()
		{
			return CurrentShape.IsShapeNew();
		}
	}
}
