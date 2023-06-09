using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageDialogOneDay : MonoBehaviour
{
    //  [SerializeField] private List<Dialogue> npcDialogues;
    //[SerializeField] private Dictionary<int, List<Dialogue>> dialoguesBard;
    [SerializeField] private List<DialoguesNPC> dialogueNPC;
    [SerializeField] private StorageDialoguesOneDayBard storage;


    public List<string> GetDialogueNPC(int id)
    {
        return dialogueNPC[id].dialogues;
    }
    public List<string> GetDialoguesBard(int id)
    {
        return storage.GetDialogues(id);
    }

    public bool CheckMiniGame(int id, out int lose, out int win)
    {
        return storage.CheckMiniGame(id, out lose, out win);
    }

    public bool CheckIsBuy(int id,out int summa,out int numberDialogBuy) 
    {
        return storage.CheckIsBuy(id, out summa, out numberDialogBuy);
    }
}
