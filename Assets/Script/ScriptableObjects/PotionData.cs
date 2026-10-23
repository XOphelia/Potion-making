using UnityEngine;

[CreateAssetMenu(fileName = "NewPotion", menuName ="Potion Maker/Potion")]

public class PotionData : ScriptableObject
{
   
   [SerializeField] private string displayName;
   [SerializeField] private Sprite icon;
   [SerializeField] private Color liquidColor = Color.white; //default color white sinn klch kif kif
   [TextArea]
   [SerializeField] private string description;

   public string DisplayName => displayName;
   public Sprite Icon => icon;
   public Color LiquidColor => liquidColor;
   public string Description => description; //ani nhas rohi ne9ra poo

   

        
    }

