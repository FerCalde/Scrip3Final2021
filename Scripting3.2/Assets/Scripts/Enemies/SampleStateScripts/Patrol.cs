using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    //EnemyPatrol refEnemigo;
    //private Transform playerTransform;
    //private UnityEngine.AI.NavMeshAgent agente;
    //StateMachine refStateManager;
    //private Transform[] m_waypointsVector;
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //    refStateManager = GetComponent<StateMachine>();
    //    agente = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
    //    playerTransform = FindObjectOfType<Player>().transform;
        

    //    GameObject[] waypointsVector = GameObject.FindGameObjectsWithTag("Waypoint");
    //    m_waypointsVector = new Transform[waypointsVector.Length];
    //    for (int i = 0; i < waypointsVector.Length; i++)
    //    {
    //        m_waypointsVector[i] = waypointsVector[i].transform;
    //    }

    //    int newPatrolPoint = Random.Range(0, m_waypointsVector.Length);

    //    while (newPatrolPoint == refEnemigo.m_lastPatrolPoint)
    //    {
    //        newPatrolPoint = Random.Range(0, m_waypointsVector.Length);
    //    }

    //    refEnemigo.m_lastPatrolPoint = newPatrolPoint;

    //    Transform randomWaypoint = m_waypointsVector[refEnemigo.m_lastPatrolPoint];
    //    agente.isStopped = false;
    //    agente.SetDestination(randomWaypoint.position);

    //}
    //private void Awake()
    //{
    //    refEnemigo = FindObjectOfType<EnemyPatrol>();
    //    refEnemigo.m_animator.SetTrigger("Patrol");
    //}
    //// Update is called once per frame
    //void Update()
    //{
    //    float hearingDistance = Vector3.Distance(transform.position, playerTransform.position);
    //    if (hearingDistance < refEnemigo.hearingDistance  )
    //    {
    //        refStateManager.ChangeState("Chase");

    //    }
    //    if (agente.remainingDistance <0.1f&& !agente.pathPending /* && refEnemigo.onPoint*/)
    //    {
            
    //        refStateManager.ChangeState("Idle");
    //    }
    //}
}
