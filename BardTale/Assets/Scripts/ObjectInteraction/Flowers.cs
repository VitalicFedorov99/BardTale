using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowers : MonoBehaviour, IInteraction
{
    [SerializeField] private int dayAction;
    [SerializeField] private int questPosition;
    public string GetName()
    {
        return "Цветы";
    }

    public string GetNameAction()
    {
        return "Взять";
    }

    public void Interaction()
    {
        if (dayAction == ObjLocator.instance.GetManagerGame().GetCurrentDay())
        {
            if (ObjLocator.instance.GetQuestObserver().CheckPositiveQuest(questPosition))
            {
                ObjLocator.instance.GetQuestObserver().AddPositionQuest(TypeQuest.Positive);
                Debug.Log("Взял цветы");
            }
        }
        
    }
}
