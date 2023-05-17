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

    public DetectorDeCodigo codigo;


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
            transform.rotation = StartRotation * Quaternion.Euler(Vector3.down * (CurrentDistanceBetweenMousePositions / SceneWidth * 360));
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("A"))
        {
            codigo.a = 9;
        }
        if (other.CompareTag("B"))
        {
            codigo.b = 5;
        }
        if (other.CompareTag("C"))
        {
            codigo.c = 8;
        }

    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("A"))
        {
            codigo.a = 0;
        }
        if (other.CompareTag("B"))
        {
            codigo.b = 0;
        }
        if (other.CompareTag("C"))
        {
            codigo.c = 0;
        }

    }
}
