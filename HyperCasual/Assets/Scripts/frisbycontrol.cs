using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class frisbycontrol : MonoBehaviour
{
	private Vector3 mOffset;

	private float mZCoord;
	Rigidbody fizik;
	int puan = 0;
	public Text puantext;
	public float frisbyhız;
	float scoresayac = 0;
	float süresayac = 0;

	void Start()
	{
		fizik = GetComponent<Rigidbody>();
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
		Camera.main.transform.position = new Vector3(transform.position.x+5, Camera.main.transform.position.y, Camera.main.transform.position.z); // kameranın frisbiyi takip etmesi
		if (Input.GetMouseButton(0))
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, GetMouseWorldPos().z + mOffset.z); /// frisbiyi sağa sola kaydırma
		}
		fizik.velocity = transform.right * frisbyhız;
		süresayac += Time.deltaTime;
		scoresayac = süresayac * 10;
		puantext.text = "Score: "+scoresayac.ToString("000"); //skoru ekrana 3 basamaklı yazdırma
	}
	private void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "engel")
		{
			SceneManager.LoadScene("kaybetme sahnesi");
		}

	}


}