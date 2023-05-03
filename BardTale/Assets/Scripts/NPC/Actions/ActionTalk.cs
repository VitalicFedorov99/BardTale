using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTalk : AbstractNPCAction
{
    public override void Execute()
    {
        Talk();
    }

    public override void Setup()
    {
       
    }

    public ActionTalk(NPC npc, string name) : base(npc, name) { }

    private void Talk()
    {
        int rand = Random.Range(1,2);
        npc.Talk(rand);
    }
}
