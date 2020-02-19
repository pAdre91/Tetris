using Tetris;

enum PointsForFiledLines
{
	OneLine		=	10,
	TwoLines	=	30,
	ThreeLines	=	60,
	FourLines	=	100
}

public class Switcher : ISwitcher
{
	private	ISpeeder	m_speeder;
	private	IScorer		m_scorer;
	private	int			m_oldStageScore = 100;

	public Switcher()
	{
		m_scorer	=	new	Scorer	();
		m_speeder	=	new	Speeder	();
	}

	public void EarnPoints(int filledLineCount)
	{
		switch (filledLineCount)        //Логи?
		{
			case 1: m_scorer.AddNewPoints((int)PointsForFiledLines.OneLine); break;
			case 2: m_scorer.AddNewPoints((int)PointsForFiledLines.TwoLines); break;
			case 3: m_scorer.AddNewPoints((int)PointsForFiledLines.ThreeLines); break;
			case 4: m_scorer.AddNewPoints((int)PointsForFiledLines.FourLines); break;
		}
	}

	public void SwitchSpeed()
	{
		if (m_scorer.Score < m_oldStageScore * 2)
			return;

		m_oldStageScore *= 2;
		m_speeder.IncrementSpeed();
	}

	public int GetSpeed()
	{
		return m_speeder.Speed;
	}

	public void ChangeSpeed(bool isIncrement)
	{
		if (isIncrement)
		{
			m_speeder.IncrementSpeed();
			return;
		}

		m_speeder.DecrementSpeed();
	}
}
