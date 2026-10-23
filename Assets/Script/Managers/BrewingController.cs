using UnityEngine;

public class BrewingController : MonoBehaviour
{
    [SerializeField] private CauldronManager cauldron; //les 2 scripts dont i a besoin 
    [SerializeField] private RecipeBook recipeBook;

    [ContextMenu("Brew")] //ajoute une entrée dans le menu clic droit du composant de linspector 
    public void Brew() //publique pour qu'un bouton de l'ui puisse lappeller plus tard 
    {
        if (cauldron.Contents.Count == 0) return; //si le chaudron est vide on ne fait rien

        RecipeData recipe = recipeBook.FindMatch(cauldron.Contents); //on passe le contenu du chaudron au livre de recettes le resultat c sois la recette sois null

        if (recipe != null)
        {
            GameEvents.TriggerBrewSucceeded(recipe.ResultPotion); //on la lance si la recette est trouvé
        }
        else
        {
            GameEvents.TriggerBrewFailed();//sinon on lance celle la 
        }

        cauldron.Clear(false);//dans les deux cas on vide le chaudron et les ingredients sont perdus 
    }
}