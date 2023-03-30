using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeMatScript : MonoBehaviour
{
	[SerializeField] Material outlineMat;

	Renderer meshRenderer;

	private Material _mat;
	private Material _defaultMat;

	public void Awake()
	{
		meshRenderer = GetComponent<Renderer>();
		_defaultMat = meshRenderer.materials[0];
		print(_defaultMat);
	}

	public void OnMouseOver()
	{
		print("Overed");
		meshRenderer.material = outlineMat;
	}

	public void OnMouseExit()
	{
		meshRenderer.material = _defaultMat;
	}

}
