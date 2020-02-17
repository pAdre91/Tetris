using UnityEngine;

interface IGridModel
{
	Transform[,] PlayFieldGrid { get; }
	bool IsAreaFree(byte x, byte y);
	void SetArea(byte x, byte y, Transform newObject);
	void RemoveArea(byte x, byte y);
}
