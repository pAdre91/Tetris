using UnityEngine;

namespace GameInput
{		/*Все ли используется?*/
	class InputManager : IInputManager
	{
		public float GetVerticalMove()
		{
			return Input.GetAxisRaw("Vertical");
		}

		public float GetHorizontalMove()
		{
			return Input.GetAxisRaw("Horizontal");
		}

		public float GetSpeedChange()
		{
			return Input.GetAxisRaw("Speed");
		}

		public bool GetDownButton(string buttonName)
		{
			return Input.GetButtonDown(buttonName);
		}

		public bool GetUpButton(string buttonName)
		{
			return Input.GetButtonUp(buttonName);
		}

		public bool GetButton(string buttonName)
		{
			return Input.GetButton(buttonName);
		}
	}
}
