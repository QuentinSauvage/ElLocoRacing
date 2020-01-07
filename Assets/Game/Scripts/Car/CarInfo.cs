using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInfo : MonoBehaviour
{
	private int m_laps = 1;
	private int m_checkpoints = 0;
	//private int m_position = 0;
	[SerializeField] private GameObject m_nextCheckpoint = null;
	[SerializeField] private bool m_isIA = true;

	public int Laps { get=> m_laps; }
	public int Checkpoints { get => m_checkpoints; }

	public bool IA { get => m_isIA; }

	public GameObject Next
	{
		get => m_nextCheckpoint;
		set
		{
			m_nextCheckpoint = value;
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
}
