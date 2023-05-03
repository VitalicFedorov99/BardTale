using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSitAngry : AbstractNPCAction
{
    public override void Execute()
    {
        Angry();
    }

    public override void Setup()
    {

    }

    public ActionSitAngry(NPC npc, string name) : base(npc, name) { }

    private void Angry()
    {
        int rand = Random.Range(1, 2);
        npc.Angry(rand);
    }
}
