using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogMemory : MonoBehaviour
{
    [SerializeField] private List<int> idNPC;
    [SerializeField] private List<int> numberDialogs;
    [SerializeField] private List<bool> winGame;
    [SerializeField] private List<string> lastMassege;

    public void ClearDialogue() 
    {
        for(int i = 0; i < idNPC.Count;i++) 
        {
            numberDialogs[i] = 1;
            winGame[i] = false;
        }
    }

    public void AddNumberDealog(int number, int id) 
    {
        numberDialogs[id] = number;
    }

    public void AddWinGame(int id) 
    {
        winGame[id] = true;
    }

    public int GetNumberDialogs(int id) => numberDialogs[id];

    public void SetNumberDialogs(int id, int number) => numberDialogs[id] = number;

    public void SetLastMessage(int id, string dialog) => lastMassege[id] = dialog;

    public string GetLastMessage(int id) => lastMassege[id];

    public bool GetWinGame(int id) => winGame[id];
}
