using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [Serializable]
    private class StartingItem
    {
        public IngredientData ingredient;
        public int amount;
    }

    [SerializeField] private List<StartingItem> startingItems = new List<StartingItem>();

    private readonly Dictionary<IngredientData, int> items = new Dictionary<IngredientData, int>();

    public IReadOnlyDictionary<IngredientData, int> Items => items;

    private void Start()
    {
        foreach (StartingItem item in startingItems)
        {
            Add(item.ingredient, item.amount);
        }
    }

    public int GetCount(IngredientData ingredient)
    {
        return items.TryGetValue(ingredient, out int count) ? count : 0;
    }

    public void Add(IngredientData ingredient, int amount = 1)
    {
        items[ingredient] = GetCount(ingredient) + amount;
        GameEvents.TriggerInventoryChanged();
    }

    public bool TryRemove(IngredientData ingredient)
    {
        if (GetCount(ingredient) <= 0)
        {
            return false;
        }

        items[ingredient]--;
        GameEvents.TriggerInventoryChanged();
        return true;
    }
}