using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopChase : MonoBehaviour
{
    private Transform playerTransform;
    private UnityEngine.AI.NavMeshAgent agente;
    StateMachine refStateManager;

    CopEnemy refEnemigo;
    Animator miAnim;

    Vector3 v = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        refEnemigo = GetComponent<CopEnemy>();
        refStateManager = GetComponent<StateMachine>();
        agente = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        playerTransform = FindObjectOfType<Mov>().transform;
        miAnim = GetComponent<Animator>();
        
        agente.isStopped = false;
        Animaciones();
    }
    void Animaciones()
    {
        miAnim.ResetTrigger("Idle");
        miAnim.SetTrigger("Chase");
        miAnim.ResetTrigger("Hitted");
        miAnim.ResetTrigger("Death");
        miAnim.ResetTrigger("Shoot");
        miAnim.ResetTrigger("Aim2Down");
        miAnim.ResetTrigger("Stoping");
        miAnim.ResetTrigger("Aiming");

    }
    // Update is called once per frame
    void Update()
    {
        
        float hearingDistance = Vector3.Distance(transform.position, playerTransform.position);
        if (hearingDistance < refEnemigo.distance2Shoot )
        {
            miAnim.SetTrigger("Stoping");
            refStateManager.ChangeState("Aiming");
        }
        //if (!refEnemigo.viendoPlayer || hearingDistance > refEnemigo.distance2Chase||!refEnemigo.identificadoPlayer)
        //{
        //    refStateManager.ChangeState("Patrol");

        //}
        //if (hearingDistance > refEnemigo.distance2Chase)
        //{
        //    // animator.ResetTrigger("Idle");y asi todos los triggers
        //    refStateManager.ChangeState("Retreat");
        //}

        agente.SetDestination(playerTransform.position);
    }
}
