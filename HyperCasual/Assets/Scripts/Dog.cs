using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
	public Animator anim;
	public Transform target;

	private void Start()
	{
		anim = GetComponent<Animator>();
	}

	private void Update()
	{
		transform.LookAt(target.transform);
	}

}
