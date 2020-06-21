using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	public GameObject[] menus;
	public GameObject Tr, Eng;

	public void Play()
	{
		menus[0].SetActive(false);//mainmenu
		menus[1].SetActive(true);//levelselector
		menus[2].SetActive(false);//settings
		menus[3].SetActive(false);//market
	}
	public void Settings()
	{
		menus[0].SetActive(false);//mainmenu
		menus[1].SetActive(false);//levelselector
		menus[2].SetActive(true);//settings
		menus[3].SetActive(false);//market
	}
	public void Market()
	{
		menus[0].SetActive(false);//mainmenu
		menus[1].SetActive(false);//levelselector
		menus[2].SetActive(false);//settings
		menus[3].SetActive(true);//market
	}
	public void Back()
	{
		menus[0].SetActive(true);//mainmenu
		menus[1].SetActive(false);//levelselector
		menus[2].SetActive(false);//settings
		menus[3].SetActive(false);//market
	}
	public void Quit()
	{
		Application.Quit();
	}
	public void ENG()
	{
		Tr.SetActive(false);
		Eng.SetActive(true);
	}
	public void TR()
	{
		Tr.SetActive(true);
		Eng.SetActive(false);
	}

}
