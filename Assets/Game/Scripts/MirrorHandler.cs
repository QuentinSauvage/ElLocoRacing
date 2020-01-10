using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorHandler : MonoBehaviour
{
	public Camera m_mirror;

	private void OnBecameVisible()
	{
		m_mirror.gameObject.SetActive(true);
	}

	private void OnBecameInvisible()
	{
		m_mirror.gameObject.SetActive(false);
	}
}
