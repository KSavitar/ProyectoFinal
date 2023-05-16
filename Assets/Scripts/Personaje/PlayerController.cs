using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public Rigidbody rb;
	public Animator animator;
	private Vector3 moveDir;
	public float speed = 12, speedRotation, jumpForce, gravity;

	public AudioSource caminar;
	public bool isGrounded, haveRest;
	public Transform groundPoint;
	public float groundRadius;
	public LayerMask groundMask;

	float lastRot;

	float mouseX;
	public float minRot, maxRot;

	public ValoresOpciones values;

	[SerializeField] GameObject panelGenerador;
	[SerializeField] GameObject sliderGenerador;

	




	void Start()
	{
		caminar.enabled = false;
	}

	void Update()
	{



		speedRotation = values.RotSpeed;

		if (values.canMove)
		{
			rb.isKinematic = false;

			moveDir = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y, Input.GetAxis("Vertical") * speed);

			moveDir = transform.TransformDirection(moveDir);

			if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
			{
				caminar.enabled = true;
				animator.SetBool("Move", true);
			}
			else
			{
				caminar.enabled =false;
				animator.SetBool("Move", false);
			}



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

	private void OnTriggerEnter(Collider other)
	{
		if (other.name == "FNAFTrigger")
		{
			FindObjectOfType<EnemyNavigationIA>().canMove = true;
			panelGenerador.SetActive(true);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.name == "FNAFTrigger" && sliderGenerador.GetComponent<Slider>().value == sliderGenerador.GetComponent<Slider>().maxValue)
		{
			panelGenerador.SetActive(false);
		}
	}
}
