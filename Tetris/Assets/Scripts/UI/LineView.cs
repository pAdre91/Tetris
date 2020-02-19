using UnityEngine;
using Auxiliary;

namespace UI
{
	class LineView : MonoBehaviour, ILineView
	{
		private	TextMesh		m_lineScore;
		private	const string	m_scoreTextTemplate	=	"Line:\n";

		private void Start()
		{
			m_lineScore = gameObject.GetComponent<TextMesh>();
			m_lineScore.text = m_scoreTextTemplate + Сonstants.m_startLineCount;
		}

		public void RefreshLineView(int newLineScore)
		{
			m_lineScore.text = m_scoreTextTemplate + newLineScore;
		}
	}
}
