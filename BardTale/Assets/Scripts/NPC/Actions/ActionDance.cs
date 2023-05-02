using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDance : AbstractNPCAction
{
    public override void Execute()
    {
        Dance();
    }

    public override void Setup()
    {
        
    }
    public ActionDance(NPC npc, string name) : base(npc, name)
    {

    }


    public void Dance() 
    {
        var rand = Random.Range(1, 2);
        npc.Dance(2);
    }







}
