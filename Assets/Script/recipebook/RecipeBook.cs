using UnityEngine;
using System.Collections.Generic;

public class RecipeBook : MonoBehaviour
{

[SerializeField] private List<RecipeData> recipes = new List<RecipeData>();//liste visible pour glisser les assets des recettes 

public RecipeData FindMatch(IReadOnlyList<IngredientData> ingredients){
    foreach (RecipeData recipe in recipes){
        if (recipe.Matches(ingredients)){
            return recipe; //recois les ingredients du chaudron et renvoie la recipe data trouvée si aucun ingredient de correspond on ne renvoie rien
        } 
    }
    return null;
}
}
