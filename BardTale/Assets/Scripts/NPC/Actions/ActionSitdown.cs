using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSitdown : AbstractNPCAction
{


    public override void Execute()
    {
        SitDown();
    }

    public override void Setup()
    {
      
    }

    public ActionSitdown(NPC npc, string name) : base(npc, name) { }

    private void SitDown() 
    {
       // npc.SitDown();
    }
}
