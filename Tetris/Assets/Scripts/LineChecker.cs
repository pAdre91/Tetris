using System.Collections.Generic;
using UnityEngine;

namespace Tetris
{
	class LineChecker : ILineChecker
	{
		public Stack<byte> GetNumbersFilledLines(Transform[,] grid)
		{
			Stack<byte> numberFilledLines = new Stack<byte>();
			for (byte i = 0; i < grid.GetLength(1); i++)
			{
				for (byte j = 0; j < grid.GetLength(0); j++)
				{
					if (grid[j, i] == null)
						break;

					if (j == grid.GetLength(0) - 1)
						numberFilledLines.Push(i);
				}
			}
			return numberFilledLines;
		}
	}
}
