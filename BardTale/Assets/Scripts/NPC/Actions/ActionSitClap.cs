using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSitClap : AbstractNPCAction
{
    public override void Execute()
    {
        Clap();
    }

    public override void Setup()
    {

    }

    public ActionSitClap(NPC npc, string name) : base(npc, name) { }

    private void Clap()
    {
        int rand = Random.Range(1, 2);
        npc.Clap(rand);
    }
}
