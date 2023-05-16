using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorDeCodigo : MonoBehaviour
{
    public int a, b, c;
    public string finalNum;
    public string codeNum = "958";

    public CajaFuerte A, B, C;
    public ValoresOpciones values;
    [SerializeField] Animator anim;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        finalNum = a.ToString() + b.ToString() + c.ToString();
        if (finalNum == codeNum)
        {
            anim.SetBool("Abierta", true);
            A.enabled = false;
            B.enabled = false;
            C.enabled = false;
            values.canMove = true;

            this.enabled = false;
            
            
        }


    }

    
}
