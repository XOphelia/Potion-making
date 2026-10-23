using UnityEngine;

[CreateAssetMenu(fileName = "NewIngredient", menuName ="Potion Maker/Ingredient")]//creer un menu utilisable, on a le chemin menu : create, potion maker; ingredient


public class IngredientData : ScriptableObject 
{

//la liste des trucs qui vont se repeter en gros 
[SerializeField] private string displayName;
[SerializeField] private Sprite icon;
[TextArea] //grande zone de text pour la description
[SerializeField] private string description;

public string DisplayName => displayName; //pour que les autres scripts puissent lire les ingredients mais les modifier 
public Sprite Icon => icon;
public string Description => description; 


}
