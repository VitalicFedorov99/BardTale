using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    [SerializeField] private string globalNameQuest;
    [SerializeField] private string nameQuest;
    [SerializeField] private TypeQuest typeQuest;
    [SerializeField] private int idQuest;
    [SerializeField] private int currentPositionQuest = 1;
    [SerializeField] private int breakOtherQuestNumber;
    [SerializeField] private int dayQuest;




    public bool AddCurrentPositionQuest()
    {
        currentPositionQuest++;
        if (currentPositionQuest == breakOtherQuestNumber) 
        {
            return true;
        }
        return false;
    }

    public int GetCurrentPositionQuest() => currentPositionQuest;

    public int GetDayQuest() => dayQuest;

    public TypeQuest GetTypeQuest() => typeQuest;

}


public enum TypeQuest
{
    Negative,
    Neutral,
    Positive,
    Norm
}
