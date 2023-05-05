using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tractirchic : NPC
{
    // Start is called before the first frame update
    protected override void Setup()
    {
        //base.Setup();
        currentAction = new ActionDance(this, "Dance");
        currentAction.Setup();
        currentAction.Execute();
    }
}
