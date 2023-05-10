using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaFuerte : MonoBehaviour
{
    public ValoresOpciones values;

    public float rotSpeed;

    private float SceneWidth;
    private Vector3 PressPoint;
    private Quaternion StartRotation;


    private void Start()
    {
        SceneWidth = Screen.width;

    }

    void Update()
    {
        values.canMove = false;


        if (Input.GetMouseButtonDown(0))
        {
            PressPoint = Input.mousePosition;
            StartRotation = transform.rotation;
        }
        else if (Input.GetMouseButton(0))
        {
            float CurrentDistanceBetweenMousePositions = (Input.mousePosition - PressPoint).x;
            transform.rotation = StartRotation * Quaternion.Euler(Vector3.left * (CurrentDistanceBetweenMousePositions / SceneWidth * 360));
        }

    }
}
