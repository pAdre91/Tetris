using UnityEngine;
using Auxiliary;

namespace Tetris
{
	class GridModel : IGridModel
	{
		public	Transform[,]	PlayFieldGrid	{ get; private set; }

		private	byte		m_width;
		private	byte		m_height;
		private	IDestroyer	m_destroyer;

		private	GridModel() { }			//Может есть другой способ?
		public	GridModel(byte width, byte height)
		{
			PlayFieldGrid = new Transform[width, height];
			m_destroyer = GameObject.FindGameObjectWithTag("ScriptsObject").GetComponent<Destroyer>();
			m_width = width;
			m_height = height;
		}

		public bool IsAreaFree(byte x, byte y)
		{
			if (x >= m_width || y >= m_height)
				return false;

			if (PlayFieldGrid[x, y] != null)
				return false;
			return true;
		}

		public void SetArea(byte x, byte y, Transform newObject)
		{
			PlayFieldGrid[x, y] = newObject;			//Проверка и логи
		}

		public void RemoveArea(byte x, byte y)
		{
			m_destroyer.RemoveObject(PlayFieldGrid[x, y].gameObject);
			PlayFieldGrid[x, y] = null;				//Проверка и логи
		}

		public void ReplaceAreaFromGrid(int startX, int startY, int endX, int endY, Vector3 derection)
		{
			PlayFieldGrid[endX, endY] = PlayFieldGrid[startX, startY];
			PlayFieldGrid[endX, endY].position += derection;
			PlayFieldGrid[startX, startY] = null;
		}
	}
}
