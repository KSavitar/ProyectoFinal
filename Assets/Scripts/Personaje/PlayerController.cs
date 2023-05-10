using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    private Vector3 moveDir;
    public float speed = 12, speedRotation, jumpForce, gravity;


    public bool isGrounded, haveRest;
    public Transform groundPoint;
    public float groundRadius;
    public LayerMask groundMask;

    float lastRot;

    float mouseX;
    public float minRot, maxRot;

    public ValoresOpciones values;


    public float pipes = 0;




    void Start()
    {

    }

    void Update()
    {



        speedRotation = values.RotSpeed;

        if (values.canMove)
        {
            rb.isKinematic = false;

            moveDir = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y, Input.GetAxis("Vertical") * speed);


            moveDir = transform.TransformDirection(moveDir);


            if (Input.GetMouseButton(2)) KeepRot();
            else PlayerRot();


            isGrounded = Physics.OverlapSphere(groundPoint.position, groundRadius, groundMask).Length != 0;
            if (isGrounded)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    moveDir.y = jumpForce;
                }
            }



            lastRot = mouseX;

            moveDir.y -= gravity * Time.deltaTime;
            rb.velocity = moveDir;

        }
        else
        {
            rb.isKinematic = true;
        }
    }

    public void PlayerRot()
    {

        mouseX += speedRotation * Input.GetAxis("Mouse X");

        transform.rotation = Quaternion.Euler(0.0f, mouseX, 0.0f);


    }
    public void KeepRot()
    {
        transform.rotation = Quaternion.Euler(0, lastRot, 0);
    }
}
