using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.attachedRigidbody.transform.SetPositionAndRotation(new Vector3(-150, 1, -50), Quaternion.Euler(0,90,0));
            //TODO use last checkpoint position and rotation
        }
    }
}
