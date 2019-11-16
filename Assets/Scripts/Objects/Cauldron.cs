using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Cauldron : MonoBehaviour
{
	[SerializeField] private int ingredientNum = 3;
	[SerializeField] private int recipeComplexity = 3;
	[SerializeField] private List<Ingredient.IngredientType> recipe;
	[SerializeField] private List<Ingredient.IngredientType> submittedRecipe;
	private int completedPills = 0;

	private void Start()
	{
		generateRecipe();
	}
	public void addIngredient(Ingredient.IngredientType ingredient)
	{
		submittedRecipe.Add(ingredient);
		if (submittedRecipe.Count == recipe.Count)
		{
			submitRecipe();
		}
	}

	private void generateRecipe()
	{
		for (int i = 0; i < recipeComplexity; i++)
		{
			recipe.Add((Ingredient.IngredientType)Random.Range(0, ingredientNum));
		}
	}

	private void submitRecipe()
	{
		List<Ingredient.IngredientType> missingIngredients = recipe.Except(submittedRecipe).ToList();
		if (missingIngredients.Count == 0)
		{
			completedPills++;
			submittedRecipe.Clear();
			recipe.Clear();
			generateRecipe();
		}
		else
		{
			submittedRecipe.Clear();
		}
	}
}
