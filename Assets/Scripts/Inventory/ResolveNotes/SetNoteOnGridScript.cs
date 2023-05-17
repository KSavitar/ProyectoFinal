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

	[SerializeField] GameObject canvas;
	[SerializeField] GameObject canvasChild;

	[SerializeField] bool isFinalBillboard;

	[SerializeField] GameObject[] cerrojos;

	private Quaternion cameraOnPlayerRotation;
	private Vector3 cameraOnPlayerTransform;
	public Renderer render;

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

		if (Input.GetKeyDown(KeyCode.Escape) && rotate && !goToDefault)
		{
			rotate = false;
			goToDefault = true;
		}

		if (goToDefault)
		{
			m_Camera.transform.rotation = Quaternion.RotateTowards(m_Camera.transform.rotation, cameraOnPlayerRotation, Time.deltaTime * speedRotation);
			//m_Camera.transform.position = Vector3.MoveTowards(m_Camera.transform.position, cameraOnPlayerTransform, speedMove * Time.deltaTime);
			m_Camera.transform.localPosition = Vector3.MoveTowards(new Vector3(0.05f, 4.49f, 0.26f), cameraOnPlayerTransform, speedMove * Time.deltaTime);
			if (Vector3.Distance(m_Camera.transform.localPosition, cameraOnPlayerTransform) <= 0.0001f)
			{
				goToDefault = false;
				m_Camera.transform.rotation = cameraOnPlayerRotation;
				render.enabled = true;
				m_Camera.GetComponentInParent<PlayerController>().enabled = true;
				m_Camera.GetComponent<Camara>().values.canMove = true;
				canvas.SetActive(true);
				if (!isFinalBillboard)
				{
					for (int i = 0; i < cerrojos.Length; i++)
					{
						cerrojos[i].GetComponent<CerrojoScript>().isFocused = false;
					}
				}
			}
		}
	}

	public void StartAll()
	{
		if (!rotate)
		{
			canvas.SetActive(false);
			rotate = true;
			render.enabled = false;
			m_Camera.GetComponent<Camara>().values.canMove = false;
			m_Camera.GetComponentInParent<PlayerController>().enabled = false;
			cameraOnPlayerRotation = m_Camera.transform.rotation;
			cameraOnPlayerTransform = m_Camera.transform.localPosition;
			if (isFinalBillboard)
			{
				canvasChild.SetActive(true);
			}
			else if (!isFinalBillboard)
			{
				for (int i = 0; i < cerrojos.Length; i++)
				{
					cerrojos[i].GetComponent<CerrojoScript>().isFocused = true;
				}
			}
		}
	}
}
