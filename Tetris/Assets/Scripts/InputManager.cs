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
	}
}
