using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tetris;
using GameControl;

public class GameController : MonoBehaviour
{
	private IInputManager		m_inputManager;
	private ILevelStater		m_levelStater;
	private ITetrisController	m_tetrisController;

	private void Start()
	{
		m_tetrisController = new TetrisController();
		m_inputManager = new InputManager();
	}

	private void Update()
	{
		m_tetrisController.MoveShape(m_inputManager.GetHorizontalMove(), m_inputManager.GetVerticalMove());
		if (m_inputManager.GetRotate())
			m_tetrisController.Rotate(90);

	}
}
