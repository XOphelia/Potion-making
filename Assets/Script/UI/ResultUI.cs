using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Image potionIcon;
    [SerializeField] private Image liquidImage;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private Button closeButton;

    private void OnEnable()
    {
        GameEvents.OnBrewSucceeded += ShowSuccess;
        GameEvents.OnBrewFailed += ShowFailure;

        closeButton.onClick.AddListener(Hide);
    }

    private void OnDisable()
    {
        GameEvents.OnBrewSucceeded -= ShowSuccess;
        GameEvents.OnBrewFailed -= ShowFailure;

        closeButton.onClick.RemoveListener(Hide);
    }

    private void Start()
    {
        Hide();
    }

    private void ShowSuccess(PotionData potion)
    {
        potionIcon.enabled = true;
        potionIcon.sprite = potion.Icon;

        liquidImage.enabled = true;
        liquidImage.color = potion.LiquidColor;

        titleText.text = potion.DisplayName;
        descriptionText.text = potion.Description;

        panel.SetActive(true);
    }

    private void ShowFailure()
    {
        potionIcon.enabled = false;
        liquidImage.enabled = false;

        titleText.text = "echec !";
        descriptionText.text = "Ces ingredients ne forment aucune recette connue.";

        panel.SetActive(true);
    }

    private void Hide()
    {
        panel.SetActive(false);
    }
}