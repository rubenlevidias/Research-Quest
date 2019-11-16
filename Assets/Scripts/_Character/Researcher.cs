using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Researcher : Character
{
	[SerializeField] private GameObject heldIngredient;
	[SerializeField] private float interactionRadius = 3f;

	public override void Action()
	{
		base.Action();
		Collider[] colliders = Physics.OverlapSphere(transform.position, interactionRadius);
		Debug.Log(heldIngredient);
		foreach (Collider col in colliders)
		{
			if (col.tag == "Cauldron" && heldIngredient)
			{
				col.GetComponent<Cauldron>().addIngredient(heldIngredient.GetComponent<Ingredient>().type);
				Debug.Log("lol");
				heldIngredient = null;
				return;
			}
			else if (col.tag == "Ingredient")
			{
				if (heldIngredient)
				{
					GameObject droppedIngredient = Instantiate(heldIngredient);
					droppedIngredient.transform.position = transform.position;
				}
				heldIngredient = col.gameObject.GetComponent<Ingredient>().getPrefab();
				Destroy(col.gameObject);
				return;
			}
		}
	}
}
