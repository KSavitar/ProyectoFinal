using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NotesMoveScript : MonoBehaviour
{
	[SerializeField]
	private Canvas canvas;

	public void DragHandler(BaseEventData data)
	{
		PointerEventData pointerData = (PointerEventData)data;
		Vector2 position;
		RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform, pointerData.position, canvas.worldCamera, out position);

		transform.position = canvas.transform.TransformPoint(position);
	}

}
