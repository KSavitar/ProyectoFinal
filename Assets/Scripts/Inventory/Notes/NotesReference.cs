using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesReference : MonoBehaviour
{
	[SerializeField] int id;
	[SerializeField] AddNotes addNotes;


	public void AddNoteToInv()
	{
		addNotes.PickupNote(id);
	}
}
