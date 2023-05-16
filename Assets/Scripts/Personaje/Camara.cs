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

	[SerializeField] GameObject notesInv;

	public GameObject cursor;
	[SerializeField] GameObject candadoObj;

	[SerializeField] Animator puertaAnim, CajonAnim, puerta2Anim, puerta3Anim, manivelaAnim, cristalAnim, cofreAnim, maquinaAnim, puerta4Anim;
	[SerializeField] AudioSource audios;
	[SerializeField] AudioClip Tuberia,cogerItem, cristal, martilloA;
	private bool martillo = false;
	[SerializeField]
	private bool llave = false;
	public bool palanca = false;
	bool candado = true, candado2 = true;
	[SerializeField] bool manivela = false;
	bool medallonAzul = false, medallonRosa = false, medallonVerde = false, piezaMaquina = false, ladrillo = false;

	[SerializeField] DialogueObject dialogSala1, dialogSala2, dialogGas;

	GameObject tempObject;

	[SerializeField] int tuboCurva, tuboCruz, tuboPlano, tubosColocados,medallones;

	[SerializeField] GameObject tuboCruzPrefab, tuboPlanoPrefab, tuboCurvoPrefab, manivelaColocada,medallonAzulC, medallonVerdeC, medallonRosaC, PTCruz1, PTCruz2,PTCurva,PTCurva2,PTPlana, sonidoHumo;

	[SerializeField] InventoryManager inventoryManager;
	[SerializeField] ItemsScript llaveSO, martilloSO, tuboCurvaSO, tuboCruzSO, tuboRectoSO, manivelaSO, medallon1SO, medallon2SO, medallon3SO, palancaSO, piezaMaquinaSO, ladrilloSO; //SO significa ScriptableObject


	

	private void Update()
	{
		rotSpeed = values.RotSpeed;

		if (Input.GetKeyDown(KeyCode.I))
		{
			notesInv.SetActive(!notesInv.activeSelf);
		}

		if (Input.GetKeyDown(KeyCode.Escape) && notesInv.activeSelf)
		{
			notesInv.SetActive(false);
		}

		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, mask))
		{
			panel.SetActive(true);

			if (hit.collider.tag == "Martillo")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					Destroy(hit.collider.gameObject);
					martillo = true;
					audios.PlayOneShot(cogerItem);
					AddToInventory(martilloSO);
				}
			}
			else if (hit.collider.tag == "Tablon")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					if (martillo)
					{
						audios.PlayOneShot(martilloA);
						Destroy(hit.collider.gameObject);
						martillo = false;
						inventoryManager.RemoveItemInSlot(ItemType.Martillo);
					}
				}
			}
			else if (hit.collider.tag == "Llave")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					audios.PlayOneShot(cogerItem);
					Destroy(hit.collider.gameObject);
					llave = true;
					AddToInventory(llaveSO);
				}
			}
			else if (hit.collider.tag == "Puerta1")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					if (candado == true && llave == true)
					{
						audios.PlayOneShot(cogerItem);
						candado = false;
						llave = false;
						Destroy(candadoObj);
						inventoryManager.RemoveItemInSlot(ItemType.Llave);
					}
					else if (candado == false)
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
					if (CajonAnim.GetBool("Abierto") == true)
					{
						CajonAnim.SetBool("Abierto", false);
					}
					else if (CajonAnim.GetBool("Abierto") == false)
					{
						CajonAnim.SetBool("Abierto", true);
					}
				}
			}
			else if (hit.collider.tag == "TuboCurva")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					audios.PlayOneShot(cogerItem);
					tuboCurva += 1;
					Destroy(hit.collider.gameObject);
					AddToInventory(tuboCurvaSO);
				}
			}
			else if (hit.collider.tag == "TuboCruz")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					audios.PlayOneShot(cogerItem);
					tuboCruz += 1;
					Destroy(hit.collider.gameObject);
					AddToInventory(tuboCruzSO);

				}
			}
			else if (hit.collider.tag == "TuboPlano")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					audios.PlayOneShot(cogerItem);
					tuboPlano += 1;
					Destroy(hit.collider.gameObject);
					AddToInventory(tuboRectoSO);
				}
			}
			else if(hit.collider.tag == "ZonaTuboCruz")
			{
				if(Input.GetKeyDown(KeyCode.E))
				{
					if(tuboCruz > 0)
					{
						PTCruz1.SetActive(false);
						audios.PlayOneShot(Tuberia);
						print(hit.collider.transform.rotation);
						Instantiate(tuboCruzPrefab, hit.transform.position, new Quaternion(-0.70711f,0,0,0.70711f));
						tuboCruz -= 1;
						tubosColocados += 1;
						Destroy(hit.collider.gameObject);
						inventoryManager.RemoveItemInSlot(ItemType.TuberiaCruz);
					}
				}
			}
			else if (hit.collider.tag == "ZonaTuboCruz2")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					if (tuboCruz > 0)
					{
						PTCruz2.SetActive(false);

						audios.PlayOneShot(Tuberia);
						print(hit.collider.transform.rotation);
						Instantiate(tuboCruzPrefab, hit.transform.position, new Quaternion(-0.70711f, 0, 0, 0.70711f));
						tuboCruz -= 1;
						tubosColocados += 1;
						Destroy(hit.collider.gameObject);
						inventoryManager.RemoveItemInSlot(ItemType.TuberiaCruz);
					}
				}
			}
			else if (hit.collider.tag == "ZonaTuboCurva")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					if (tuboCurva > 0)
					{
						PTCurva.SetActive(false);

						audios.PlayOneShot(Tuberia);

						Instantiate(tuboCurvoPrefab, hit.transform.position, new Quaternion(-0.70711f,0,0, 0.70711f));
						tuboCurva -= 1;
						tubosColocados += 1;

						Destroy(hit.collider.gameObject);
						inventoryManager.RemoveItemInSlot(ItemType.TuberiaCurva);
					}
				}
			}
			else if (hit.collider.tag == "ZonaTuboCurva2")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					if (tuboCurva > 0)
					{
						PTCurva2.SetActive(false);

						audios.PlayOneShot(Tuberia);

						Instantiate(tuboCurvoPrefab, hit.transform.position, new Quaternion(-0.5f, 0.5f, -0.5f, 0.5f));
						tuboCurva -= 1;
						tubosColocados += 1;
						inventoryManager.RemoveItemInSlot(ItemType.TuberiaCurva);
						Destroy(hit.collider.gameObject);
					}
				}
			}
			else if (hit.collider.tag == "ZonaTuboPlano")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					if (tuboPlano > 0)
					{
						PTPlana.SetActive(false);

						audios.PlayOneShot(Tuberia);

						Instantiate(tuboPlanoPrefab, hit.transform.position, new Quaternion(0.5f,0.5f,-0.5f,-0.5f));
						tuboPlano -= 1;
						tubosColocados += 1;
						inventoryManager.RemoveItemInSlot(ItemType.TuberiaRecta);
						Destroy(hit.collider.gameObject);
					}
				}
			}
			else if (hit.collider.tag == "Palanca")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					audios.PlayOneShot(cogerItem);
					palanca = true;
					Destroy(hit.collider.gameObject);
					AddToInventory(palancaSO);
				}
			}
			else if (hit.collider.tag == "Radio1")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					hit.collider.transform.GetComponent<DialoguesScript>().dialogueBox.SetActive(true);
					hit.collider.transform.GetComponent<DialoguesScript>().DisplayDialogue(dialogSala1);
					hit.collider.GetComponent<DialoguesScript>().source.enabled = true;
				}
			}
			else if (hit.collider.tag == "Manivela")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					audios.PlayOneShot(cogerItem);
					manivela = true;
					Destroy(hit.collider.gameObject);
					AddToInventory(manivelaSO);
				}
			}
			else if (hit.collider.tag == "MaquinaManivela")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					if(manivela)
					{
						manivelaColocada.SetActive(true);
						hit.collider.gameObject.layer = 0;
						manivelaAnim.SetBool("Abierta", true);
						manivela = false;
						inventoryManager.RemoveItemInSlot(ItemType.Manivela);
					}
				}
			}
			else if (hit.collider.tag == "MedallonAzul")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					audios.PlayOneShot(cogerItem);
					medallonAzul = true;
					Destroy(hit.collider.gameObject);
					AddToInventory(medallon2SO);
				}
			}
			else if (hit.collider.tag == "MedallonHuecoAzul")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					if(medallonAzul == true)
					{
						medallonAzulC.SetActive(true);
						Destroy(hit.collider.gameObject);
						medallones += 1;
						inventoryManager.RemoveItemInSlot(ItemType.Medallon2);
					}
				}
			}
			else if (hit.collider.tag == "MedallonRosa")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					audios.PlayOneShot(cogerItem);
					medallonRosa = true;
					Destroy(hit.collider.gameObject);
					AddToInventory(medallon3SO);
				}
			}
			else if (hit.collider.tag == "MedallonHuecoRosa")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					if (medallonRosa == true)
					{
						medallonRosaC.SetActive(true);
						Destroy(hit.collider.gameObject);
						medallones += 1;
						inventoryManager.RemoveItemInSlot(ItemType.Medallon3);
					}
				}
			}
			else if (hit.collider.tag == "MedallonVerde")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					audios.PlayOneShot(cogerItem);
					medallonVerde = true;
					Destroy(hit.collider.gameObject);
					AddToInventory(medallon1SO);
				}
			}
			else if (hit.collider.tag == "MedallonHuecoVerde")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					if (medallonVerde == true)
					{
						medallonVerdeC.SetActive(true);
						Destroy(hit.collider.gameObject);
						medallones += 1;
						inventoryManager.RemoveItemInSlot(ItemType.Medallon1);
					}

				}
			}
			if (hit.collider.tag == "Ladrillo")
			{
				if (Input.GetKey(KeyCode.E))
				{
					Destroy(hit.collider.gameObject);
					audios.PlayOneShot(cogerItem);
					ladrillo = true;
					AddToInventory(ladrilloSO);
				}
			}
			else if(hit.collider.tag == "Cristal")
			{
				if(Input.GetKeyDown(KeyCode.E))
				{
					if(ladrillo == true)
					{
						audios.PlayOneShot(cristal);
						cristalAnim.SetBool("Abierta", true);
						hit.collider.enabled = false;
						inventoryManager.RemoveItemInSlot(ItemType.Ladrillo);
					}
				}
			}
			else if (hit.collider.tag == "PiezaMaquina")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					audios.PlayOneShot(cogerItem);
					piezaMaquina = true;
					AddToInventory(piezaMaquinaSO);
					Destroy(hit.collider.gameObject);
				}
			}
			else if (hit.collider.tag == "Cofre")
			{
				panel.SetActive(false);
			}
			else if (hit.collider.tag == "MaquinaLlave")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					if(piezaMaquina == true)
					{
						maquinaAnim.SetBool("Abierta", true);
						piezaMaquina = false;
						inventoryManager.RemoveItemInSlot(ItemType.PiezaMaquina);
					}
				}
			}
			else if (hit.collider.tag == "Radio2")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					hit.collider.transform.GetComponent<DialoguesScript>().dialogueBox.SetActive(true);
					hit.collider.transform.GetComponent<DialoguesScript>().DisplayDialogue(dialogSala2);
					hit.collider.GetComponent<DialoguesScript>().source.enabled = true;
				}
			}
			else if (hit.collider.tag == "Radio3")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					hit.collider.transform.GetComponent<DialoguesScript>().dialogueBox.SetActive(true);
					hit.collider.transform.GetComponent<DialoguesScript>().DisplayDialogue(dialogGas);
					hit.collider.GetComponent<DialoguesScript>().source.enabled = true;
				}
			}
			else if (hit.collider.tag == "Puerta3")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					if (candado == true && llave == true)
					{
						candado = false;
						llave = false;
						
					}
					else if (candado == false)
					{
						puerta4Anim.SetBool("Abierta", true);
					}
				}
			}
			else if (hit.collider.tag == "PastillaRoja")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					hit.collider.GetComponent<PastillaRoja>().enabled = true;
				}
			}
			else if (hit.collider.tag == "PastillaAzul")
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					hit.collider.GetComponent<PastillaAzul>().enabled = true;
				}
			}

			else if (hit.collider.tag == "PuertaFNAF")
			{
				if (Input.GetKey(KeyCode.E) && palanca)
				{
					tempObject = hit.collider.gameObject;
					hit.collider.gameObject.GetComponent<FnafDoorsScript>().isOpen = false;
				}
				else
				{
					hit.collider.gameObject.GetComponent<FnafDoorsScript>().isOpen = true;
				}
			}
			else if (hit.collider.tag == "Generador")
			{
				if (Input.GetKey(KeyCode.E))
				{
					tempObject = hit.collider.gameObject;
					hit.collider.gameObject.GetComponent<GeneratorObjectScript>().isBeingClicked = true;
				}
				else
				{
					hit.collider.gameObject.GetComponent<GeneratorObjectScript>().isBeingClicked = false;
				}
			}
			else if (hit.collider.tag == "CameraMove")
			{
				if (Input.GetKey(KeyCode.E))
				{
					hit.collider.gameObject.GetComponent<SetNoteOnGridScript>().StartAll();
				}
			}
			else if (hit.collider.tag == "Notes")
			{
				if (Input.GetKey(KeyCode.E))
				{
					hit.collider.gameObject.GetComponent<NotesReference>().AddNoteToInv();
					Destroy(hit.collider.gameObject);
				}
			}
			else
			{
				if (tempObject != null)
				{
					if (tempObject.GetComponent<FnafDoorsScript>() != null)
					{
						tempObject.GetComponent<FnafDoorsScript>().isOpen = true;
					}
					else if (tempObject.GetComponent<GeneratorObjectScript>() != null)
					{
						hit.collider.gameObject.GetComponent<GeneratorObjectScript>().isBeingClicked = false;
					}
				}
				
				tempObject = null;
			}
		}
		else
		{
			panel.SetActive(false);
			if (tempObject != null)
			{
				if (tempObject.GetComponent<FnafDoorsScript>() != null)
				{
					tempObject.GetComponent<FnafDoorsScript>().isOpen = true;
				}
				else if (tempObject.GetComponent<GeneratorObjectScript>() != null)
				{
					hit.collider.gameObject.GetComponent<GeneratorObjectScript>().isBeingClicked = false;
				}
			}
		}

		if (tempObject == null)
		{

		}

		if (tubosColocados == 5)
		{
			sonidoHumo.SetActive(false);
			puerta3Anim.SetBool("Abierta", true);
			tubosColocados += 1;
		}
		if(medallones == 3)
		{
			cofreAnim.SetBool("Abierta", true);
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

	private void AddToInventory(ItemsScript item)
	{
		inventoryManager.AddItem(item);
	}
}
