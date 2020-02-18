using UnityEngine;

namespace Tetris
{
	class Scorer : IScorer
	{
		private int m_score = 0;
		private IScoreView m_scoreView;

		public Scorer()
		{
			m_scoreView = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreView>();
		}

		public void AddNewPoints(int newPoints)
		{
			m_score += newPoints;
			m_scoreView.RefreshScoreView(m_score);
		}
	}
}
