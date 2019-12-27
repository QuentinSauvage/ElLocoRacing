using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class MainScreenButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

	private TextMeshProUGUI m_text;
	private Image m_image;
	public Color m_buttonColor1, m_buttonColor2, m_textColor1, m_textColor2;

	private void Awake()
	{
		m_text = GetComponentInChildren<TextMeshProUGUI>();
		m_image = GetComponent<Image>();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		m_image.color = m_buttonColor1;
		m_text.color = m_textColor1;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		m_image.color = m_buttonColor2;
		m_text.color = m_textColor2;
	}
}