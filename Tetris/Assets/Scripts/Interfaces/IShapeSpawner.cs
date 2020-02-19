using UnityEngine;

namespace Tetris
{
	interface IShapeSpawner
	{
		GameObject SpawnShape(GameObject ShapePrefab);
	}
}
