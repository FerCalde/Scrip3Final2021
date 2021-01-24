using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopIdle : MonoBehaviour
{
    CopEnemy refEnemigo;
    Mov playerRef;
    private UnityEngine.AI.NavMeshAgent agente;
    StateMachine refStateManager;
    Animator miAnim;
    public float time2Patrol;
    float timer=0;
    
    public float fov = 35f;
    public float dotFov = 0f;
    public float dot = 0f;
    Vector3 v = Vector3.zero;

    //// Start is called before the first frame update
    void Start()
    {
        
        refStateManager = GetComponent<StateMachine>();
        refEnemigo = GetComponent<CopEnemy>();
        agente = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        playerRef = FindObjectOfType<Mov>();
        miAnim = GetComponent<Animator>();
        agente.isStopped = true;
        Animaciones();
    }
    void Animaciones()
    {
        miAnim.SetTrigger("Idle");
        miAnim.ResetTrigger("Chase");

        miAnim.ResetTrigger("Death");
        miAnim.ResetTrigger("Shoot");
        miAnim.ResetTrigger("Aim2Down");
        miAnim.ResetTrigger("Stoping");
        miAnim.ResetTrigger("Aiming");

    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time2Patrol)
        {
            timer = 0;
            refStateManager.ChangeState("Patrol");
        }

        //v = playerRef.transform.position - transform.position;


        //dotFov = Mathf.Cos(fov * 0.5f * Mathf.Deg2Rad);
        //dot = Vector3.Dot(transform.forward, v.normalized);
        float hearingDistance = Vector3.Distance(transform.position, playerRef.transform.position);
        
        if (refEnemigo.viendoPlayer && hearingDistance < refEnemigo.distance2Chase)
        {
            refStateManager.ChangeState("Chase");

        }
    }
}
