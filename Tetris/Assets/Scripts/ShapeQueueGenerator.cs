using System.Collections.Generic;
using UnityEngine;
using Auxiliary;

namespace Tetris
{
	class ShapeQueueGenerator : IShapeQueueGenerator
	{
		private Queue<GameObject>	m_shapesQueue	=	new Queue<GameObject>();
		private GameObject[]		m_shapePrefabs;

		public ShapeQueueGenerator()
		{
			FindAllAssets();
			InitQueue(Сonstants.m_queueСapacity);
		}

		public GameObject GetNewShape()
		{
			return m_shapesQueue.Dequeue();
		}

		private void FindAllAssets()
		{
			m_shapePrefabs = Resources.LoadAll<GameObject>("Shape");
		}

		private void InitQueue(int countShapes)
		{
			for (int i = 0; i < countShapes; i++)
				AddRandomShapeData();
		}

		public GameObject AddRandomShapeData()
		{
			m_shapesQueue.Enqueue(m_shapePrefabs[Random.Range(0, m_shapePrefabs.Length)]);
			return m_shapesQueue.Peek();
		}
	}
}
