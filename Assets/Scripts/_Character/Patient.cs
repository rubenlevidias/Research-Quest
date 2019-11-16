using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : Character
{
	[SerializeField] private float regen = 5;
	[SerializeField] private float degen = 1;
	public int pills = 0;
	private Damageable damageable;
	[SerializeField] private GameObject heartParticles;
	private bool isHealing = false;

	private void Start()
	{
		damageable = GetComponent<Damageable>();
	}
	public override void Action()
	{
		base.Action();
		if (pills > 0)
		{
			throwPill();
		}
	}
	void Update()
    {
        if (isHealing)
		{
			damageable.GainHealth(regen * Time.deltaTime);
		}
		else
		{
			damageable.TakeDamage(degen * Time.deltaTime);
		}
    }

	public void startRegen()
	{
		isHealing = true;
		heartParticles.Play();
	}

	public void stopRegen()
	{
		isHealing = false;
		heartParticles.Stop();
	}
	public void throwPill()
	{
		pills--;
	}
}
