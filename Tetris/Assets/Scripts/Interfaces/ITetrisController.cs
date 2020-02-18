namespace Tetris
{
	interface ITetrisController
	{
		bool MoveShapeVerticalByKey();
		bool AutoMoveShapeVertical();
		void MoveShapeHorizontal(float horizontalMove);
		void Rotate(int angle);
		float GetFallTime();
		void ChangeSpeed(float sign);
		void AddShapeToGrid();
		void CheckFilledLines();
		void SpawnNewShape();
		bool IsCurrentShapeNew();
	}
}
