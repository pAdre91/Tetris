using UnityEngine;
using Auxiliary;
using UI;

namespace Tetris
{
	class Speeder : ISpeeder
	{
		private	IInfoView	m_speedView;

		public int Speed { get; private set; } = Сonstants.m_minimalSpeed;

		public Speeder()
		{
			m_speedView = GameObject.FindGameObjectWithTag("Speed").GetComponent<SpeedView>();
		}

		public void IncrementSpeed()
		{
			Speed++;
			m_speedView.RefreshInfo(Speed);
		}

		public void DecrementSpeed()
		{
			if (Speed == Сonstants.m_minimalSpeed)
				return;

			Speed--;
			m_speedView.RefreshInfo(Speed);
		}
	}
}
