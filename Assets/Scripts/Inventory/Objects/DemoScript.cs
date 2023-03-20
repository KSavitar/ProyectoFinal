using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> Script de prueba para a�adir items </summary>

public class DemoScript : MonoBehaviour
{
	/// <summary> Inventario </summary>
	public InventoryManager inventoryManager;
	/// <summary> Lista de items creados que puedes encontrar </summary>
	public ItemsScript[] itemsToPickup;         //(Solo son ejemplos)

	/// <summary> Recive una id que hace referencia a la lista de itemsToPickup </summary>
	public void PickupItem(int id)
	{
		bool canAdd = inventoryManager.AddItem(itemsToPickup[id]); //Comprobar si se puede a�adir
		if (canAdd) print("Item is Added");
		else if (!canAdd) print("Inventory is full");
	}
}
