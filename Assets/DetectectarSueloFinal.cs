using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectectarSueloFinal : MonoBehaviour
{
    // Start is called before the first frame update

    public DialogueObject DialogoFinal;
    public GameObject panel;
    bool si;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player" && !si)
        {
            panel.SetActive(true);
            GetComponent<DialoguesScript>().DisplayDialogue(DialogoFinal);
            si = true;
        }
    }
}
