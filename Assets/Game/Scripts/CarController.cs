using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float m_speed = 300.0f;
    private Rigidbody m_rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(float x, float y)
    {
        //float moveY = Mathf.Clamp(y, 0, 1);
        float moveY = 0;
        if(y > 0)
        {
            moveY = 1;
        } else if(y < 0)
        {
            moveY = -1;
        }
        moveY = moveY * m_speed;
        Debug.Log(moveY);
        m_rigidbody.AddForce(transform.forward*moveY);
    }
}
