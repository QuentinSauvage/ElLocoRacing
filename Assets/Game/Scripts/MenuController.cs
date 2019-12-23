using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public struct Track
{
	private string name;
	private string path;
}

public class MenuController : MonoBehaviour
{
	private int[] laps = new int[] {1,3,5,-1};
	private Track[] tracks;
	private string[] mode = new string[] { "Time Attack", "VS CPU" };

	public void OnDisplayRace()
	{
		SceneManager.LoadSceneAsync("Track Selection");
	}

	public void OnDisplayOptions()
	{
		Debug.Log("options");
	}

	public void OnQuitGame()
	{
		Application.Quit();
	}

	public void OnChangeTrack()
	{

	}

	public void OnChangeMode()
	{

	}

	public void OnChangeLaps()
	{

	}

	public void OnStartRace()
	{
		SceneManager.LoadSceneAsync("Track1");
	}

	public void OnBack()
	{
		SceneManager.LoadSceneAsync("Main Screen");
	}
}
