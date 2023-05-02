using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class  AbstractNPCAction
{
    protected NPC npc;
    public string nameAction;

    public AbstractNPCAction(NPC npc, string name)
    {
        this.npc = npc;
        nameAction = name;
    }

    public abstract void Execute();

    public abstract void Setup();
}
