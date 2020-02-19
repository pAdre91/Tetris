using UnityEngine;

namespace Tetris
{
	interface IShapeQueueGenerator
	{
		GameObject GetNewShape();
		GameObject AddRandomShapeData();
	}
}
