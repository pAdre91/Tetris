using System.Collections;
using System;
using UnityEngine;
using GameInput;
using Tetris;

namespace Controllers
{
	public class GameController : MonoBehaviour
	{
		private IInputManager		m_inputManager;
		private ILevelStater		m_levelStater;
		private ITetrisController	m_tetrisController;

		private void Start()
		{
			m_tetrisController	=	new	TetrisController	();
			m_inputManager		=	new	InputManager		();
			m_levelStater		=	new	LevelStater			();

			m_tetrisController.SpawnNewShape();
			StartCoroutine(FallShape());
		}

		private void Update()
		{

			if (m_levelStater.GameContinue == false)
				return;

			m_tetrisController.MoveShapeHorizontal(m_inputManager.GetHorizontalMove());

			if (Convert.ToBoolean(m_inputManager.GetVerticalMove()))
				if (!m_tetrisController.MoveShapeVerticalByKey())
					ShapeDelivered();

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
				if (!m_tetrisController.AutoMoveShapeVertical())
					ShapeDelivered();
				yield return new WaitForSeconds(m_tetrisController.GetFallTime());
			}
		}

		private void ShapeDelivered()
		{
			if (m_tetrisController.IsCurrentShapeNew())
			{
				m_levelStater.GameContinue = false;
				StopAllCoroutines();
				return;
			}
			m_tetrisController.AddShapeToGrid();
			m_tetrisController.CheckFilledLines();
			m_tetrisController.SpawnNewShape();
		}
	}
}
