namespace Tetris
{
	interface ILineScorer
	{
		void AddNewLines(int newLines);
		int LineScore { get; }
	}
}
