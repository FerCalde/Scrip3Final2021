using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
//    private Transform playerTransform;
//    private UnityEngine.AI.NavMeshAgent agente;
//    StateMachine refStateManager;
    
//    EnemyPatrol refEnemigo;

//    // Start is called before the first frame update
//    void Start()
//    {
//        refEnemigo = FindObjectOfType<EnemyPatrol>();
//        refStateManager = GetComponent<StateMachine>();
//        agente = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
//        playerTransform = FindObjectOfType<Player>().transform;
        
//        refEnemigo.m_animator.SetTrigger("Chase");
//        agente.isStopped = false;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        float hearingDistance = Vector3.Distance(transform.position, playerTransform.position);
//        if (hearingDistance < 2)
//        {
//            refStateManager.ChangeState("Attack");
//        }

//        if (hearingDistance > 10)
//        {
//            // animator.ResetTrigger("Idle");y asi todos los triggers
//            refStateManager.ChangeState("Idle");
//        }

//        agente.SetDestination(playerTransform.position);
//    }
}
