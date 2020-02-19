using UnityEngine;

namespace Tetris
{
	class LevelStater : ILevelStater
	{
		private	bool			m_gameContinue	=	true;
		private	IGameOverView	m_gameOverView;

		public LevelStater()
		{
			m_gameOverView = GameObject.FindGameObjectWithTag("GameOver").GetComponent<GameOverView>();
			m_gameOverView.DeactivaleGameOverPanel();
		}

		public bool GameContinue
		{
			get
			{
				return m_gameContinue;
			}

			set
			{
				if (value == true)
					m_gameOverView.DeactivaleGameOverPanel();
				else
					m_gameOverView.ActivaleGameOverPanel();
				m_gameContinue = value;
			}
		}
	}
}
