using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{

	public GameObject win;
	Dog dog;
	public frisbycontrol controller;
	public Text high, score, challenge;
	int c;

	private void Awake()
	{
		win.SetActive(false);
		challenge.gameObject.SetActive(false);
		dog = GameObject.Find("Dog").GetComponent<Dog>();

	}
	private void OnTriggerEnter(Collider other)
	{
		
		if(other.tag=="Player")
		{
			
			dog.anim.Play("BeagleJump", -1, 0.0f);
			dog.transform.position = Vector3.MoveTowards(dog.transform.position, controller.transform.position, 2f);
			controller.LevelIndex += 1;
			
			high.text = "High Score: "+controller.highscore.ToString("000");
			score.text = "Score: "+controller.scoresayac.ToString("000");
			PlayerPrefs.SetInt("LevelIndex", controller.LevelIndex);
			PlayerPrefs.SetFloat("HighScore", controller.highscore);
			PlayerPrefs.SetInt("Gem", controller.gem);
			for (int i = 0; i<controller.challenge.Length; i++)
			{
				if (controller.challenge[i])
				{
					
				}
			}
			if (c == 8)
			{
				challenge.gameObject.SetActive(true);
				challenge.text = "You have completed the challenge!";
			}
			controller.frisbyhız = 0.9f; 
			StartCoroutine(Wait());
		}
			
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(0.85f);
		controller.enabled = false;
		Time.timeScale = 0;
		win.SetActive(true);
	}
}
