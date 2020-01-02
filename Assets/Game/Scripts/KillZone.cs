using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CheckpointController))]
public class KillZone : MonoBehaviour
{
    //public CheckpointController m_ckeckpoint;

    private void Awake()
    {
        // get the car controller
        //m_ckeckpoint = GetComponent<CheckpointController>();
    }

        private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.attachedRigidbody.transform.SetPositionAndRotation(CheckpointController.m_currentCheckpoint.transform.position, CheckpointController.m_currentCheckpoint.transform.rotation);

            //TODO use last checkpoint position and rotation
        }
    }
}
