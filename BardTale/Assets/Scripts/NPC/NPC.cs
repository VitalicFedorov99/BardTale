using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;
public class NPC : MonoBehaviour , IInteraction
{
    [SerializeField] protected string nameNPC;
    [SerializeField] protected Animator animator;
    [SerializeField] protected NavMeshAgent agent;

    [SerializeField] protected AbstractNPCAction currentAction;

    [SerializeField] protected StateNPC state;




    private GameObject pointWalk;
    [SerializeField] private GameObject objSitdown;  
    public void Walk(GameObject point)
    {
        agent.SetDestination(point.transform.position);
        animator.SetBool("Walk", true);
        state = StateNPC.Walk;
        pointWalk = point;
    }

    public void Clap()
    {
        animator.SetBool("Clap", true);
    }

    public void SitTalk() 
    {
        animator.SetTrigger("Talk");
    }


    public void Talk(int number) 
    {
        animator.SetTrigger("Talk");
        animator.SetInteger("Type", number);
    }
    public void Clap(int number) 
    {
        animator.SetBool("Clap", true);
        animator.SetInteger("TypeClap", number);
    }

   /* public void SitDown() 
    {
        animator.SetTrigger("SitDown");
    }*/

    public void Dance(int number) 
    {
        animator.SetBool("Dance", true);
        animator.SetInteger("TypeDance", number);
    }

    public void Angry(int number) 
    {
        animator.SetBool("Angry", true);
        animator.SetInteger("TypeAngry", number);
    }

    public void Angry() 
    {
        animator.SetBool("Angry", true);
    }

    public void EndAngry() 
    {
        animator.SetBool("Angry", false);
    }

    public void StartAnim(string name) => animator.SetBool(name, true);

    public void EndAnim(string name) => animator.SetBool(name, false);

    protected virtual void Setup()
    {
        currentAction = new ActionWalk(this, "Walk");
        currentAction.Setup();
        currentAction.Execute();
    }

    private void Update()
    {
        if (pointWalk != null && state == StateNPC.Walk)
        {
            if (Vector3.Distance(transform.position, pointWalk.transform.position) < 1)
            {
                state = StateNPC.Idle;
                pointWalk = null;
            }
        }
    }
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        //state = StateNPC.Idle;
        Setup();
    }

    public void Interaction()
    {
        
    }

    public string GetName()
    {
        return nameNPC;
    }
}

public enum StateNPC
{
    Walk,
    Idle,
    Sit
}


