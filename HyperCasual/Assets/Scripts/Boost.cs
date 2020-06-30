using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		frisbycontrol controller = other.GetComponent<frisbycontrol>();
		if (other.tag == "Player")
		{
			controller.boostb = true;
			controller.frisbyhız += 10 - controller.throwPower;
			controller.power.value += 10 - controller.throwPower;
			Destroy(gameObject);
		}
	}
}
