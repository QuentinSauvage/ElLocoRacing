using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]
    [RequireComponent(typeof(CameraController))]
    public class CarUserControl : MonoBehaviour
    {
        [SerializeField] private Renderer brakeLights;
        [SerializeField] private Material brakeLightsOn;
        [SerializeField] private Light TailLightLeftSpot;
        [SerializeField] private Light TailLightRightSpot;
        [SerializeField] private Material brakeLightsOff;
        private CarController m_Car; // the car controller we want to use
        private CameraController m_Camera;
		private GameController m_gameController;
		private Rigidbody m_rigidbody;

		private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
            // get the camera controller
            m_Camera = GetComponent<CameraController>();
			m_gameController = GameObject.Find("Controller").GetComponent<GameController>();
			m_rigidbody = GetComponent<Rigidbody>();
		}

        private void Update()
        {
			if (!m_gameController.Pause && !m_gameController.Finished)
			{
				if (Input.GetAxis("Vertical") < 0f)
				{
					brakeLights.material = brakeLightsOn;
					TailLightLeftSpot.gameObject.SetActive(true);
					TailLightRightSpot.gameObject.SetActive(true);
					//Debug.Log("Activation");
				}
				else
				{
					brakeLights.material = brakeLightsOff;
					TailLightLeftSpot.gameObject.SetActive(false);
					TailLightRightSpot.gameObject.SetActive(false);
				}
				if(Input.GetButton("Reset"))
				{
					m_rigidbody.transform.SetPositionAndRotation(CheckpointController.m_currentCheckpoint.transform.position, CheckpointController.m_currentCheckpoint.transform.rotation);
					m_rigidbody.velocity = Vector3.zero;
					m_rigidbody.angularVelocity = Vector3.zero;
				}
			}
			if (Input.GetButtonDown("Pause"))
			{
				m_gameController.PauseGame();
			}
		}

		private void FixedUpdate()
		{
			if (!m_gameController.Pause && !m_gameController.Finished)
			{
				// pass the input to the car!
				float h = CrossPlatformInputManager.GetAxis("Horizontal");
				float v = CrossPlatformInputManager.GetAxis("Vertical");

				// pass the input to the camera
				if (Input.GetButton("Mouse Left"))
				{
					m_Camera.Rotate(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
				}
				m_Camera.Rotate(Input.GetAxis("Joystick X"), Input.GetAxis("Joystick Y"));

				m_Camera.Switch(Input.GetButton("Mouse Right"));

#if !MOBILE_INPUT
				float handbrake = Input.GetAxis("Handbreak");
				m_Car.Move(h, v, v, handbrake);
#else
				m_Car.Move(h, v, v, 0f);
#endif
			}
		}
    }
}