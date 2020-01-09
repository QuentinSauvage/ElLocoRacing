using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class KillZone : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" )
        {
			if (other.GetComponent<CarAIControl>() != null)
			{
				CarInfo carInfo = other.transform.parent.parent.GetComponent<CarInfo>();
				Vector3 randPosition = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
				randPosition += carInfo.NextWaypoint.transform.position;
				other.attachedRigidbody.transform.SetPositionAndRotation(randPosition, transform.rotation);
				other.attachedRigidbody.velocity = Vector3.zero;
				other.attachedRigidbody.transform.LookAt(carInfo.NextWaypoint.transform.position);
				other.attachedRigidbody.angularVelocity = Vector3.zero;
			}
			else
			{
				other.attachedRigidbody.transform.SetPositionAndRotation(CheckpointController.m_currentCheckpoint.transform.position, CheckpointController.m_currentCheckpoint.transform.rotation);
				other.attachedRigidbody.velocity = Vector3.zero;
				other.attachedRigidbody.angularVelocity = Vector3.zero;
			}
            
        }
		else if (other.gameObject.tag.StartsWith("AI"))
		{
			CarInfo carInfo = other.transform.parent.parent.GetComponent<CarInfo>();
			Vector3 randPosition = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
			randPosition += carInfo.Current.transform.position;
			other.attachedRigidbody.transform.SetPositionAndRotation(randPosition, transform.rotation);
			other.attachedRigidbody.velocity = Vector3.zero;
			other.attachedRigidbody.transform.LookAt(carInfo.NextWaypoint.transform.position);
			other.attachedRigidbody.angularVelocity = Vector3.zero;
		}
    }
}
