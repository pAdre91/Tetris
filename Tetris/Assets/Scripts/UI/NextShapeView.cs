using UnityEngine;

namespace Tetris
{
	class NextShapeView : MonoBehaviour, INextShapeView
	{
		[SerializeField]
		private	GameObject	m_nextShapeSpawner;
		private	GameObject	m_currentShape;

		public void CreateNewShape(GameObject newShape)
		{
			if (m_currentShape)
				Destroy(m_currentShape);
			m_currentShape = Instantiate(newShape, m_nextShapeSpawner.transform.position, Quaternion.identity);
		}
	}
}
