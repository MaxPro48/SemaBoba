using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    public NavMeshAgent agent;
    [SerializeField] Transform[] PatrolPoints;
    Vector3 goal;

    Vector3 distance;

    bool Waiting;


    bool RoamPointSet = false;
    int choice;

    
    // Start is called before the first frame update
    void Start()
    {
       
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Patrolling();
       
    }

    

    void Patrolling()
    {

        if (!RoamPointSet)
        {
            //choice = Random.Range(0, patrolPoints.Length);

            if (choice == PatrolPoints.Length - 1)
            {
                choice = 0;
            }
            else
            {
                choice++;
            }
            goal = PatrolPoints[choice].position;
            RoamPointSet = true;
        }
        else if (!Waiting)
        {
            agent.isStopped = false;
            //anim.SetBool("Idle", false);
            agent.SetDestination(goal);
            distance = transform.position - goal;


            if (distance.magnitude < 0.5f && !Waiting)
            {
                Waiting = true;
                agent.isStopped = true;
                //anim.SetBool("Idle", true);
                StopAllCoroutines();
                StartCoroutine((IdleWait()));
            }
        }

    }

    IEnumerator IdleWait()
    {
        yield return new WaitForSeconds(5f);
        Waiting = false;
        RoamPointSet = false;
    }
}
