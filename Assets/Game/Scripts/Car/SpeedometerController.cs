using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CameraController))]

    public class SpeedometerController : MonoBehaviour
    {
        private CarController m_Car;
        [SerializeField] private GameObject m_pointer;
		private GameController m_gameController;

		private void Awake()
		{
			m_gameController = GameObject.Find("Controller").GetComponent<GameController>();
		}

		private void Start()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }

        void Update()
        {
			if (!m_gameController.Pause && !m_gameController.Finished)
			{
				m_pointer.transform.Rotate(Vector3.up * m_Car.Acceleration);
			}
        }
    }
}