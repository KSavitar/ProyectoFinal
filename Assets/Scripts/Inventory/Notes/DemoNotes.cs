using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary> Misma funcion que el DemoScript para las notas </summary>
public class DemoNotes : MonoBehaviour
{
	/// <summary> Inventario de notas </summary>
	public NotesInventoryScript notesInventory;
	/// <summary> Lista de notas recogibles </summary>
	public List<NotesScript> notesToPickup = new List<NotesScript>();

	private void Awake()
	{
		foreach (string path in Directory.EnumerateFiles(Path.Combine(Application.streamingAssetsPath, "Notes"), "*.json"))
		{
			notesToPickup.Add((NotesScript)JsonConvert.DeserializeObject(File.ReadAllText(path), typeof(NotesScript)));
		}
	}

	/// <summary> Recoge la nota deseada a traves de su id (Posicion en notesToPickup)</summary>
	public void PickupNote(int id)
	{
		notesInventory.AddNote(notesToPickup[id]);
	}
}
