using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventoryManager inventory;
    [SerializeField] private CauldronManager cauldron;
    [SerializeField] private IngredientSlotUI slotPrefab; //le modéle de case a dupliquer 
    [SerializeField] private Transform slotsContainer;

    private readonly Dictionary<IngredientData, IngredientSlotUI> slots =
        new Dictionary<IngredientData, IngredientSlotUI>();

    private void OnEnable()
    {
        GameEvents.OnInventoryChanged += Refresh;
    }

    private void OnDisable()
    {
        GameEvents.OnInventoryChanged -= Refresh;
    }

    private void Refresh()
    {
        foreach (KeyValuePair<IngredientData, int> item in inventory.Items)
        {
            if (slots.TryGetValue(item.Key, out IngredientSlotUI slot))
            {
                slot.UpdateCount(item.Value);
            }
            else
            {
                IngredientSlotUI newSlot = Instantiate(slotPrefab, slotsContainer);
                newSlot.Setup(item.Key, item.Value, cauldron);
                slots[item.Key] = newSlot;
            }
        }
    }
}