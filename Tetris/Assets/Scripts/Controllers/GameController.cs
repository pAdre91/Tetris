using System.Collections;
using UnityEngine;
using Tetris;
using GameControl;

public class GameController : MonoBehaviour
{
	private IInputManager m_inputManager;
	private ILevelStater m_levelStater;
	private ITetrisController m_tetrisController;

	private void Start()
	{
		m_tetrisController = new TetrisController();
		m_inputManager = new InputManager();

		StartCoroutine(FallShape());
	}

	private void Update()
	{
		m_tetrisController.MoveShape(m_inputManager.GetHorizontalMove(), m_inputManager.GetVerticalMove());

		if (m_inputManager.GetDownButton("Rotate"))
			m_tetrisController.Rotate(90);

		if (m_inputManager.GetDownButton("Vertical"))
			StopAllCoroutines();
		if (m_inputManager.GetUpButton("Vertical"))
			StartCoroutine(FallShape());
		if (m_inputManager.GetDownButton("Speed"))
			m_tetrisController.ChangeSpeed(m_inputManager.GetSpeedChange());
	}

	private IEnumerator FallShape()
	{
		while (true)
		{
			m_tetrisController.MoveShape(0, -1);
			yield return new WaitForSeconds(m_tetrisController.GetFallTime());
		}
	}
}
