using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private List<Quest> allQuest;
    [SerializeField] private QuestObserver questObserver;
    [SerializeField] private List<QuestObject> allQuestObject;
    [SerializeField] private int currentDay;

    [SerializeField] private List<QuestObject> dayObjects= new List<QuestObject>();


    private void Start()
    {
        SetupObserver();
    }
    public void SetupObserver() 
    {
        Clear();
        foreach (var quest in allQuest) 
        {
            if (quest.GetDayQuest() == currentDay) 
            {
                switch (quest.GetTypeQuest()) 
                {
                    case TypeQuest.Negative:
                        questObserver.SetQuestNegative(quest);
                        break;
                    case TypeQuest.Neutral:
                        questObserver.SetQuestNeutral(quest);
                        break;
                    case TypeQuest.Positive:
                        questObserver.SetQuestPositive(quest);
                        break;
                }
            }
        }
        foreach(var objectQuest in allQuestObject) 
        {
            if (objectQuest.GetDayQuest() == currentDay) 
            {
                dayObjects.Add(objectQuest);
            }
        }

        questObserver.SetQuestObject(dayObjects);
    }

    public void Clear() => dayObjects.Clear();
    

}
