using UnityEngine;
using UnityEngine.AI;

public class Creepwalk2State : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;

    public float chasespeed = 10f;

    public float stopChasingDistance = 51f;

    public float attackingDistance = 2.5f;
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
        if (distanceFromPlayer > stopChasingDistance)
        {
            animator.SetBool("IsCatchingYou", false);
        }
        if (distanceFromPlayer < attackingDistance)
        {
            animator.SetBool("InAttackRange", true);
        }

    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }
}
