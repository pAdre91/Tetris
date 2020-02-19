using UnityEngine;

namespace Auxiliary
{
	public class Destroyer : MonoBehaviour, IDestroyer
	{
		public void RemoveObject(GameObject removeObject)
		{
			Destroy(removeObject);
		}
	}
}
