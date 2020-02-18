using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedView : MonoBehaviour, ISpeedView
{
	private TextMesh m_meshSpeed;
	private const string m_speedTextTemplate = "Speed:\n";


	private void Start()
	{
		int startedSpeed = 1;
		m_meshSpeed = gameObject.GetComponent<TextMesh>();

		m_meshSpeed.text = m_speedTextTemplate + startedSpeed;
	}

	public void RefreshSpeedView(int newSpeed)
	{
		m_meshSpeed.text = m_speedTextTemplate + newSpeed;
	}
}
