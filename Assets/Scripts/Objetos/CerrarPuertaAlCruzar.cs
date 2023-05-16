using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarPuertaAlCruzar : MonoBehaviour
{
    public Animator puertaAnim;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            puertaAnim.SetBool("Abierta", false);
            this.enabled = false;
        }
    }
}
