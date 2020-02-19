using UnityEngine;
using Auxiliary;

namespace UI
{
	public class ScoreView : MonoBehaviour, IInfoView
	{
		private	TextMesh		m_meshScore;
		private	const string	m_scoreTextTemplate = "Score:\n";


		private void Start()
		{
			m_meshScore = gameObject.GetComponent<TextMesh>();

			m_meshScore.text = m_scoreTextTemplate + Сonstants.m_startScore;
		}

		public void RefreshInfo(int newScore)
		{
			m_meshScore.text = m_scoreTextTemplate + newScore;
		}
	}
}
