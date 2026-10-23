using UnityEngine;
using System.Collections.Generic; //its to import the lists 


[CreateAssetMenu(fileName = "NewRecipe", menuName ="Potion Maker/Recipe")]

public class RecipeData : ScriptableObject
{
[SerializeField] private List<IngredientData> requiredIngredients = new List<IngredientData>(); //we create a list that can only contain ingredientdata if we try to put something else we CANT 
//and ofc we create a new list thats EMPTY
[SerializeField] private PotionData resultPotion;

public IReadOnlyList<IngredientData> RequiredIngredients => requiredIngredients; //meme principe une recette doit aussi rester constante pendant le jeu 
public PotionData ResultPotion => resultPotion; //la cest un champ pour glisser une fiche potion in the inspector 

public bool Matches(IReadOnlyList<IngredientData> given)
{
    if (given.Count != requiredIngredients.Count) return false;

    List<IngredientData> remaining = new List<IngredientData>(requiredIngredients);
    foreach (IngredientData ingredient in given)
    {
        if (!remaining.Remove(ingredient)) return false;
    }
    return true;
}//pour voir est ce que les ingredients font une recette

}
