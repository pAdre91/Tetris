using UnityEngine;

namespace Controllers
{
	interface IShapeQueueController
	{
		void AddRandomShape();
		GameObject GetNewShape();
	}
}
