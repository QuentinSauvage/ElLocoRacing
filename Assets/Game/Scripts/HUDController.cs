using System;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
	[Serializable]
	public class Timer
	{
		private float milliseconds = 0;
		private float minutes = 0;
		private float seconds = 0;

		[SerializeField]
		private GameObject minutesUI = null, secondsUI = null, millisecondsUI = null;
		private TextMeshProUGUI minutesText, secondsText, millisecondsText;

		public float Minutes { get => minutes; set => minutes = value; }
		public float Seconds { get => seconds; set => seconds = value; }
		public float Milliseconds { get => milliseconds; set => milliseconds = value; }

		public void Start()
		{
			minutesText = minutesUI.GetComponent<TextMeshProUGUI>();
			secondsText = secondsUI.GetComponent<TextMeshProUGUI>();
			millisecondsText = millisecondsUI.GetComponent<TextMeshProUGUI>();
		}

		public void Update()
		{
			milliseconds += Time.deltaTime * 100;
			if(milliseconds > 99)
			{
				milliseconds = 0;
				++seconds;
				if(seconds >= 60)
				{
					seconds = 0;
					++minutes;
					minutesText.text = (minutes >= 10) ? minutes.ToString("F0") + ':' : '0' + minutes.ToString("F0") + ':';
				}
				secondsText.text = (seconds >= 10) ? seconds.ToString("F0") + '.' : '0' + seconds.ToString("F0") + '.';
			}
			millisecondsText.text = (milliseconds > 9) ? milliseconds.ToString("F0") : '0' + milliseconds.ToString("F0");
		}

		public void Reset()
		{
			minutes = seconds = milliseconds = 0;
			minutesUI.GetComponent<TextMeshProUGUI>().text = "00:";
			secondsUI.GetComponent<TextMeshProUGUI>().text = "00.";
			millisecondsUI.GetComponent<TextMeshProUGUI>().text = "00";
		}
	}

	[SerializeField]
	private int m_nbLaps;
	[SerializeField]
	private GameObject m_nbLapsUI, m_currentLapUI;
	[SerializeField]
	private Timer m_raceTimer = null, m_lapTimer = null;
	private Timer m_bestTimer;
	private TextMeshProUGUI m_currentLapText;
	private static int m_currentLap = 1;
	private bool finish = false;

	private void Start()
	{
		m_raceTimer.Start();
		m_lapTimer.Start();
		m_nbLapsUI.GetComponent<TextMeshProUGUI>().text = (m_nbLaps >= 10) ? m_nbLaps.ToString() : '0' + m_nbLaps.ToString();
		m_currentLapText = m_currentLapUI.GetComponent<TextMeshProUGUI>();
	}

	void Update()
    {
		if (!finish)
		{
			m_raceTimer.Update();
			m_lapTimer.Update();
		}
	}


	public void IncreaseNbLaps()
	{
		if (m_currentLap > m_nbLaps)
		{
			finish = true;
		}
		else
		{
			m_currentLapText.text = (++m_currentLap >= 10) ? m_currentLap.ToString() + '/' : '0' + m_currentLap.ToString() + '/';
			m_lapTimer.Reset();
		}
	}
}
