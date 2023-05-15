using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshScript : MonoBehaviour
{
	[SerializeField] Transform targetDestination;
	[SerializeField] Vector3[] targetLocations;
	[SerializeField] GameObject[] doors;
	[SerializeField] Transform player;
	[SerializeField] float changeTargetSpeed = 7.5f;

	int currentPosition;
	int lastPosition = -1;


	int tempInt;

	[HideInInspector] public bool canMove = true;

	GeneratorScript generator;
	[SerializeField] Vector3 resetPlayerPos;

	Vector3 defPos;

	NavMeshAgent _meshAgent;

	private void Awake()
	{
		defPos = transform.position;
		_meshAgent = GetComponent<NavMeshAgent>();
		generator = FindObjectOfType<GeneratorScript>();
	}
	private void Update()
	{
		if (canMove)
		{
			_meshAgent.destination = targetDestination.position;
			print("locacion: " + currentPosition);
			if (_meshAgent.remainingDistance <= 0.02f)
			{
				if (currentPosition != 0)
				{
					print("Puerta" + doors[tempInt - 1].name);
				}
				if (currentPosition != 0)
				{
					if (doors[tempInt - 1].GetComponent<FnafDoorsScript>().isOpen)
					{
						targetDestination = player;
						return;
					}
				}
				if (lastPosition != currentPosition)
				{
					if (currentPosition == 0)
					{
						tempInt = Random.Range(1, targetLocations.Length);
						StartCoroutine(WaitToChangeDestination(10));
					}
					else
					{
						tempInt = 0;
						StartCoroutine(WaitToChangeDestination(changeTargetSpeed));
					}
				}
			}
			if (_meshAgent.remainingDistance <= 2 && targetDestination == player)
			{
				Die();
			}
		}
		else
		{
			_meshAgent.destination = targetLocations[0];
		}
	}

	public void ChangeDestination()
	{
		targetDestination.position = targetLocations[tempInt];
		lastPosition = currentPosition;
		currentPosition = tempInt;
	}

	IEnumerator WaitToChangeDestination(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		ChangeDestination();
		StopAllCoroutines();
	}

	private void Die()
	{
		canMove = false;
		generator.amountRepaired.value = generator.amountRepaired.minValue;
		transform.position = defPos;
		StopAllCoroutines();
		player.position = resetPlayerPos;
	}

	public void FinishGame()
	{
		canMove = false;
		transform.position = defPos;
	}
}
