using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObserver : MonoBehaviour
{
    [SerializeField] private Quest questPositive;
    [SerializeField] private Quest questNeutral;
    [SerializeField] private Quest questNegative;

    [SerializeField] private Quest currentQuest;
    [SerializeField] private TypeQuest typeCurrentQuest;

    [SerializeField] private bool blockQuest;


    [SerializeField] private List<QuestObject> questObjects;


    public void SetQuestObject(List<QuestObject> listObjects) => questObjects = listObjects;

    public void SetQuestPositive(Quest questPositive)
    {
        this.questPositive = questPositive;
    }
    public void SetQuestNeutral(Quest questNeutral)
    {
        this.questNeutral = questNeutral;
    }
    public void SetQuestNegative(Quest questNegative)
    {
        this.questNegative = questNegative;
    }

    public bool CheckPositiveQuest(int number)
    {
        if (number == questPositive.GetCurrentPositionQuest())
            return true;
        return false;
    }

    public bool CheckNegativeQuest(int number)
    {
        if (number == questNegative.GetCurrentPositionQuest())
            return true;
        return false;
    }
    public bool CheckNeutralQuest(int number)
    {
        if (number == questNeutral.GetCurrentPositionQuest())
            return true;
        return false;
    }

    public void AddPositionQuest(TypeQuest typeQuest) 
    {
        switch (typeQuest) 
        {
            case TypeQuest.Negative:
                questNegative.AddCurrentPositionQuest();
                break;
            case TypeQuest.Neutral:
                questNeutral.AddCurrentPositionQuest();
                break;
            case TypeQuest.Positive:
                questPositive.AddCurrentPositionQuest();
                break;
        }
    }

    public bool CheckCurrentQuest(out TypeQuest typeQuest)
    {
        typeQuest = typeCurrentQuest;
        if (blockQuest)
        {
            return true;
        }
        else
        {
            typeQuest = TypeQuest.Norm;
            return false;
        }
    }

    public void Setup()
    {
        blockQuest = false;
    }

    public void BreakOtherQuest(TypeQuest typeQuest)
    {
        switch (typeQuest)
        {
            case TypeQuest.Negative:
                currentQuest = questNegative;
                blockQuest = true;
                typeCurrentQuest = TypeQuest.Negative;
                break;
            case TypeQuest.Neutral:
                currentQuest = questNeutral;
                typeCurrentQuest = TypeQuest.Neutral;
                blockQuest = true;
                break;
            case TypeQuest.Positive:
                currentQuest = questPositive;
                typeCurrentQuest = TypeQuest.Positive;
                blockQuest = true;
                break;
        }
    }


}
