using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorObjectScript : MonoBehaviour
{
	[SerializeField] Transform player;
	public bool isBeingClicked;
	public void OnMouseDown()
	{
		if (Vector3.Distance(transform.position, player.position) <= 9f && Input.GetKeyDown(KeyCode.E))
		{
			isBeingClicked = true;
		}
		else
		{
			isBeingClicked = false;
		}
	}
	private void OnMouseUpAsButton()
	{
		isBeingClicked = false;
	}

	private void OnMouseExit()
	{
		if (isBeingClicked)
		{
			isBeingClicked = false;
		}
	}
}
