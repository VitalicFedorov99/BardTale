using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oficiant : NPC
{
    protected override void Setup()
    {
        //base.Setup();
        currentAction = new ActionDance(this, "Dance");
        currentAction.Setup();
        currentAction.Execute();
    }
}
