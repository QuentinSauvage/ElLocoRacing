using UnityEngine;

public class CheckpointController : MonoBehaviour
{
	public bool m_endLapCheckpoint;
	public GameObject m_nextCheckpoint;
	public GameObject m_ui;
	private HUDController m_hud;

	public static GameObject m_currentCheckpoint = null;

	 void Awake()
	{
		m_hud = m_ui.GetComponent<HUDController>();
		if (m_currentCheckpoint == null)
		{
			m_currentCheckpoint = GameObject.Find("Checkpoints").transform.GetChild(0).gameObject;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		CarInfo info = other.transform.parent.parent.GetComponent<CarInfo>();
		if (info != null)
		{
			if (info.Next == this.gameObject)
			{
				info.Next = m_nextCheckpoint;
				if(m_endLapCheckpoint)
				{
					info.IncreaseLaps();
					if (other.gameObject.tag == "Player")
					{
						m_currentCheckpoint = this.gameObject;
						m_hud.UpdateLaps();
					}
				}
				else
				{
					if (other.gameObject.tag == "Player")
					{
						m_currentCheckpoint = this.gameObject;
					}
					info.IncreaseCheckpoints();
				}
			}
		}
	}
}
