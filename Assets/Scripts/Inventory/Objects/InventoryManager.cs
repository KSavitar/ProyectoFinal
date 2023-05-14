using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
	/// <summary> Lista de slots del inventario </summary>
	public InventorySlot[] inventorySlots;
	/// <summary> Prefab de los items del inventario </summary>
	public GameObject inventoryItemPrefab;

	/// <summary> Maxima cantidad de items stackeables. Default = 4 </summary>
	private int maxStack = 4;

	/// <summary> Slot del inventario seleccionado </summary>
	int selectedSlot = -1;
	private void Start()
	{
		ChangeSelectedSlot(0);
	}
	private void Update()
	{
		int mouseScroll = (int)Input.mouseScrollDelta.y;

		if (Input.inputString != null)						//Cambiar slot seleccionado con las teclas del 1-9
		{
			bool isNumber = int.TryParse(Input.inputString, out int number);
			if (isNumber && number > 0 && number < 9)
			{
				ChangeSelectedSlot(number - 1);
			}
		}

		if (mouseScroll != 0)								//Cambiar slot seleccionado con la rueda del mouse
		{
			int newSelectedSlot = selectedSlot + mouseScroll;
			if ((newSelectedSlot) >= 0 && (newSelectedSlot) <= 7)
			{
				ChangeSelectedSlot(newSelectedSlot);
			}
		}

		
	}

	/// <summary> Comprueba si puede añadir el item al inventario </summary>
	public bool AddItem(ItemsScript item)
	{
		for (int i = 0; i < inventorySlots.Length; i++)		//Comprobar si el item ya existe
		{
			InventorySlot slot = inventorySlots[i];
			InventoryItemsScript itemInSlot = slot.GetComponentInChildren<InventoryItemsScript>();
			if (itemInSlot != null && itemInSlot.item == item && itemInSlot.amount < maxStack && itemInSlot.item.stackable)
			{
				itemInSlot.amount++;
				itemInSlot.RefreshCount();
				return true;
			}
		}

		for (int i = 0; i < inventorySlots.Length; i++)		//Comprobar si hay slots vacios
		{
			InventorySlot slot = inventorySlots[i];
			InventoryItemsScript itemInSlot = slot.GetComponentInChildren<InventoryItemsScript>();
			if(itemInSlot == null)
			{
				SpawnItem(item, slot);
				return true;
			}
		}


		return false;
	}

	/// <summary> Añade el item al inventario </summary>
	public void SpawnItem(ItemsScript item, InventorySlot slot)
	{
		GameObject newItemGameObject = Instantiate(inventoryItemPrefab, slot.transform);
		InventoryItemsScript inventoryItem = newItemGameObject.GetComponent<InventoryItemsScript>();
		inventoryItem.InitialiseItem(item);
	}

	/// <summary> Cambia el slot seleccionado </summary>
	private void ChangeSelectedSlot(int newValue)
	{
		if (selectedSlot >= 0)
		{
			inventorySlots[selectedSlot].Deselected();
		}

		inventorySlots[newValue].Selected();
		selectedSlot = newValue;
	}

	public void RemoveItemInSlot(ItemType itemType)
	{
		/*InventoryItemsScript itemInSlot = parentSlot.GetComponentInChildren<InventoryItemsScript>();*/
		/*itemInSlot.amount--;
		itemInSlot.RefreshCount();*/
		print("Tipo: " + itemType);
		for (int i = 0; i < inventorySlots.Length; i++)
		{
			InventorySlot slot = inventorySlots[i];
			InventoryItemsScript itemInSlot = slot.GetComponentInChildren<InventoryItemsScript>();
			if (itemInSlot != null)
			{
				print("Tipo slot: " + itemInSlot.item.type);
			}


			if (itemInSlot != null && itemInSlot.item.type == itemType)
			{
				print("Borrado");
				itemInSlot.amount--;
				itemInSlot.RefreshCount();
				break;
			}
		}
	}

	public bool CheckItemInSlot(ItemType ItemType)
	{
		InventoryItemsScript itemInSlot = inventorySlots[selectedSlot].GetComponentInChildren<InventoryItemsScript>();
		if (itemInSlot != null && itemInSlot.item.type == ItemType)
		{
			return true;
		}
		return false;
	}
}
