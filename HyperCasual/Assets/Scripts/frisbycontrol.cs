using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class frisbycontrol : MonoBehaviour
{
	private Vector3 mOffset;

	private float mZCoord;
	Rigidbody fizik;
	public int puan = 0;
	public int gem;
	public int LevelIndex=1;
	public Text puantext, gameoverScore, gemText;
	public float frisbyhız;
	float scoresayac = 0;
	float süresayac = 0;
	public float highscore = 0;
	public Text high;
	bool follow;
	[SerializeField] private GameObject gameOver, tutorial;

	void Awake()
	{
		LevelIndex = PlayerPrefs.GetInt("LevelIndex");
		fizik = GetComponent<Rigidbody>();
		gameOver.SetActive(false);
		LevelIndex = PlayerPrefs.GetInt("LevelIndex");
		follow = false;
		StartCoroutine(Wait());
		if (LevelIndex == 1)
		{
			tutorial.SetActive(true);
			Time.timeScale = 0;
		}
	}

	private void OnMouseDown()
	{
		mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
		mOffset = gameObject.transform.position - GetMouseWorldPos();
	}



	private Vector3 GetMouseWorldPos()
	{
		Vector3 mousePoint = Input.mousePosition;

		mousePoint.z = mZCoord;

		return Camera.main.ScreenToWorldPoint(mousePoint);
	}

	void Update()
	{
		if (follow)
		{
			Camera.main.transform.position = new Vector3(transform.position.x + 3, 4.960916f, 36.7752f);
			Camera.main.transform.rotation = Quaternion.Euler(20.662f, -86.872f, -0.001f);
			fizik.velocity = -transform.right * frisbyhız;// kameranın frisbiyi takip etmesi
		}
		if (Input.GetMouseButton(0))
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, GetMouseWorldPos().z + mOffset.z); /// frisbiyi sağa sola kaydırma
		}
		
		süresayac += Time.deltaTime;
		scoresayac = süresayac * 10;
		puantext.text = "Score: "+scoresayac.ToString("000"); //skoru ekrana 3 basamaklı yazdırma
		gemText.text = "Gem: "+gem.ToString("000"); //gem ekrana 3 basamaklı yazdırma
		if (scoresayac > highscore)
		{

			highscore = süresayac;

		}
		high.text = "High Score: " + highscore.ToString("000");
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "engel")
        {
            gameOver.SetActive(true);
            //frisbyhız = 0;
            //süresayac = 0;
            gameoverScore.text = "Score: " + scoresayac.ToString("000");
            Time.timeScale = 0;
            this.enabled = false;
        }
    }
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(0.7f);
		follow = true;
		
	}
}