using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;
public class NPC : MonoBehaviour
{
    [SerializeField] protected string nameNPC;
    [SerializeField] protected Animator animator;
    [SerializeField] protected NavMeshAgent agent;

    [SerializeField] protected AbstractNPCAction currentAction;

    [SerializeField] protected StateNPC state;




    private GameObject pointWalk;

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

    public void EndClap()
    {
        animator.SetBool("Clap", false);
    }

    public void Dance(int number) 
    {
        animator.SetBool("Dance", true);
        animator.SetInteger("TypeDance", number);
    }
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
        state = StateNPC.Idle;
        Setup();
    }



}

public enum StateNPC
{
    Walk,
    Idle
}
