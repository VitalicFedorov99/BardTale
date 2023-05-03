using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSitTalk : AbstractNPCAction
{
    public override void Execute()
    {
        Talk();
    }

    public override void Setup()
    {

    }

    public ActionSitTalk(NPC npc, string name) : base(npc, name) { }

    private void Talk()
    {
        
        npc.SitTalk();
    }
}
