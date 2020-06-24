using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{

	public GameObject win;

	private void Awake()
	{
		win.SetActive(false);
	}
	private void OnTriggerEnter(Collider other)
	{
		frisbycontrol controller = other.GetComponent<frisbycontrol>();
		if(other.tag=="Player")
		{
			controller.LevelIndex += 1;
			Time.timeScale = 0;
			win.SetActive(true);
			PlayerPrefs.SetInt("LevelIndex", controller.LevelIndex);
			PlayerPrefs.SetFloat("HighScore", controller.highscore);
			PlayerPrefs.SetInt("Gem", controller.gem);
		}
			
	}
}
