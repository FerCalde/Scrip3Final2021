using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LookForPlayer : MonoBehaviour
{
    VidaEnemyBase vida;
    Vector3 start;
    NavMeshAgent kamiNav;
    Animator miAnim;

    StateMachine refStateManager;
    void Start()
    {
        miAnim = GetComponent<Animator>();
        vida = GetComponent<VidaEnemyBase>();
        kamiNav = GetComponent<NavMeshAgent>();
        start = transform.position;
        kamiNav.isStopped = false;
        kamiNav.SetDestination(vida.lookForPlayer);
        vida.hitted = false;
        refStateManager = GetComponent<StateMachine>();
        Animaciones();
    }
    void Animaciones()
    {
        miAnim.ResetTrigger("Idle");
        miAnim.SetTrigger("Chase");
        miAnim.ResetTrigger("Explote");
    }

    // Update is called once per frame
    void Update()
    {
        if (kamiNav.remainingDistance <= 1)
        {
            refStateManager.ChangeState("BackToIdle");
        }
    }
}
