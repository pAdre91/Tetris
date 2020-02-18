using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Tetris
{
	class Speeder : ISpeeder
	{
		private ISpeedView m_speedView;			//IInfoViewer?

		public int Speed { get; private set; } = 1;

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
			if (Speed == 1)
				return;

			Speed--;
			m_speedView.RefreshSpeedView(Speed);
		}
	}
}
