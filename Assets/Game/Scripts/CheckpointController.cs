using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
	public bool m_endLapCheckpoint;
	public GameObject m_nextCheckpoint;
	public GameObject m_ui;
	public static GameObject m_currentCheckpoint;

	private HUDController m_hud;

	private void Awake()
	{
		m_hud = m_ui.GetComponent<HUDController>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (m_endLapCheckpoint)
			{
				m_hud.IncreaseNbLaps();
			}
			m_nextCheckpoint.SetActive(true);
			m_currentCheckpoint = this.gameObject;
			this.gameObject.SetActive(false);
		}
	}
}
