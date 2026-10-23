using TMPro; //pour TMP_Text 
using UnityEngine;
using UnityEngine.UI;//pour limage et boutton 

public class IngredientSlotUI : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text countText;
    [SerializeField] private Button button;

    private IngredientData ingredient;
    private CauldronManager cauldron; //pour que la case se souvienne de quel ingredient elle représente et de quel chaudron elle doit appeler 

    public void Setup(IngredientData data, int count, CauldronManager targetCauldron)
    {   //methode qui remplie la case, un prepfab sera dupliqué pour chaque ingredient
        ingredient = data;
        cauldron = targetCauldron; //remplie licone et le nom 

        iconImage.sprite = data.Icon;
        nameText.text = data.DisplayName;
        UpdateCount(count);

        button.onClick.RemoveAllListeners(); 
        button.onClick.AddListener(OnClicked);
    }

    public void UpdateCount(int count)  //appelle updatecount pour la quantité
    {
        countText.text = "x" + count;  //rajoute 1 a chaque element ajouter 
        button.interactable = count > 0;
    }

    private void OnClicked()
    {
        cauldron.TryAddIngredient(ingredient);  //on nettoie avant d'abonner le clic
    }
}