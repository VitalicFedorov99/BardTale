using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;
public class CardForBallada : MonoBehaviour
{
    [SerializeField] private TMP_Text textName;
    [SerializeField] private Image image;
    [SerializeField] private Image frame;
    [SerializeField] private CardModel model;
   
        
  

    public void SetupCurrentCard(CardModel model) 
    {
        this.model = model;
        textName.text = model.nameCard;
        frame.color = SearchColorFrame(model.classCard);
        image.sprite = model.spriteCard;
    }

    public CardModel GetCardModel() => model;

    private Color SearchColorFrame(ClassCard card) 
    {
        switch (card) 
        {
            case ClassCard.Heroic:
                return Color.yellow;
            case ClassCard.Bandit:
                return Color.blue;
            case ClassCard.Love:
                return Color.magenta;
            case ClassCard.Neutral:
                return Color.black;
        }
        return Color.white;
    }
}
