using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DialoguesWithNPC")]
public class DialoguesBardWithNPC : ScriptableObject
{
    [TextArea]
    public List<string> dialogues;
    public int id;

    public bool isMiniGame;
    public int numberDialogueWin;
    public int numberDialogueLose;

    public bool IsBuy;
    public int summa;
    public int numberDialogueBuy;
}
