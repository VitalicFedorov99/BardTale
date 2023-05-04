using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowers : MonoBehaviour, IInteraction
{
    [SerializeField] private int dayAction;
    [SerializeField] private int questPosition;
    public string GetName()
    {
        return "�����";
    }

    public string GetNameAction()
    {
        return "�����";
    }

    public void Interaction()
    {
        if (dayAction == ObjLocator.instance.GetManagerGame().GetCurrentDay())
        {
            if (ObjLocator.instance.GetQuestObserver().CheckPositiveQuest(questPosition))
            {
                ObjLocator.instance.GetQuestObserver().AddPositionQuest(TypeQuest.Positive);
                Debug.Log("���� �����");
            }
        }
        
    }
}
