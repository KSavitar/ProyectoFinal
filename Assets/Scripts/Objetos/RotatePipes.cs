using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePipes : MonoBehaviour
{
    public ValoresOpciones values;

    private float grados;

    void Start()
    {
        grados = 45;
    }

    void Update()
    {
        
    }
    public void RotarObjeto()
    {
        transform.Rotate(0, 0, grados);

    }
}
