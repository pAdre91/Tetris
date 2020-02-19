using System.Collections.Generic;
using UnityEngine;

namespace Tetris
{
	interface ILineChecker
	{
		Stack<byte> GetNumbersFilledLines(Transform[,] grid);
	}
}