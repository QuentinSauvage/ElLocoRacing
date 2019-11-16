using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapController : MonoBehaviour
{
	[SerializeField] Transform m_car;
	private const float m_CameraRotation = 90f;

	void LateUpdate()
    {
		Vector3 cameraPosition = m_car.position;
		cameraPosition.y = transform.position.y;
		transform.position = cameraPosition;
		transform.rotation = Quaternion.Euler(m_CameraRotation,m_car.eulerAngles.y,0f);
	}
}
