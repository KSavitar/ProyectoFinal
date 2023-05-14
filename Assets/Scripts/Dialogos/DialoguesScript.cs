using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialoguesScript : MonoBehaviour
{
	[SerializeField] private GameObject dialogueBox;
	[SerializeField] private TextMeshProUGUI authorText;
	[SerializeField] private TextMeshProUGUI dialogueText;
	[SerializeField] private float timeLapse = 0.5f;
	int dialogueTime;
	float timer = 0f;
	float maxTimer = 5f;
	bool enoughtTimePast = false;
	public DialogueObject currentDialogue;

	private void Start()
	{
		DisplayDialogue(currentDialogue);
	}

	private IEnumerator MoveThroughDialogue(DialogueObject dialogueObject)
	{
		for (int i = 0; i < dialogueObject.dialogueLines.Length; i++)
		{
			authorText.text = "";
			dialogueText.text = "";
			maxTimer = float.Parse(dialogueObject.dialogueLines[i].timeToPass);
			authorText.text = dialogueObject.dialogueLines[i].author;
			for (int j = 0; j < dialogueObject.dialogueLines[i].dialogue.Length; j++)
			{
				dialogueText.text = string.Concat(dialogueText.text, dialogueObject.dialogueLines[i].dialogue[j]);
				yield return new WaitForSeconds(timeLapse);
			}

			yield return new WaitUntil(() => enoughtTimePast);
			enoughtTimePast = false;
			
			//The following line of codes make the coroutine wait for a frame so as the next WaitUntil is not skipped
			yield return null;
		}
		dialogueBox.SetActive(false);
	}

	private void Update()
	{
		if (!enoughtTimePast)
		{
			if (timer < maxTimer)
			{
				timer += Time.deltaTime;
			}
			else if (timer >= maxTimer)
			{
				timer = 0f;
				enoughtTimePast = true;
			}
		}
	}

	public void DisplayDialogue(DialogueObject dialogueObject)
	{
		StartCoroutine(MoveThroughDialogue(dialogueObject));
	}
}
