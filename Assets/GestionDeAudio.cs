using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionDeAudio : MonoBehaviour
{
    public AudioSource musicaDeFondo;
    AudioClip tuberias, normal;
    public Transform lupo;
    void Start()
    {
        normal = Resources.Load<AudioClip>("Default");
        tuberias = Resources.Load<AudioClip>("Tuberias");

    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MusicaDefault"))
        {
            // Cambia la música de fondo a la de la zona 1
            musicaDeFondo.clip = Resources.Load<AudioClip>("Default");
            musicaDeFondo.Play();
        }
        else if (other.CompareTag("SalaGas"))
        {
            
            musicaDeFondo.PlayOneShot(tuberias);
        }
    }
}
