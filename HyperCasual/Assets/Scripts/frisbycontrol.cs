using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frisbycontrol : MonoBehaviour
{
    private Vector3 mOffset;

    private float mZCoord;

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
       
       
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}

