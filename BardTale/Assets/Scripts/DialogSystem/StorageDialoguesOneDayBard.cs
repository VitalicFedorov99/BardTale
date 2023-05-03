using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageDialoguesOneDayBard : MonoBehaviour
{
    [SerializeField] private List<int> idNPC;
    [SerializeField] private List<DialoguesBardWithNPC> dialogues;


    public List<string> GetDialogues(int id)
    {
        int counter = 0;
        foreach (var npc in idNPC)
        {
            if (npc == id)
                break;
            counter++;
        }
        return dialogues[counter].dialogues;
    }
}
