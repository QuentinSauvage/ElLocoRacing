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
		else if (other.gameObject.tag.StartsWith("AI"))
		{
			CarInfo carInfo = other.transform.parent.parent.GetComponent<CarInfo>();
			other.attachedRigidbody.transform.SetPositionAndRotation(carInfo.Current.transform.position, carInfo.Current.transform.rotation);
            other.attachedRigidbody.velocity = Vector3.zero;
            other.attachedRigidbody.angularVelocity = Vector3.zero;
		}
    }
}
