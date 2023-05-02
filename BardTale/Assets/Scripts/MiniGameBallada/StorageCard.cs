using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageCard : MonoBehaviour
{
    [SerializeField] private List<CardModel> cards;

    public void Add(CardModel cardForBallada) 
    {
        cards.Add(cardForBallada);
    }

    public List<CardModel> GetCards()=>cards;

    public int GetCountCards() => cards.Count;
}
