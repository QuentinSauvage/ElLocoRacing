using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCursor : MonoBehaviour
{
	public GameObject m_car;
    // Start is called before the first frame update
    void Start()
    {
        if(!m_car.activeSelf)
		{
			gameObject.SetActive(false);
		}
    }

    // Update is called once per frame
    void Update()
    {
		transform.position = new Vector3(m_car.transform.position.x, m_car.transform.position.y + 1, m_car.transform.position.z);
    }
}
