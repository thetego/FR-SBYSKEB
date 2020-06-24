using UnityEngine;
using UnityEngine.UI;

public class LevelItem : MonoBehaviour
{
	public bool islocked;
	public int index;
	Button but;

	private void Awake()
	{
		but = GetComponent<Button>();
		but.onClick.AddListener(EnterLevel);
	}

	public void Check()
	{
		if (index > PlayerPrefs.GetInt("LevelIndex"))
		{
			islocked = true;
			if (index == 1)
			{
				islocked = false;
			}
		}
		else
		{
			islocked = false;
		}
		if (islocked)
		{
			but.interactable = false;
		}
		else
		{
			but.interactable = true;
		}
	}
	public void EnterLevel()
	{
		Application.LoadLevel(index);
		PlayerPrefs.SetInt("LevelIndex", index);
	}
}
