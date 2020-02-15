using UnityEngine;

namespace Tetris
{
	class ShapeSpawner :MonoBehaviour, IShapeSpawner
	{
		public GameObject SpawnShape(GameObject ShapePrefab)
		{
			return Instantiate(ShapePrefab, gameObject.transform.position, Quaternion.identity);
		}
	}
}
