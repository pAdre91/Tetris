using UnityEngine;

namespace Tetris
{
	class GameOverView : MonoBehaviour, IGameOverView
	{
		[SerializeField]
		GameObject m_gameOverPanel;

		public void ActivaleGameOverPanel()
		{
			m_gameOverPanel.SetActive(true);
		}

		public void DeactivaleGameOverPanel()
		{
			m_gameOverPanel.SetActive(false);
		}
	}
}
