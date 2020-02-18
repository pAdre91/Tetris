interface IInputManager
{
	float GetVerticalMove();
	float GetHorizontalMove();
	float GetSpeedChange();
	bool GetDownButton(string buttonName);
	bool GetUpButton(string buttonName);
	bool GetButton(string buttonName);
}
