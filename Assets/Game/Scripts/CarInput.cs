using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInput : MonoBehaviour
{
    CarController m_carController;
    // Start is called before the first frame update
    void Start()
    {
        m_carController = GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        m_carController.Move(x, y);
    }
}
