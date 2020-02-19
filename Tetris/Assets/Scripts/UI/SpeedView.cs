using UnityEngine;
using Auxiliary;

namespace UI
{
	public class SpeedView : MonoBehaviour, ISpeedView
	{
		private	TextMesh		m_meshSpeed;
		private	const string	m_speedTextTemplate = "Speed:\n";


		private void Start()
		{
			m_meshSpeed = gameObject.GetComponent<TextMesh>();

			m_meshSpeed.text = m_speedTextTemplate + Сonstants.m_minimalSpeed;
		}

		public void RefreshSpeedView(int newSpeed)
		{
			m_meshSpeed.text = m_speedTextTemplate + newSpeed;
		}
	}
}
