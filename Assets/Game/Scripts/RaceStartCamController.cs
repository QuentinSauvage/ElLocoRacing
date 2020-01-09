using System.Collections;
using UnityEngine;

public class RaceStartCamController : MonoBehaviour
{

    [SerializeField] private GameObject m_1Text;
    [SerializeField] private GameObject m_2Text;
    [SerializeField] private GameObject m_3Text;
    [SerializeField] private GameObject m_GoText;
    [SerializeField] private GameObject m_ui;
    [SerializeField] private GameObject m_pause;
    [SerializeField] private AudioClip m_beeps;

    private AudioSource m_audioSource;
    private Camera m_camera;

    private void Awake()
    {
        m_1Text.SetActive(false);
        m_2Text.SetActive(false);
        m_2Text.SetActive(false);
        m_GoText.SetActive(false);
        m_audioSource = GetComponent<AudioSource>();
        m_camera = GetComponent<Camera>();
    }

    public void AnimationStart()
    {
        m_audioSource.PlayOneShot(m_beeps);
    }

    public IEnumerator AnimationEnd()
    {
        GameController gameController = GameObject.Find("Controller").GetComponent<GameController>();
        gameController.Pause = false;
        gameController.Unpause = true;
        m_GoText.SetActive(true);
        m_1Text.SetActive(false);
        m_ui.SetActive(true);
        m_pause.SetActive(false);
        m_camera.enabled = false;
        yield return StartCoroutine(LateEnd());
    }

    IEnumerator LateEnd()
    {
        yield return new WaitForSeconds(1);
        m_GoText.SetActive(false);
        gameObject.SetActive(false);
        
    }

    public void print1()
    {
        m_1Text.SetActive(true);
        m_2Text.SetActive(false);
        m_3Text.SetActive(false);
    }

    public void print2()
    {
        m_2Text.SetActive(true);
        m_3Text.SetActive(false);
    }

    public void print3()
    {
        m_3Text.SetActive(true);
    }

}
