using UnityEngine;

interface IGridModel
{
	bool IsAreaFree(byte x, byte y);
	void SetArea(byte x, byte y, Transform newObject);
}
