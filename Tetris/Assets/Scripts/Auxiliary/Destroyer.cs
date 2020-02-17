using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour, IDestroyer
{
	public void RemoveObject(GameObject removeObject)
	{
		Destroy(removeObject);
	}
}
