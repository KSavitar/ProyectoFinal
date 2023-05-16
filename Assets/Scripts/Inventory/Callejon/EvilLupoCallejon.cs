using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilLupoCallejon : MonoBehaviour
{
	public void DerribaALupo()
	{
		GetComponentInParent<CallejonAnimation>().DerribaALiam();
	}
}
