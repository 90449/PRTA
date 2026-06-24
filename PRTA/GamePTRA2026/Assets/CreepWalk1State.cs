using UnityEngine;
using UnityEngine.AI;

public class CreepWalk1State : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;

    public float chasespeed = 9f;

    public float stopChasingDistance = 51f;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();

        agent.speed = chasespeed;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        agent.SetDestination(player.position);
        animator.transform.LookAt(player);

        float distanceFromPlayer = Vector3.Distance(player.position, animator.transform.position);

        //checks if the agent should stop chasing
        if (distanceFromPlayer > 25f)
        {
            animator.SetBool("IsCloseCatchingYou" , false);
        }   
        if (distanceFromPlayer < 15f)
        {
            animator.SetBool("IsCatchingUp", true);
        }

    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }
}
