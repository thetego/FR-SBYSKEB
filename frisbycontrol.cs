using System.Collections;
using System.Collections.Generic;
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
        fizik.velocity = transform.forward * frisbyhız;
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
		if (Input.GetMouseButton(0))
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, GetMouseWorldPos().z + mOffset.z);
		}

        süresayac += Time.deltaTime;
        scoresayac = süresayac * 1000;
        Debug.Log(scoresayac);
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "puan")
        {
            puan++;
            puantext.text = "" + puan;  
        }
        if (col.gameObject.tag == "engel")
        {
            SceneManager.LoadScene("kaybetme sahnesi");
        }

    }
    

}

