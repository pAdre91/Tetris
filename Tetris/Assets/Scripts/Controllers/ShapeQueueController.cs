using UnityEngine;

namespace Tetris
{
	class ShapeQueueController : IShapeQueueController
	{
		IShapeQueueGenerator	m_shapeQueueGenerator;
		INextShapeView			m_nextShapeView;

		public ShapeQueueController()
		{
			m_shapeQueueGenerator	=	new	ShapeQueueGenerator	();
			m_nextShapeView			=	GameObject.FindGameObjectWithTag("ShapeView").GetComponent<NextShapeView>();
		}

		public GameObject GetNewShape()
		{
			return m_shapeQueueGenerator.GetNewShape();
		}

		public void AddRandomShape()
		{
			m_nextShapeView.CreateNewShape(m_shapeQueueGenerator.AddRandomShapeData());
		}
	}
}
