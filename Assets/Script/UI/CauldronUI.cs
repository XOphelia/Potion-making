using UnityEngine;
using UnityEngine.UI;

public class CauldronUI : MonoBehaviour
{
    [SerializeField] private CauldronManager cauldron;
    [SerializeField] private BrewingController brewing;
    [SerializeField] private Image[] slotIcons;
    [SerializeField] private Button brewButton;
    [SerializeField] private Button cancelButton;

    private void OnEnable()
    {
        GameEvents.OnIngredientAddedToCauldron += HandleIngredientAdded;
        GameEvents.OnCauldronCleared += Refresh;

        brewButton.onClick.AddListener(OnBrewClicked);
        cancelButton.onClick.AddListener(OnCancelClicked);
    }

    private void OnDisable()
    {
        GameEvents.OnIngredientAddedToCauldron -= HandleIngredientAdded;
        GameEvents.OnCauldronCleared -= Refresh;

        brewButton.onClick.RemoveListener(OnBrewClicked);
        cancelButton.onClick.RemoveListener(OnCancelClicked);
    }

    private void Start()
    {
        Refresh();
    }

    private void HandleIngredientAdded(IngredientData ingredient)
    {
        Refresh();
    }

    private void Refresh()
    {
        for (int i = 0; i < slotIcons.Length; i++)
        {
            if (i < cauldron.Contents.Count)
            {
                slotIcons[i].sprite = cauldron.Contents[i].Icon;
                slotIcons[i].enabled = true;
            }
            else
            {
                slotIcons[i].enabled = false;
            }
        }

        bool hasContent = cauldron.Contents.Count > 0;
        brewButton.interactable = hasContent;
        cancelButton.interactable = hasContent;
    }

    private void OnBrewClicked()
    {
        brewing.Brew();
    }

    private void OnCancelClicked()
    {
        cauldron.Clear(true);
    }
}