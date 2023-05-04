using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class QuestObject 
{
    [SerializeField] private string nameObjectForQuest;
    [SerializeField] private bool isHas;
    [SerializeField] private int dayQuest;

    public QuestObject(string name, bool flag) 
    {
        nameObjectForQuest = name;
        isHas = flag;
       
    }

    public int GetDayQuest() => dayQuest;

    public bool IsHave() => isHas = true;

    public bool GetIsHas() => isHas;

    public string GetNameObject() => nameObjectForQuest;
}
