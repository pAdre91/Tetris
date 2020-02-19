using UnityEngine;
using UI;

using Auxiliary;

namespace Tetris
{
	class LineScorer : ILineScorer
	{
		private	IInfoView	m_lineView;

		public int LineScore { get; private set; } = Сonstants.m_startLineCount;

		public LineScorer()
		{
			m_lineView = GameObject.FindGameObjectWithTag("Line").GetComponent<LineView>();
		}

		public void AddNewLines(int newLines)
		{
			LineScore += newLines;
			m_lineView.RefreshInfo(LineScore);
		}
	}
}
