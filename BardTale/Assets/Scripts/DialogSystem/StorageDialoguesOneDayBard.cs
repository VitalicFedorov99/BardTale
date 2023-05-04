using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageDialoguesOneDayBard : MonoBehaviour
{
    [SerializeField] private List<int> idNPC;
    [SerializeField] private List<DialoguesBardWithNPC> dialogues;


    public List<string> GetDialogues(int id)
    {
        return dialogues[id].dialogues;
    }

    public bool CheckMiniGame(int id, out int lose, out int win)
    {
        lose = 0; win = 0;


        if (dialogues[id].isMiniGame)
        {
            lose = dialogues[id].numberDialogueLose;
            win = dialogues[id].numberDialogueWin;
        }
        return dialogues[id].isMiniGame;
    }


}
