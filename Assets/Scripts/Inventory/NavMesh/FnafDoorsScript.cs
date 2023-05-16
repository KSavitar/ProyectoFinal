using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FnafDoorsScript : MonoBehaviour
{
	public bool isOpen = true;


	Animator anim;

	private void Awake()
	{
		anim = GetComponentInParent<Animator>();
	}


	private void Update()
	{
		anim.SetBool("Open", isOpen);
	}
}
