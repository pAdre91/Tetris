using UnityEngine;
using UI;
using Auxiliary;

namespace Tetris
{
	class Scorer : IScorer
	{
		private	IInfoView	m_scoreView;

		public int Score { get; private set; } = Сonstants.m_startScore;

		public Scorer()
		{
			m_scoreView = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreView>();
		}

		public void AddNewPoints(int newPoints)
		{
			Score += newPoints;
			m_scoreView.RefreshInfo(Score);
		}
	}
}
