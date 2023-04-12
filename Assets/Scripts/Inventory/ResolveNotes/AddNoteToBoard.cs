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
	[SerializeField] Vector2 fixedPos;
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
		//image.transform.position = parentCanvasOfImageToMove.transform.TransformPoint(pos);
		
		if (Input.mousePosition.x >= minX + xOffset && Input.mousePosition.x <= maxX - xOffset
			&& Input.mousePosition.y >= minY + yOffset && Input.mousePosition.y <= maxY - yOffset)
		{
			print("SESOOE");
			image.transform.position = Vector3.Lerp(image.transform.position, parentCanvasOfImageToMove.transform.TransformPoint(pos), Time.deltaTime * speed);
		}

	}
	public void Update()
	{
		if (Input.GetMouseButton(0))
		{
			//print(Input.mousePosition);
		}
	}
	public void OnEndDrag(PointerEventData eventData)
	{
		image.raycastTarget = true;
	}

}
