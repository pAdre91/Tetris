using System.Collections.Generic;
using UnityEngine;

namespace Tetris
{
	class ShapeQueueGenerator : IShapeQueueGenerator
	{
		private const int			m_queueСapacity = 2;
		private Queue<ShapeData>	m_shapesQueue = new Queue<ShapeData>();
		private ShapeData[]			m_shapePrefabs;

		public ShapeQueueGenerator()
		{
			FindAllAssets();
			InitQueue(m_queueСapacity);
		}

		public ShapeData GetNewShape()
		{
			return m_shapesQueue.Dequeue();
		}

		private void FindAllAssets()
		{
			m_shapePrefabs = Resources.LoadAll<ShapeData>("Shapes");
		}

		private void InitQueue(int countShapes)
		{
			for (int i = 0; i < countShapes; i++)
				AddRandomShapeData();
		}

		private void AddRandomShapeData()
		{
			m_shapesQueue.Enqueue(m_shapePrefabs[Random.Range(0, m_shapePrefabs.Length)]);
		}
	}
}
