using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	public static int levelIndex = 1;
	frisbycontrol controller;

	private void Awake()
	{
		controller = GameObject.FindWithTag("Player").GetComponent<frisbycontrol>();
	}
	public void Retry()
	{
		Application.LoadLevel("Level 1");
		Time.timeScale = 1;
		controller.enabled = true;
	}
	public void MainMenu()
	{
		Application.LoadLevel("MainMenu");
	}
}
