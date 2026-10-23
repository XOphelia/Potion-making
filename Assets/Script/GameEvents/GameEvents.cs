using System;

public static class GameEvents
{
    public static event Action OnInventoryChanged;
    public static event Action<IngredientData> OnIngredientAddedToCauldron;
    public static event Action OnCauldronCleared;
    public static event Action<PotionData> OnBrewSucceeded;
    public static event Action OnBrewFailed;

    public static void TriggerInventoryChanged()
    {
        OnInventoryChanged?.Invoke();
    }

    public static void TriggerIngredientAddedToCauldron(IngredientData ingredient)
    {
        OnIngredientAddedToCauldron?.Invoke(ingredient);
    }

    public static void TriggerCauldronCleared()
    {
        OnCauldronCleared?.Invoke();
    }

    public static void TriggerBrewSucceeded(PotionData potion)
    {
        OnBrewSucceeded?.Invoke(potion);
    }

    public static void TriggerBrewFailed()
    {
        OnBrewFailed?.Invoke();
    }
}