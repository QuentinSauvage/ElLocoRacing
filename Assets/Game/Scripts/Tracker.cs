using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
	[SerializeField] private GameObject m_waypointsContainer = null;
	private Transform[] m_waypoints;
	private int m_waypointIndex = 0;
	private int m_nbWaypoints = 0;

	public void Awake()
	{
		Transform t = m_waypointsContainer.transform;
		m_nbWaypoints = t.childCount;
		m_waypoints = new Transform[m_nbWaypoints];
		for (int i = 0; i < m_nbWaypoints; ++i)
		{
			m_waypoints[i] = t.GetChild(i);
		}
		Debug.Log(m_waypoints[0].position);
		transform.position = m_waypoints[0].position;
	}

	public void OnTriggerEnter(Collider collision)
	{
		Debug.Log(collision.gameObject.tag);
		if(collision.gameObject.tag == "AI")
		{
			m_waypointIndex = (m_waypointIndex + 1) % m_nbWaypoints;
			transform.position = m_waypoints[m_waypointIndex].position;
		}
	}
}
