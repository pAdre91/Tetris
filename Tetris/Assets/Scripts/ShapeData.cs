using UnityEngine;

[CreateAssetMenu(menuName ="Shapes/Standart Shape", fileName = "New Shape")]
class ShapeData : ScriptableObject 
{
	[Tooltip("Основной спарйт")]
	[SerializeField] private Sprite m_mainSprite;
	public Sprite MainSprite
	{
		get { return m_mainSprite; }
	}
}
