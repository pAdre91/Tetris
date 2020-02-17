using System.Collections.Generic;
using UnityEngine;

interface ILineChecker
{
	Stack<byte> GetNumbersFilledLines(Transform[,] grid);
}