using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CreepCrouchState : StateMachineBehaviour
{
    float timer;
    public float walkingTime = 18f;

    Transform player;
    NavMeshAgent agent;

    public float detectionAreaRadius = 50f;
    public float walkSpeed = 10f;
    
    List<Transform>  waypointsList = new List<Transform> ();
    // onstateenter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        //initialization
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();

        agent.speed = walkSpeed;
        timer = 0;

        //Getwaypoints to move to the first podsition

        GameObject wayPointCluster = animator.GetComponent<NPCWaypoints>().npcWaypointsCluster;
        foreach (Transform t in wayPointCluster.transform)
        {
            waypointsList.Add(t);
        }

        Vector3 firstPosition = waypointsList[Random.Range(0, waypointsList.Count)].position;
        agent.SetDestination(firstPosition);

    }

    // onstateupdate is called on each update frame between onstateenter and onstateexit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        //if agent arrived at the waypoint

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(waypointsList[Random.Range(0, waypointsList.Count)].position);
        }
        //Transaction to idle state
        timer += Time.deltaTime;
        if (timer > walkingTime)
        {
            animator.SetBool("IsWalking", false);
        }

        //chase the player
        float distanceFromPlayer = Vector3.Distance(player.position, animator.transform.position);
        if (distanceFromPlayer < detectionAreaRadius)
        {
            animator.SetBool("IsWalking", true);
        }
        else if (distanceFromPlayer < 25f)        
        {
            animator.SetBool("IsCloseCatchingYou", true );
        }
    }

    // onstateexit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        agent.SetDestination(agent.transform.position);
    }


}
