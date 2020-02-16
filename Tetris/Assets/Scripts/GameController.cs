using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tetris;

public class GameController : MonoBehaviour
{
	private IInputManager		m_inputManager;
	private ILevelStater		m_levelStater;
	private ITetrisController	m_tetrisController;

	private void Start()
	{
		m_tetrisController = new TetrisController();
	}

	private void Update()
	{
		m_tetrisController.MoveShape(0, -1);			//Заглушка
	}
}
