using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public struct Track
{
	private string name;
	private string path;
}

public class MenuController : MonoBehaviour
{
	private int[] lapsValues = new int[] {1,3,5,-1};
	private string[] laps = new string[] {"1 lap", "3 laps", "5 laps", "Infinite"};
	private List<string> tracks = new List<string>();
	private string[] modes = new string[] { "Time Attack", "VS CPU" };
	private int tracksIndex = 0, modesIndex = 0, lapsIndex = 0;
	[SerializeField] private TextMeshProUGUI tracksText, modesText, lapsText;

	private void Awake()
	{
		//need to retrieve all existing tracks in a list of tracks
		tracks.Add("Track1");
		tracks.Add("Track2");
		//tracksText.text = tracks[0];
		//modesText.text = modes[0];
		//lapsText.text = laps[0];
	}

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

	public void OnLeftTrack()
	{
		tracksIndex = (tracksIndex - 1 + tracks.Count) % tracks.Count;
		tracksText.text = tracks[tracksIndex];
	}

	public void OnRightTrack()
	{
		tracksIndex = (tracksIndex + 1 + tracks.Count) % tracks.Count;
		tracksText.text = tracks[tracksIndex];
	}

	public void OnLeftMode()
	{
		modesIndex = (modesIndex - 1 + modes.Length) % modes.Length;
		modesText.text = modes[modesIndex];
	}

	public void OnRightMode()
	{
		modesIndex = (modesIndex + 1 + modes.Length) % modes.Length;
		modesText.text = modes[modesIndex];
	}

	public void OnLeftLaps()
	{
		lapsIndex = (lapsIndex - 1 + laps.Length) % laps.Length;
		lapsText.text = laps[lapsIndex];
	}

	public void OnRightLaps()
	{
		lapsIndex = (lapsIndex + 1 + laps.Length) % laps.Length;
		lapsText.text = laps[lapsIndex];
	}

	public void OnStartRace()
	{
		RaceParameters.AI = (modesIndex == 1);
		RaceParameters.nbLaps = lapsValues[lapsIndex];
		SceneManager.LoadSceneAsync(tracks[tracksIndex]);
	}

	public void OnBack()
	{
		SceneManager.LoadSceneAsync("Main Screen");
	}
}
