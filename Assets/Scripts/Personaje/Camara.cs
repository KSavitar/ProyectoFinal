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
                    panel.SetActive(false);
                    hit.collider.transform.GetComponent<CajaFuerte>().enabled = true;
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                    hit.collider.transform.GetComponent<CajaFuerte>().enabled = false;

                    values.canMove = true;
                    panel.SetActive(false);

            }



        }

        else if (hit.collider.tag == "CollectablePipe")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                    hit.collider.transform.GetComponent<CollectablePipe>().Interact();
            }

        }
        else if (hit.collider.tag == "WallPipeSpot")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                    hit.collider.transform.GetComponent<InstancePipe>().Instancepipe();
            }

        }
        if (hit.collider.tag == "WallPipe")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                    hit.collider.transform.GetComponent<RotatePipes>().RotarObjeto();

            }






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
