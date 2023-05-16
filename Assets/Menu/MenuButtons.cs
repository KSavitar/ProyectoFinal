using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public void CerrarAplicacion()
    {
        Application.Quit();
    }

    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
