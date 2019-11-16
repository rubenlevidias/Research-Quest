using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchDesk : MonoBehaviour
{
	[SerializeField] private float discoverDelay = 5;
	[SerializeField] private float researchCooldown = 5;
	[SerializeField] private float successMult = 0.2f;
	private float nextDiscoverTime;
	private bool isResearching = false;
	private int nClues = 0;
	private float cooldownTimer = 0;
	private void Update()
	{
		if (isResearching)
		{
			if (cooldownTimer > 0)
			{
				nextDiscoverTime = Time.time + discoverDelay * 1 + successMult * nClues;
			}
			if (Time.time >= nextDiscoverTime)
			{
				nClues++;
				nextDiscoverTime = Time.time + discoverDelay * 1 + successMult * nClues;
				cooldownTimer = researchCooldown;
			}
		}
		else if (cooldownTimer > 0)
		{
			cooldownTimer -= Time.deltaTime;
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Patient")
		{
			isResearching = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Patient")
		{
			isResearching = false;
		}
	}
}
