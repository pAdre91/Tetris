namespace Tetris
{
	interface IScorer
	{
		void AddNewPoints(int newPoints);
		int Score { get; }
	}
}
