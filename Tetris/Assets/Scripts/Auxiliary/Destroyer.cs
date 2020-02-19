using UnityEngine;

namespace Auxiliary
{
	public class Destroyer : MonoBehaviour, IDestroyer
	{
		public void RemoveBrick(GameObject removeObject)
		{
			Transform parent = removeObject.transform.parent;

			if (parent.transform.childCount == 1)
			{
				Destroy(removeObject);
				Destroy(parent.gameObject);
			}

			DestroyImmediate(removeObject);
		}
	}
}
