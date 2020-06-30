using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Player")
		{
			frisbycontrol controller = other.GetComponent<frisbycontrol>();
			controller.combo = true;
			controller.comboCounter++;
			controller.timer = 0;
			controller.gem += 10;
			Destroy(gameObject);
		}
	}
}
