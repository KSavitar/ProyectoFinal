using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNoteOnGridScript : MonoBehaviour
{
	[SerializeField] Camera m_Camera;

	[SerializeField] Vector3 cameraPositionToGrid;
	[SerializeField] Quaternion cameraRotationToGrid;

	[SerializeField] float speedRotation;
	[SerializeField] float speedMove;

	private Quaternion cameraOnPlayerRotation;
	private Vector3 cameraOnPlayerTransform;

	bool rotate;
	bool goToDefault;

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (rotate)
		{
			m_Camera.transform.rotation = Quaternion.RotateTowards(m_Camera.transform.rotation, cameraRotationToGrid, Time.deltaTime * speedRotation);
			m_Camera.transform.position = Vector3.MoveTowards(m_Camera.transform.position, cameraPositionToGrid, speedMove * Time.deltaTime);
		}

		if (Input.GetKeyDown(KeyCode.Y))
		{
			rotate = false;
			goToDefault = true;
		}

		if (goToDefault)
		{
			m_Camera.transform.rotation = Quaternion.RotateTowards(m_Camera.transform.rotation, cameraOnPlayerRotation, Time.deltaTime * speedRotation);
			m_Camera.transform.position = Vector3.MoveTowards(m_Camera.transform.position, cameraOnPlayerTransform, speedMove * Time.deltaTime);

			if (Vector3.Distance(m_Camera.transform.position, cameraOnPlayerTransform) <= 0.0001f)
			{
				print("GGGGG");
				goToDefault = false;
				m_Camera.transform.rotation = cameraOnPlayerRotation;
				m_Camera.GetComponentInParent<PlayerController>().enabled = true;
				m_Camera.GetComponent<Camara>().enabled = true;
			}
		}
	}

	private void OnMouseDown()
	{
		if (!rotate)
		{
			rotate = true;
			print("Hey");
			m_Camera.GetComponent<Camara>().enabled = false;
			m_Camera.GetComponentInParent<PlayerController>().enabled = false;
			cameraOnPlayerRotation = m_Camera.transform.rotation;
			cameraOnPlayerTransform = m_Camera.transform.position;
		}
	}
}
