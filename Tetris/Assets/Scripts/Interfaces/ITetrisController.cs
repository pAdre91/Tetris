namespace Tetris
{
	interface ITetrisController
	{
		void MoveShape(float horizontalMove, float verticalMove);
		void Rotate(int angle);
	}
}
