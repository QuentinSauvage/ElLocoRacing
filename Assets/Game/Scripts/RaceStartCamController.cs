using System.Collections;
using UnityEngine;

public class RaceStartCamController : MonoBehaviour
{

    [SerializeField] private GameObject m_1Text;
    [SerializeField] private GameObject m_2Text;
    [SerializeField] private GameObject m_3Text;

    private void Awake()
    {
        m_1Text.SetActive(false);
        m_2Text.SetActive(false);
        m_2Text.SetActive(false);
    }

    public void AnimationEnd()
    {
        
        m_1Text.SetActive(false);
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
