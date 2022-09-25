using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FinishMoveScript : MonoBehaviour
{
    [SerializeField] FinishAreaScript Finish;

    //[SerializeField] Transform Follower;
    [SerializeField] Transform target;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Finish.OnTriggerFin)
        {
            agent.destination = target.position;


            //Follower.transform.position = this.gameObject.transform.position;

        }
    }
}
