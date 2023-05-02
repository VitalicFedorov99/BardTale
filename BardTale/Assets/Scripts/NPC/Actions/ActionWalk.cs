using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionWalk : AbstractNPCAction
{

    public GameObject target;
    public override void Execute()
    {
        Walk();
    }

    public ActionWalk(NPC npc,string name) : base(npc,name)
    {
       
    }

    public override void Setup()
    {
        var points = ObjLocatorForNPC.instance.poinstWalking;
        var numberPoint = Random.Range(0, points.Count);
        target = points[numberPoint];
    }

    private void Walk() 
    {
      
        npc.Walk(target);
    }
}
