using System.Collections.Generic;
using UnityEngine;

public class CauldronManager : MonoBehaviour
{
    [SerializeField] private InventoryManager inventory; //inventaire pour retirer les ingreients quon y met
    [SerializeField] private int maxSlots = 3; //le nombre maximum d'ingredients dans le chaudron ( 3 par defaut)

    private readonly List<IngredientData> contents = new List<IngredientData>(); //la liste réelle est en privé et les autres scripts reçoivent une version en lecture seule via contents seule le chadron peut modifier son contenu

    public IReadOnlyList<IngredientData> Contents => contents;
    public int MaxSlots => maxSlots;

    public bool TryAddIngredient(IngredientData ingredient) //renvoie faux si le chaudron est pleins 
    {
        if (contents.Count >= maxSlots) return false;
        if (!inventory.TryRemove(ingredient)) return false;

        contents.Add(ingredient);
        GameEvents.TriggerIngredientAddedToCauldron(ingredient);
        return true;
    }

    public void Clear(bool refundIngredients)
    {
        if (refundIngredients)
        {
            foreach (IngredientData ingredient in contents)
            {
                inventory.Add(ingredient);
            }
        }

        contents.Clear();
        GameEvents.TriggerCauldronCleared();
    }
}