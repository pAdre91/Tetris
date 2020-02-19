namespace Controllers
{
	interface ISwitcher
	{
		void EarnPoints(int filledLineCount);
		void SwitchSpeed();
		int GetSpeed();
		void ChangeSpeed(bool isIncrement);
	}
}
