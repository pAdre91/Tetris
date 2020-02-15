using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour, ISwitcher
{
	ISpeeder	m_speeder;
	IScorer		m_scorer;
}
