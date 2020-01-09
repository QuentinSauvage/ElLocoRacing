using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CarInfo : MonoBehaviour
{
	private int m_laps = 1;
	private int m_checkpoints = 0;
	private GameObject m_currentCheckpoint;
	private GameObject m_nextWaypoint;
	private GameObject m_currentWaypoint;
	private string m_name;
	private string m_time = "";
	//private int m_position = 0;
	[SerializeField] private GameObject m_nextCheckpoint = null;
	[SerializeField] private bool m_isIA = true;

	public int Laps { get=> m_laps; }
	public int Checkpoints { get => m_checkpoints; }

	public bool IA { 
		get => m_isIA;
		set
		{
			m_isIA = value;
		}
	}

	public string Name
	{
		get => m_name;
		set
		{
			m_name = value;
		}
	}

	public string Time
	{
		get => m_time;
		set
		{
			m_time = value;
		}
	}

	public GameObject Current
	{
		get => m_currentCheckpoint;
		set
		{
			m_currentCheckpoint = value;
		}
	}

	public GameObject Next
	{
		get => m_nextCheckpoint;
		set
		{
			m_nextCheckpoint = value;
		}
	}

	public GameObject NextWaypoint
	{
		get => m_nextWaypoint;
		set
		{
			m_nextWaypoint = value;
		}
	}

	public GameObject CurrentWaypoint
	{
		get => m_currentWaypoint;
		set
		{
			m_currentWaypoint = value;
		}
	}

	public void IncreaseLaps()
	{
		++m_laps;
		m_checkpoints = 0;
	}

	public void IncreaseCheckpoints()
	{
		++m_checkpoints;
	}

	public float DistanceNextCP()
	{
		return Vector3.Distance(m_nextCheckpoint.transform.position, transform.position);
	}

	public void PredictTime(int nbLaps, int mn, int s, int ml)
	{
		CarAIControl carAI = GetComponent<CarAIControl>();
		int cpLeft = carAI.PredictTime(nbLaps - m_laps);
		float mil = cpLeft * 2000;
		mil += mn * 60000 + s * 1000 + ml;
		float min = Mathf.Floor((mil / 60000));
		mil -= min * 60000;
		float sec = Mathf.Floor((mil / 1000));
		mil -= sec * 1000;
		mil = Mathf.Floor(mil) % 100;
		Time += (min < 10) ? '0' + min + ':' : min + ':';
		Time += (sec < 10) ? '0' + sec + '.' : sec + '.';
		Time += (mil < 10) ? '0' + mil : mil;
		Time = min.ToString("F0") + ":" + sec.ToString("F0") + "." + mil.ToString("F0");
	}
}
