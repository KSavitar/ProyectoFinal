using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValoresOpciones : MonoBehaviour
{
    [Range(1.0f, 10f)]
    public float RotSpeed;
    public bool canMove = true;

    public int TuberiasColocadas;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void GoMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
