using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigationIA : MonoBehaviour
{
	[SerializeField] Transform targetDestination;
	[SerializeField] Vector3[] targetLocations;
	[SerializeField] GameObject[] doors;
	[SerializeField] Transform player;
	[SerializeField] float changeTargetSpeed = 7.5f;

	int currentPosition = 0;
	int lastPosition = -1;


	int tempInt;

	bool canMove = false;

	GeneratorScript generator;
	[SerializeField] Vector3 resetPlayerPos;


	bool goForPlayer = false;
	Vector3 defPos;

	NavMeshAgent _meshAgent;

	private void Awake()
	{
		defPos = transform.position;
		_meshAgent = GetComponent<NavMeshAgent>();
		generator = FindObjectOfType<GeneratorScript>();
		_meshAgent.destination = targetLocations[0];
	}

	private void Update()
	{
		if (canMove)
		{
			/*if (currentPosition != 0)
			{
				print(currentPosition + " + " + doors[currentPosition - 1].name);
			}*/
			if (currentPosition != 0 && _meshAgent.remainingDistance <= 2f)
			{
				
				if (doors[currentPosition - 1].GetComponent<FnafDoorsScript>().isOpen)
				{
					_meshAgent.destination = player.position;
					goForPlayer = true;
					print("Muere");
				}
				else
				{
					StartCoroutine(WaitToChangeDestination(changeTargetSpeed));
				}
			}
			else if (currentPosition == 0 && _meshAgent.remainingDistance <= 2f)
			{
				StartCoroutine(WaitToChangeDestination(10f));
			}

			if (goForPlayer && _meshAgent.remainingDistance <= .2f)
			{
				Die();
			}
		}
	}

	private void Die()
	{
		canMove = false;
		generator.amountRepaired.value = generator.amountRepaired.minValue;
		transform.position = defPos;
		player.position = resetPlayerPos;
		goForPlayer = false;
		StopAllCoroutines();
	}

	public void ChangeDestination()
	{
		print("SpawnPoint");
		if (currentPosition == 0)
		{
			_meshAgent.destination = targetLocations[currentPosition = Random.Range(1, targetLocations.Length)];
			
		}
		else
		{
			_meshAgent.destination = targetDestination.position;
			currentPosition = 0;
		}
	}
	IEnumerator WaitToChangeDestination(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		ChangeDestination();
		StopAllCoroutines();
	}


	public void FinishGame()
	{
		canMove = false;
		transform.position = defPos;
	}
}
