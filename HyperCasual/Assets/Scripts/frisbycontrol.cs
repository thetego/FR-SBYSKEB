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
	Animator anim, anim2;
	public int puan = 0;
	public int gem, comboCounter, throwPower, posIndex;
	public int LevelIndex=1;
	public Text puantext, gameoverScore, gemText;
	public float frisbyhız;
	public float scoresayac = 0;
	float süresayac = 0;
	public float highscore = 0;
	public float timer;
	public Text high, comboT;
	public bool follow, left, right, combo, throwv;
	[SerializeField] private GameObject gameOver, tutorial;
	public GameObject handle, main, chara;
	public Transform[] target;
	public Transform level;
	public bool[] challenge;

	void Awake()
	{
		LevelIndex = PlayerPrefs.GetInt("LevelIndex");
		fizik = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		anim2 = chara.GetComponent<Animator>();
		gameOver.SetActive(false);
		LevelIndex = PlayerPrefs.GetInt("LevelIndex");
		highscore = PlayerPrefs.GetFloat("HighScore");
		follow = false;
		throwv = true;
		for(int i =0; i<challenge.Length; i++)
		{
			challenge[i] = false;
		}
		//StartCoroutine(Wait());
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
		if (throwv) 
		{
			main.gameObject.SetActive(true);
			if (Vector3.Distance(target[posIndex].position, handle.transform.position) < .2f)
			{
				posIndex++;
				if (posIndex >= target.Length)
				{
					posIndex = 0;
				}
			}
			handle.transform.position = Vector3.MoveTowards(handle.transform.position, target[posIndex].position, 500 * Time.deltaTime);
			if (Input.GetMouseButtonDown(0))
			{
				handle.transform.position = handle.transform.position;
				if (Vector3.Distance(level.transform.position, handle.transform.position)< 25f)
				{
					throwPower = 10;
					anim2.Play("Fast", -1, 0.0f);
					print(Vector3.Distance(level.transform.position, handle.transform.position));
				}
				if (Vector3.Distance(level.transform.position, handle.transform.position) > 25f)
				{
					throwPower = 5;
					anim2.Play("normal", -1, 0.0f);
					print(Vector3.Distance(level.transform.position, handle.transform.position));
				}
				if (Vector3.Distance(level.transform.position, handle.transform.position) > 200f)
				{
					throwPower = 3;
					anim2.Play("Slow", -1, 0.0f);
					print(Vector3.Distance(level.transform.position, handle.transform.position));
				}
				throwv = false;
				StartCoroutine(Wait());
			}
		}
		if (follow)
		{
			transform.SetParent(null);
			
			Camera.main.transform.position = new Vector3(transform.position.x+3, 5, 36.8f);
			Camera.main.transform.rotation = Quaternion.Euler(20f, -90f, 0);
			Camera.main.fieldOfView = 94.3f;
			fizik.velocity = -transform.right * frisbyhız;
			if (combo)
			{
				timer += 1 * Time.deltaTime;

				print("Combo");
				//print(timer);
				
				if (timer >= 2)
				{
					combo = false;
					print("ComboOver");
					comboCounter = 0;
					timer = 0;
				}
			}
		}
		frisbyhız += (comboCounter/10) * Time.deltaTime;
		süresayac += Time.deltaTime;
		scoresayac = süresayac * frisbyhız;
		puantext.text = "Score: "+scoresayac.ToString("0000"); //skoru ekrana 3 basamaklı yazdırma
		gemText.text = "Gem: "+gem.ToString("000"); //gem ekrana 3 basamaklı yazdırma
		comboT.text = "Combo: " + comboCounter.ToString("00");
		if (scoresayac > highscore)
		{

			highscore = scoresayac;
			PlayerPrefs.SetFloat("HighScore", highscore);

		}
		high.text = "High Score: " + highscore.ToString("000");
	}
	private void OnMouseDrag()
	{
		Vector3 currentpose = transform.position;
		transform.position = new Vector3(transform.position.x, transform.position.y, GetMouseWorldPos().z + mOffset.z); /// frisbiyi sağa sola kaydırma
		if (transform.position.z < currentpose.z)
		{
			transform.Rotate(-25 * Time.deltaTime, 0, 0);
			anim.SetBool("Idle", false);
			anim.enabled = false;
			left = true;
			right = false;
		}
		else
		{
			transform.Rotate(25 * Time.deltaTime, 0, 0);
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
		if (other.gameObject.tag == "O")
		{
			challenge[0] = true;
			Destroy(other.gameObject);
		}
		if (other.gameObject.tag == "P")
		{
			challenge[1] = true;
			Destroy(other.gameObject);
		}
		if (other.gameObject.tag == "U")
		{
			challenge[2] = true;
			Destroy(other.gameObject);
		}
		if (other.gameObject.tag == "L")
		{
			challenge[3] = true;
			Destroy(other.gameObject);
		}
		if (other.gameObject.tag == "E")
		{
			challenge[4] = true;
			Destroy(other.gameObject);
		}
		if (other.gameObject.tag == "N")
		{
			challenge[5] = true;
			Destroy(other.gameObject);
		}
		if (other.gameObject.tag == "C")
		{
			challenge[6] = true;
			Destroy(other.gameObject);
		}
		if (other.gameObject.tag == "E" && challenge[4])
		{
			challenge[7] = true;
			Destroy(other.gameObject);
		}
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(0.35f);
		follow = true;
		frisbyhız = throwPower;
		transform.position = new Vector3(transform.position.x, 2.86f, transform.position.z);
		main.SetActive(false);
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