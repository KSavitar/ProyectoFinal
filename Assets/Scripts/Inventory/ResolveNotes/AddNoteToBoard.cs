using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AddNoteToBoard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	private Image parentImage;
	private Image image;
	[SerializeField] float xOffset;
	[SerializeField] float yOffset;
	[SerializeField] float speed = 30f;
	TextMeshProUGUI description;
	public Canvas parentCanvasOfImageToMove;

	[SerializeField] float minX, maxX, minY, maxY;

	private void Start()
	{
		image = GetComponent<Image>();
		parentImage = GetComponentInParent<Image>();
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		image.raycastTarget = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		Vector2 pos;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvasOfImageToMove.transform as RectTransform, Input.mousePosition, parentCanvasOfImageToMove.worldCamera, out pos);
		image.transform.position = parentCanvasOfImageToMove.transform.TransformPoint(pos);
		

	}
	public void OnEndDrag(PointerEventData eventData)
	{
		image.raycastTarget = true;
	}

}
