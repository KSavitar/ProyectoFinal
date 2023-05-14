using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform player;
    public float rotSpeed, minRot, maxRot;
    float mouseX, mouseY;
    public ValoresOpciones values;

    public LayerMask mask;
    public float distance = 2f;
    RaycastHit hit;
    
    public GameObject panel;

    public GameObject cursor;
    [SerializeField] GameObject candadoObj;

    [SerializeField] Animator puertaAnim,CajonAnim,puerta2Anim;
    
    private bool martillo = false;
    [SerializeField]
    private bool llave = false;
    bool candado = true;

    [SerializeField]int tuboCurva, tuboCruz, tuboPlano;


 private void Start()
 {




 }

 private void Update()
 {
        rotSpeed = values.RotSpeed;

    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, mask))
    {




        if (hit.collider.tag == "Cerrojo")
        {
            panel.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                    
                    hit.collider.transform.GetComponent<CajaFuerte>().enabled = true;
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                    hit.collider.transform.GetComponent<CajaFuerte>().enabled = false;

                    values.canMove = true;
                    

            }



        }
        else if(hit.collider.tag == "Martillo")
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(hit.collider.gameObject);
                    martillo = true;
                }
            }
            else if (hit.collider.tag == "Tablon")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if(martillo == true)
                    {
                        Destroy(hit.collider.gameObject);
                        martillo = false;
                    }
                }
            }
            else if (hit.collider.tag == "Llave")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(hit.collider.gameObject);
                    llave = true;
                }
            }
            else if (hit.collider.tag == "Puerta1")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if(candado == true && llave == true)
                    {
                        candado = false;
                        llave = false;
                        Destroy(candadoObj);
                    }
                    else if(candado == false)
                    {
                        puertaAnim.SetBool("Abierta", true);
                    }
                }
            }
            else if (hit.collider.tag == "Puerta2")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    
                    puerta2Anim.SetBool("Abierta", true);
                    
                }
            }
            else if (hit.collider.tag == "CajonSala1")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if(CajonAnim.GetBool("Abierto") == true)
                    {
                        CajonAnim.SetBool("Abierto", false);
                    }
                    else if(CajonAnim.GetBool("Abierto") == false)
                    {
                        CajonAnim.SetBool("Abierto", true);
                    }
                }
            }

            else if (hit.collider.tag == "TuboCurva")
            {
              if (Input.GetKeyDown(KeyCode.E))
              {
                    tuboCurva += 1;
                    Destroy(hit.collider.gameObject);
              }
            }
            else if (hit.collider.tag == "TuboCruz")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    tuboCruz += 1;
                    Destroy(hit.collider.gameObject);

                }
            }
            else if (hit.collider.tag == "TuboPlano")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    tuboPlano += 1;
                    Destroy(hit.collider.gameObject);

                }
            }
            else if(hit.collider.tag == null)
            {
                panel.SetActive(false);
            }
    }


 }


 public void Cam()
 {

        mouseY -= rotSpeed * Input.GetAxis("Mouse Y");
        mouseY = Mathf.Clamp(mouseY, minRot, maxRot);

        transform.localRotation = Quaternion.Euler(mouseY, player.rotation.x, 0.0f);


 }
 public void CamX()
 {
        mouseX += rotSpeed * Input.GetAxis("Mouse X");

        transform.localRotation = Quaternion.Euler(0, mouseX, 0.0f);

 }


 private void LateUpdate()
 {
    if (values.canMove)
    {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            cursor.SetActive(true);

        if (Input.GetMouseButton(2))
        {
                CamX();
        }
        else
        {
                Cam();

        }
    }
    else
    {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            cursor.SetActive(false);

    }



 }
}
