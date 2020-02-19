namespace Tetris
{
	interface ISpeeder
	{
		void IncrementSpeed();
		void DecrementSpeed();
		int Speed { get; }
	}
}
