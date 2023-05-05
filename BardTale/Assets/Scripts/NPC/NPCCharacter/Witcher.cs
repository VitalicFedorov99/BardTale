using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witcher : NPC
{
    protected override void Setup()
    {
        //base.Setup();
        currentAction = new ActionDance(this, "Dance");
        currentAction.Setup();
        currentAction.Execute();
    }
}
