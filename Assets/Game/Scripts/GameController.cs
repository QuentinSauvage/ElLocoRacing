using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
	[SerializeField] private GameObject player = null;
	[SerializeField] private HUDController m_hud = null;
	private CarInfo[] cars;
    void Awake()
    {
		GameObject AIContainer = GameObject.Find("AI Container");
		int i;
		int nbAI = (RaceParameters.AI < AIContainer.transform.childCount) ? RaceParameters.AI : AIContainer.transform.childCount;
		cars = new CarInfo[nbAI + 1];
		cars[0] = player.GetComponent<CarInfo>();
		for (i = 0; i < nbAI; ++i)
		{
			GameObject ai = AIContainer.transform.GetChild(i).gameObject;
			ai.SetActive(true);
			cars[i + 1] = ai.transform.GetChild(0).GetComponent<CarInfo>();
		}
		for(; i < AIContainer.transform.childCount; ++i)
		{
			GameObject ai = AIContainer.transform.GetChild(i).gameObject;
			ai.SetActive(false);
		}
    }

	private int CarsComparison(CarInfo c1, CarInfo c2)
	{
		if(c1.Laps > c2.Laps)
		{
			return -1;
		}
		if(c2.Laps > c1.Laps)
		{
			return 1;
		}
		if(c1.Checkpoints > c2.Checkpoints)
		{
			return -1;
		}
		if(c2.Checkpoints > c1.Checkpoints)
		{
			return 1;
		}
		float d2 = c1.DistanceNextCP();
		float d1 = c2.DistanceNextCP();
		if(d1 > d2)
		{
			return -1;
		}
		if(d2 > d1)
		{
			return 1;
		}
		return 0;
	}

	void Update()
	{
		Array.Sort(cars, CarsComparison);
		for(int i = 0; i < cars.Length; ++i)
		{
			if (!cars[i].IA)
			{
				m_hud.UpdatePosition(i + 1);
				break;
			}
		}

	}
}
