using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{

	public GameObject win;
	Dog dog;
	public frisbycontrol controller;
	public Text high, score;

	private void Awake()
	{
		win.SetActive(false);
		dog = GameObject.Find("Dog").GetComponent<Dog>();

	}
	private void OnTriggerEnter(Collider other)
	{
		
		if(other.tag=="Player")
		{
			controller.frisbyhız = 0.1f;
			dog.anim.Play("BeagleJump", -1, 0.0f);
			dog.transform.position = Vector3.MoveTowards(dog.transform.position, controller.transform.position, 2f);
			controller.LevelIndex += 1;
			win.SetActive(true);
			high.text = "High Score: "+controller.highscore.ToString("000");
			score.text = "Score: "+controller.scoresayac.ToString("000");
			PlayerPrefs.SetInt("LevelIndex", controller.LevelIndex);
			PlayerPrefs.SetFloat("HighScore", controller.highscore);
			PlayerPrefs.SetInt("Gem", controller.gem);
			StartCoroutine(Wait());
		}
			
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(1.3f);
		controller.enabled = false;
		Time.timeScale = 0;
	}
}
