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
	Animator anim;
	public int puan = 0;
	public int gem;
	public int LevelIndex=1;
	public Text puantext, gameoverScore, gemText;
	public float frisbyhız;
	public float scoresayac = 0;
	float süresayac = 0;
	public float highscore = 0;
	public Text high;
	public bool follow, left, right;
	[SerializeField] private GameObject gameOver, tutorial;

	void Awake()
	{
		LevelIndex = PlayerPrefs.GetInt("LevelIndex");
		fizik = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		gameOver.SetActive(false);
		LevelIndex = PlayerPrefs.GetInt("LevelIndex");
		follow = false;
		StartCoroutine(Wait());
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
			Camera.main.transform.position = new Vector3(transform.position.x+3, 5, 36.8f);
			Camera.main.transform.rotation = Quaternion.Euler(20f, -90f, 0);
			Camera.main.fieldOfView = 94.3f;
			fizik.velocity = -transform.right * frisbyhız;// kameranın frisbiyi takip etmesi
		}
		frisbyhız += 0.25f * Time.deltaTime;
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
	private void OnMouseDrag()
	{
		Vector3 currentpose = transform.position;
		transform.position = new Vector3(transform.position.x, transform.position.y, GetMouseWorldPos().z + mOffset.z); /// frisbiyi sağa sola kaydırma
		if (transform.position.z < currentpose.z)
		{
			if (transform.localRotation.x > -90)
			{
				transform.Rotate(-25 * Time.deltaTime, 0, 0);
			}
			
			anim.SetBool("Idle", false);
			anim.enabled = false;
			left = true;
			right = false;
		}
		else
		{
			if (transform.localRotation.x < -90)
			{
				transform.Rotate(25 * Time.deltaTime, 0, 0);
			}
				
			anim.SetBool("Idle", false);
			anim.enabled = false;
			right = true;
			left = false;
		}
	}
	private void OnMouseUp()
	{
		anim.enabled = true;
		if (right)
		{
			anim.Play("RightToMid", -1, 0.0f);
			right = false;
		}
		else if (left)
		{
			anim.Play("LeftToMid", -1, 0.0f);
			left = false;
		}
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
		yield return new WaitForSeconds(0.35f);
		follow = true;
		yield return new WaitForSeconds(1);
		if (LevelIndex == 1)
		{
			Time.timeScale = 0;
			tutorial.SetActive(true);
			if (Input.GetMouseButtonDown(0))
			{
				Time.timeScale = 1;
				tutorial.SetActive(false);
			}
		}
	}
}