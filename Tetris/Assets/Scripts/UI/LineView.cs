using UnityEngine;

namespace Tetris
{
	class LineView : MonoBehaviour, ILineView
	{
		private	TextMesh		m_lineScore;
		private	const string	m_scoreTextTemplate	=	"Line:\n";

		private void Start()
		{
			int startedLineScore = 0;
			m_lineScore = gameObject.GetComponent<TextMesh>();
			m_lineScore.text = m_scoreTextTemplate + startedLineScore;
		}

		public void RefreshLineView(int newLineScore)
		{
			m_lineScore.text = m_scoreTextTemplate + newLineScore;
		}
	}
}
