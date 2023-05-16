using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelFinal : MonoBehaviour
{
    float timer;
    [SerializeField] GameObject panelEnd, musicaCreditos, panelCredito;
    GameObject panelCreditos;
    [SerializeField] ValoresOpciones values;
    [SerializeField] AudioSource source;
    void Start()
    {
        panelCreditos = this.gameObject;
        values.canMove = false;
        source.enabled = false;
        musicaCreditos.SetActive(true);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 10)
        {
            
            panelCredito.SetActive(true);
        }
        if (timer > 20)
        {

            panelEnd.SetActive(true);
        }
    }
}
