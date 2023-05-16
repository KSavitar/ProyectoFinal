using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrojoScript : MonoBehaviour
{
	private void OnMouseDown()
	{
		GetComponent<CajaFuerte>().enabled = true;
	}

	private void OnMouseUp()
	{
		GetComponent<CajaFuerte>().enabled = false;
	}
}
