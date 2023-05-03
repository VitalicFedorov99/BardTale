using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAngry : AbstractNPCAction
{
    public override void Execute()
    {
        Angry();
    }

    public override void Setup()
    {
    }

    public ActionAngry(NPC npc, string name) : base(npc, name) { }

    private void Angry() 
    {
        npc.StartAnim(ConstantNameAction.ANGRY);
    }
    
}
