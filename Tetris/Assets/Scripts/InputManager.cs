using UnityEngine;

namespace GameControl
{
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

		public bool GetDownButton(string buttonName)
		{
			return Input.GetButtonDown(buttonName);
		}

		public bool GetUpButton(string buttonName)
		{
			return Input.GetButtonUp(buttonName);
		}
	}
}
