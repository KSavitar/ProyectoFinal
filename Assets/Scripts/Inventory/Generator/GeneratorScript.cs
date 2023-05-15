using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorScript : MonoBehaviour
{
	[Header("Componentes del generador")]
	[SerializeField] public Slider amountRepaired;
	[SerializeField] TextMeshProUGUI generatorNameText;
	[SerializeField] GeneratorObjectScript generator;
 
	[Header("Info del generador")]
	[SerializeField] string generatorName;
	[SerializeField] float timeToRepair;
	[SerializeField] float regressingSpeed;


	private NavMeshScript navMeshManager;
	float currentTime;
	bool isMousePressed => generator.isBeingClicked;
	bool isRepaired;

	private void Awake()
	{
		amountRepaired.maxValue = timeToRepair;
		amountRepaired.minValue = 0;
		generatorName = generatorNameText.text;
		navMeshManager = FindObjectOfType<NavMeshScript>();
	}
	private void Update()
	{
		if (isMousePressed && !isRepaired)
		{
			print("Reparando");
			if (amountRepaired.value < amountRepaired.maxValue)
			{
				amountRepaired.value += Time.deltaTime;
			}
			else if (amountRepaired.value >= amountRepaired.minValue)
			{
				print("Reparado");
				isRepaired = true;
				navMeshManager.FinishGame();
			}
		}
		else if (!isMousePressed && !isRepaired)
		{
			if (amountRepaired.value > 0f)
			{
				amountRepaired.value -= Time.deltaTime * regressingSpeed;
			}
		}
	}


}
