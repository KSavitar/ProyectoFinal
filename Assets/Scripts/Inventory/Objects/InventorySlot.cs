using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
	/// <summary> Imagen del slot del inventario </summary>
	public Image image;
	/// <summary> Color para cuando el este seleccionado </summary>
	public Color selectedColor;
	/// <summary> Color para cuando el slot no este seleccionado </summary>
	public Color notSelectedColor;
	/// <summary> Color para cuando el slot no este seleccionado </summary>
	public bool isSelected;

	private void Awake()
	{
		Deselected();
	}

	/// <summary> Cambiar el color del slot al selectedColor </summary>
	public void Selected()
	{
		image.color = selectedColor;
		isSelected = true;
	}

	/// <summary> Cambiar el color del slot al notSelectedColor </summary>
	public void Deselected()
	{
		image.color = notSelectedColor;
		isSelected = false;
	}

	/// <summary> Convierte el slot en el parent del item al soltarlo </summary>
	public void OnDrop(PointerEventData eventData)
	{
		if (transform.childCount == 0)
		{
			GameObject dropped = eventData.pointerDrag;
			InventoryItemsScript draggableItem = dropped.GetComponent<InventoryItemsScript>();
			draggableItem.parentAfterDrag = transform;
		}
	}
}
