using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DialoguesNPC")]
public class DialoguesNPC : ScriptableObject
{
    [TextArea]
    public List<string> dialogues;
    public int id;
    public List<int> sequenceDialogues;
}

