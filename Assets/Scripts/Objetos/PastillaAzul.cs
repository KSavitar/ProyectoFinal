using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastillaAzul : MonoBehaviour
{
    [SerializeField] GameObject panelCreditos;
    void Start()
    {
        panelCreditos.SetActive(true);
    }
}
