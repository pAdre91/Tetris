using UnityEngine;

namespace Tetris
{
	class Scorer : IScorer
	{
		private IScoreView m_scoreView;

		public int Score { get; private set; } = 0;

		public Scorer()
		{
			m_scoreView = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreView>();
		}

		public void AddNewPoints(int newPoints)
		{
			Score += newPoints;
			m_scoreView.RefreshScoreView(Score);
		}
	}
}
