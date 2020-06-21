using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
	[SerializeField] private Slider[] sliders;
	public AudioSource[] src;
	bool TR, ENG;
	MainMenu mm;

	private void Awake()
	{
		mm = GetComponent<MainMenu>();
	}

	private void LateUpdate()
	{
		src[0].volume = sliders[0].value;//music
		src[1].volume = sliders[1].value;//sound

		if (TR)
		{
			mm.TR();
		}
		else if (ENG) 
		{
			mm.ENG();
		}
	}

}
