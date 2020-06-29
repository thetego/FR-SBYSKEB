using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	frisbycontrol controller;

	private void Awake()
	{
		controller = GameObject.FindWithTag("Player").GetComponent<frisbycontrol>();
	}
	public void NextLevel()
	{
		Application.LoadLevel(PlayerPrefs.GetInt("LevelIndex"));
		Time.timeScale = 1;
	}
	public void Retry()
	{
		Application.LoadLevel("Level 5");
		Time.timeScale = 1;
		controller.enabled = true;
	}
	public void MainMenu()
	{
		PlayerPrefs.SetInt("LevelIndex",controller.LevelIndex);
		Application.LoadLevel("MainMenu");
	}
}
