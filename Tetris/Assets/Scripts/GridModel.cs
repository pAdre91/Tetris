using UnityEngine;

namespace Tetris
{
	class GridModel : IGridModel
	{
		private Transform[,] m_grid;
		private byte m_width;
		private byte m_height;

		private GridModel() { }			//Может есть другой способ?
		public	GridModel(byte width, byte height)
		{
			m_grid = new Transform[width, height];
			m_width = width;
			m_height = height;
		}

		public bool IsAreaFree(byte x, byte y)
		{
			if (x >= m_width || y >= m_height)
				return false;

			if (m_grid[x, y] != null)
				return false;
			return true;
		}

		public void SetArea(byte x, byte y, Transform newObject)
		{
			m_grid[x, y] = newObject;
		}
	}
}
