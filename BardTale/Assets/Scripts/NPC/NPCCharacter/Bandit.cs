using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : NPC
{
    protected override void Setup()
    {
        //base.Setup();
        SetupUseType();
    }


    private void SetupUseType() 
    {
        if (state == StateNPC.Sit) 
        {
            currentAction = new ActionSitTalk(this, "Talk");
            currentAction.Setup();
            currentAction.Execute();
        }
        if(state == StateNPC.Idle) 
        {
            currentAction = new ActionDance(this, "Dance");
            currentAction.Setup();
            currentAction.Execute();
        }
    }
}
