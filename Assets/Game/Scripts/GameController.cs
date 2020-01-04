using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    void Awake()
    {
		GameObject AIContainer = GameObject.Find("AI Container");
		int i;
        for(i = 0; i < RaceParameters.AI && i < AIContainer.transform.childCount; ++i)
		{
			GameObject ai = AIContainer.transform.GetChild(i).gameObject;
			ai.SetActive(true);
		}
		for(; i < AIContainer.transform.childCount; ++i)
		{
			GameObject ai = AIContainer.transform.GetChild(i).gameObject;
			ai.SetActive(false);
		}
    } 
}
