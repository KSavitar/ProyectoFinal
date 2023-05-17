using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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

	public bool canMove = false;

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
			if (currentPosition != 0 && _meshAgent.remainingDistance <= 2f)
			{
				
				if (doors[currentPosition - 1].GetComponent<FnafDoorsScript>().isOpen)
				{
					_meshAgent.destination = player.position;
					goForPlayer = true;
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

			if (goForPlayer && _meshAgent.remainingDistance <= 1.25f)
			{
				Die();
			}
		}
	}

	private void Die()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		StopAllCoroutines();
	}

	public void ChangeDestination()
	{
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
		Destroy(gameObject);
		transform.position = defPos;
	}
}
