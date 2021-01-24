using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BackToIdle : MonoBehaviour
{
    
    NavMeshAgent kamiNav;
    Animator miAnim;
    Kamikaze behaviour;

    StateMachine refStateManager;
    void Start()
    {
        behaviour = GetComponent<Kamikaze>();
        miAnim = GetComponent<Animator>();
        kamiNav = GetComponent<NavMeshAgent>();
        kamiNav.isStopped = false;
        kamiNav.SetDestination(behaviour.start);
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
            refStateManager.ChangeState("Idle");
        }
    }
}
