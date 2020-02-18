namespace Tetris
{
	interface ITetrisController
	{
		void MoveShape(float horizontalMove, float verticalMove);
		void Rotate(int angle);
		float GetFallTime();
		void ChangeSpeed(float sign);
	}
}
