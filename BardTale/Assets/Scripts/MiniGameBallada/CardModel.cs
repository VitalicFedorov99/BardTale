using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CardModel")]
public class CardModel : ScriptableObject
{
    public ClassCard classCard;
    public string nameCard;
    public Sprite spriteCard;
}

public enum ClassCard 
{
    Heroic,
    Bandit,
    Love,
    Neutral
}
