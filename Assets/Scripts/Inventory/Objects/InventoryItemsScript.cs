using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class InventoryItemsScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	/// <summary> Sprite del objeto en el inventario </summary>
	public Image image;
	/// <summary> Cantidad del item en el inventario </summary>
	[HideInInspector] public int amount = 1;
	/// <summary> Texto en la UI con la cantidad de ese item </summary>
	public TextMeshProUGUI amountText;
	/// <summary> Parent del item despues de terminar el drag </summary>
	[HideInInspector]
	public Transform parentAfterDrag;
	/// <summary> El item recibido </summary>
	[HideInInspector]
	public ItemsScript item;

	/// <summary> Cuando se empieza a mover el item por la UI </summary>
	public void OnBeginDrag(PointerEventData eventData)
	{
		parentAfterDrag = transform.parent;
		transform.SetParent(transform.root);
		transform.SetAsLastSibling();						//Colocarlo al final del canvas para que se muestre por encima de todo
		image.raycastTarget = false;						//Desactivar el poder interactuar con un raycast para evitar interacciones no deseadas
	}

	/// <summary> Mientras el item se está moviendo por la UI </summary>
	public void OnDrag(PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}

	/// <summary> Al soltar el item </summary>
	public void OnEndDrag(PointerEventData eventData)
	{
		transform.SetParent(parentAfterDrag);
		image.raycastTarget = true;							//Devolverle la interaccion con raycasts para poder volver a moverlo
	}

	/// <summary> Asigna el tipo de item creando uno nuevo con las propiedades deseadas </summary>
	public void InitialiseItem(ItemsScript newItem)
	{
		item = newItem;
		image.sprite = newItem.image;
		RefreshCount();
	}

	/// <summary> Actualiza la cantidad del item en el inventario </summary>
	public void RefreshCount()
	{
		amountText.text = ("x" + amount);
		bool textActive = amount > 1;
		amountText.gameObject.SetActive(textActive);
		if (amount <= 0)
		{
			Destroy(gameObject);
		}
		print(amount);
	}
}
