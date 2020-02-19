using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreView : MonoBehaviour, IScoreView
{
	private	TextMesh		m_meshScore;
	private	const string	m_scoreTextTemplate	=	"Score:\n";


	private void Start()
	{
		int startedScore = 0;
		m_meshScore = gameObject.GetComponent<TextMesh>();

		m_meshScore.text = m_scoreTextTemplate + startedScore;
	}

	public void RefreshScoreView(int newScore)
	{
		m_meshScore.text = m_scoreTextTemplate + newScore;
	}
}