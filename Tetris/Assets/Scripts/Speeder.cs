using UnityEngine;
using Сonstant;

namespace Tetris
{
	class Speeder : ISpeeder
	{
		private	ISpeedView	m_speedView;			//IInfoViewer?

		public int Speed { get; private set; } = Сonstants.m_minimalSpeed;

		public Speeder()
		{
			m_speedView = GameObject.FindGameObjectWithTag("Speed").GetComponent<SpeedView>();
		}

		public void IncrementSpeed()
		{
			Speed++;
			m_speedView.RefreshSpeedView(Speed);
		}

		public void DecrementSpeed()
		{
			if (Speed == Сonstants.m_minimalSpeed)
				return;

			Speed--;
			m_speedView.RefreshSpeedView(Speed);
		}
	}
}
