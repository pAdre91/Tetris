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

		/*Старт корутины производить, когда кнопка вниз не нажата*/
		/*Как только кнопку вниз нажали, останавливать корутину*/

		/*Зделать чтение на кнопки + и - менять скорость через тетрис контроллер*/
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
