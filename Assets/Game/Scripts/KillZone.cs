using UnityEngine;

public class KillZone : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.attachedRigidbody.transform.SetPositionAndRotation(CheckpointController.m_currentCheckpoint.transform.position, CheckpointController.m_currentCheckpoint.transform.rotation);
            other.attachedRigidbody.velocity = Vector3.zero;
            other.attachedRigidbody.angularVelocity = Vector3.zero;
        }
    }
}
