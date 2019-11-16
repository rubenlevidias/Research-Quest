using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
	public IngredientType type;
	[SerializeField] private GameObject ingredientPrefab;
	public enum IngredientType
	{
		shroom,
		apple,
		dna
	}

	public GameObject getPrefab()
	{
		return (ingredientPrefab);
	}
}
