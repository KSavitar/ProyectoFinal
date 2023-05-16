using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallejonAnimation : MonoBehaviour
{
	[SerializeField] Animator liamAnim;
	[SerializeField] Animator villainAnim;
	[SerializeField] Animator cameraAnim;
	[SerializeField] Animator adrianAnim;

	[SerializeField] Transform VillainParent;

	private Vector3 pos = new Vector3(-1.93f, -0.34f, -8.96f);

	private void start()
	{
		villainAnim.SetTrigger("CallejonWalking");
		//cameraAnim.SetTrigger("CallejonMove");
	}

	public void StopWalk()
	{
		adrianAnim.SetFloat("speedMultiplier", 0);
	}

	public void Punch()
	{
		adrianAnim.SetFloat("speedMultiplier", 1);
		adrianAnim.SetTrigger("Punch");
	}

	public void DerribaALiam()
	{
		liamAnim.SetTrigger("Die");
	}
}
