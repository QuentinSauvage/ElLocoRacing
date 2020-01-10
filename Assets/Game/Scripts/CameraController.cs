using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CameraController))]
    public class CameraController : MonoBehaviour
    {
		[SerializeField] private Camera m_middleMirror;
		private CarController m_Car; // the car controller we want to use
		private GameController m_gameController;
		public Camera m_mainCamera;
        public Camera m_BackupCamera;
        public float m_RotationAngleX = 60;
        public float m_RotationAngleY = 60;
        public float m_FoVAccelRatio = 0.05f;

        private float m_MaxRotationAngleX;
        private float m_MaxRotationAngleY;

		private void Awake()
		{
			m_gameController = GameObject.Find("Controller").GetComponent<GameController>();
		}

		private void Start()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
            m_MaxRotationAngleX = 360 - m_RotationAngleX;
            m_MaxRotationAngleY = 360 - m_RotationAngleY;
            m_BackupCamera.gameObject.SetActive(false);
        }

        public void Update()
        {
			if (!m_gameController.Pause)
			{
				m_mainCamera.fieldOfView -= m_Car.Acceleration * m_FoVAccelRatio;
			}
        }

        public void Rotate(float xMove, float yMove)
        {
            if (m_mainCamera.transform.localEulerAngles[0] - yMove < m_MaxRotationAngleY && (m_mainCamera.transform.localEulerAngles[0] - yMove > m_RotationAngleY))
                yMove = 0;
            if (m_mainCamera.transform.localEulerAngles[1] + xMove < m_MaxRotationAngleX && (m_mainCamera.transform.localEulerAngles[1] + xMove > m_RotationAngleX))
                xMove = 0;

            m_mainCamera.transform.Rotate(-yMove, xMove, 0);
		}

		public void Switch(bool keyPressed)
        {
			m_middleMirror.gameObject.SetActive(!keyPressed);
			m_mainCamera.gameObject.SetActive(!keyPressed);
			m_BackupCamera.gameObject.SetActive(keyPressed);
        }
    }
}