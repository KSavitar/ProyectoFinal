using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePipes : MonoBehaviour
{
    private float grados;
    public ValoresOpciones values;

    void Start()
    {
        grados = 45;
        values = GameObject.Find("GameManager").GetComponent<ValoresOpciones>();
    }

    void Update()
    {
        
    }
    public void RotarObjeto()
    {
        transform.Rotate(0, grados, 0);
        print(gameObject.transform.rotation);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "A" && other.tag == "B")
        {
            values.TuberiasColocadas += 1;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "A" && other.tag == "B")
        {
            values.TuberiasColocadas -= 1;
        }
    }
}
