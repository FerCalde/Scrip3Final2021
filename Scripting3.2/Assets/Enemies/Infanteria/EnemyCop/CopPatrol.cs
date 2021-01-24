using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopPatrol : MonoBehaviour
{
    CopEnemy refEnemigo;
    private Transform playerTransform;
    private UnityEngine.AI.NavMeshAgent agente;
    StateMachine refStateManager;
    Animator miAnim;
    private Transform[] m_waypointsVector;
    public GameObject[] waypointsVector;

    public float fov = 35f;
    public float dotFov = 0f;
    public float dot = 0f;
    Vector3 v = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

        refStateManager = GetComponent<StateMachine>();
        
        playerTransform = FindObjectOfType<Mov>().transform;


        //GameObject[] waypointsVector = GameObject.FindGameObjectsWithTag("Waypoint");
        m_waypointsVector = new Transform[waypointsVector.Length];
        for (int i = 0; i < waypointsVector.Length; i++)
        {
            m_waypointsVector[i] = waypointsVector[i].transform;
        }

        int newPatrolPoint = Random.Range(0, m_waypointsVector.Length);

        while (newPatrolPoint == refEnemigo.m_lastPatrolPoint)
        {
            newPatrolPoint = Random.Range(0, m_waypointsVector.Length);
        }

        refEnemigo.m_lastPatrolPoint = newPatrolPoint;

        Transform randomWaypoint = m_waypointsVector[refEnemigo.m_lastPatrolPoint];
        agente.isStopped = false;
        agente.SetDestination(randomWaypoint.position);
        Vector3 lookVector = m_waypointsVector[refEnemigo.m_lastPatrolPoint].position - transform.position;
        lookVector.y = transform.position.y;
        Quaternion rot = Quaternion.LookRotation(lookVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);

    }
    private void Awake()
    {
        agente = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        miAnim = GetComponent<Animator>();
        refEnemigo = GetComponent<CopEnemy>();
        Animaciones();
    }
    void Animaciones()
    {
        miAnim.ResetTrigger("Idle");
        miAnim.SetTrigger("Chase");
        miAnim.ResetTrigger("Death");
        miAnim.ResetTrigger("Shoot");
        miAnim.ResetTrigger("Aim2Down");
        miAnim.ResetTrigger("Stoping");
        miAnim.ResetTrigger("Aiming");

    }
    // Update is called once per frame
    void Update()
    {
        //v = playerTransform.position - (transform.position);
        //dotFov = Mathf.Cos(fov * 0.5f * Mathf.Deg2Rad);
        //dot = Vector3.Dot(transform.forward, v.normalized);
        float hearingDistance = Vector3.Distance(transform.position, playerTransform.position);

        if (refEnemigo.viendoPlayer && hearingDistance < refEnemigo.distance2Chase)
        {
            refStateManager.ChangeState("Chase");

        }
        //}
        if (agente.remainingDistance < 0.1f && !agente.pathPending /* && refEnemigo.onPoint*/)
        {

            refStateManager.ChangeState("Idle");
        }
    }
}
