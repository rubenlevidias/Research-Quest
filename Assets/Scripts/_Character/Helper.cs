using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
	[SerializeField] private float health = 100;
	[SerializeField] private float regen = 5;
	[SerializeField] private float healAmount = 20;
	[SerializeField] private bool isHealing = false;
	private Patient patient;

	private void Start()
	{
		patient = GameObject.FindGameObjectWithTag("Patient").GetComponent<Patient>();
	}
	private void Update()
	{
		if (!isHealing && health < 100)
		{
			health += regen * Time.deltaTime;
			if (health > 100)
				health = 100;
		}
		if (isHealing)
		{
			health -= Time.deltaTime * healAmount;
			if (health <= 0)
			{
				health = 0;
				patient.stopRegen();
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Patient")
		{
			isHealing = true;
			patient.startRegen();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Patient")
		{
			isHealing = false;
			patient.stopRegen();
		}
	}
}
