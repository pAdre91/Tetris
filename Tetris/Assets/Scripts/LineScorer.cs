using UnityEngine;
using UI;

namespace Tetris
{
	class LineScorer : ILineScorer
	{
		private	ILineView	m_lineView;

		public int LineScore { get; private set; } = 0;

		public LineScorer()
		{
			m_lineView = GameObject.FindGameObjectWithTag("Line").GetComponent<LineView>();
		}

		public void AddNewLines(int newLines)
		{
			LineScore += newLines;
			m_lineView.RefreshLineView(LineScore);
		}
	}
}
