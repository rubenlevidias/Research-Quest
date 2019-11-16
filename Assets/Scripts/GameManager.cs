using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public playerIdentity cState = playerIdentity.patient;
	private float nextSwitchTime = 0;
	private float switchDelay = 60;
	[SerializeField] private UserInput userInput;
	private PlayerController patient;
	private PlayerController researcher;
	private Camera patientCamera;
	private Camera researcherCamera;

    public enum playerIdentity
	{
		researcher,
		doctor,
		patient
	}

	public void Start()
	{
		patient = GameObject.FindGameObjectWithTag("Patient").GetComponent<PlayerController>();
		researcher = GameObject.FindGameObjectWithTag("Researcher").GetComponent<PlayerController>();
		patientCamera = GameObject.FindGameObjectWithTag("PatientCamera").GetComponent<Camera>();
		researcherCamera = GameObject.FindGameObjectWithTag("ResearcherCamera").GetComponent<Camera>();
	}
	public void switchToNextIdentity()
	{
		switch (cState)
		{
			case playerIdentity.researcher:
			{
				cState = playerIdentity.patient;
				GameObject[] ennemies = GameObject.FindGameObjectsWithTag("Enemy");
				foreach (GameObject enemy in ennemies)
				{
					enemy.GetComponent<SeekerAI>().UnFreeze();
				}
				userInput.setCharacter(patient, patientCamera.gameObject.GetComponent<CameraController>());
					patientCamera.enabled = true;
					researcherCamera.enabled = false;
				break;
			}
			case playerIdentity.patient:
			{
				cState = playerIdentity.researcher;
				GameObject[] ennemies = GameObject.FindGameObjectsWithTag("Enemy");
				foreach (GameObject enemy in ennemies)
				{
					enemy.GetComponent<SeekerAI>().Freeze();
				}
				userInput.setCharacter(researcher, researcherCamera.gameObject.GetComponent<CameraController>());
					patientCamera.enabled = false;
					researcherCamera.enabled = true;
					break;
			}
		}
	}
}
