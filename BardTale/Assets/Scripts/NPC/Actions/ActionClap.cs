using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionClap : AbstractNPCAction
{
    public override void Execute()
    {
        npc.Clap();
    }

    public override void Setup()
    {

    }

    public ActionClap(NPC npc, string name) : base(npc, name)
    {

    }

    private void CLap()
    {
        npc.Clap();
    }


}
