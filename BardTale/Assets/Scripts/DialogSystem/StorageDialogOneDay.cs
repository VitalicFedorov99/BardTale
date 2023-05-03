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
}
