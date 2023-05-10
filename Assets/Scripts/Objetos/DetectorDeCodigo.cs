using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorDeCodigo : MonoBehaviour
{
    public int a = 1, b = 2, c = 0;
    public string finalNum, codeNum;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        finalNum = a.ToString() + b.ToString() + c.ToString();
        if (finalNum == codeNum)
        {
            print("Correcto");
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        print("a");
        if (other.CompareTag("Correct"))
        {
            a = 9;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        print("a");
        if (other.CompareTag("Correct"))
        {
            a = 0;
        }

    }
}
