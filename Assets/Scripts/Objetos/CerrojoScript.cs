using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrojoScript : MonoBehaviour
{
	public bool isFocused;
	private void OnMouseDown()
	{
		if (isFocused)
		{
			GetComponent<CajaFuerte>().enabled = true;
		}
	}

	private void OnMouseUp()
	{
		GetComponent<CajaFuerte>().enabled = false;
	}
}
