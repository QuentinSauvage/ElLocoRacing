using System;
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
		[SerializeField] private Material brakeLightsOff;
		private CarController m_Car; // the car controller we want to use
        private CameraController m_Camera;


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
            // get the camera controller
            m_Camera = GetComponent<CameraController>();
        }

		private void Update()
		{
			if (Input.GetKey(KeyCode.DownArrow))
			{
				brakeLights.material = brakeLightsOn;
			}
			else
			{
				brakeLights.material = brakeLightsOff;
			}
		}

		private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");

            // pass the input to the camera
            //if (Input.GetButton("Mouse Left"))
            //{
                m_Camera.Rotate(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            //}
            m_Camera.Switch(Input.GetButton("Mouse Right"));

#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}