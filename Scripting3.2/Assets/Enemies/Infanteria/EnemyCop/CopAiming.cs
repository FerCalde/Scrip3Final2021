using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopAiming : MonoBehaviour
{
    private Transform playerTransform;
    private UnityEngine.AI.NavMeshAgent agente;
    StateMachine refStateManager;

    CopEnemy refEnemigo;
    Animator miAnim;


    float timer=0;
    public float tiempoAiming;
    public float fov = 35f;
    public float dotFov = 0f;
    public float dot = 0f;

    Vector3 v = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        refEnemigo = GetComponent<CopEnemy>();
        refStateManager = GetComponent<StateMachine>();
        agente = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        playerTransform = FindObjectOfType<Mov>().transform;
        miAnim = GetComponent<Animator>();

        agente.isStopped = true;

    }
    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(playerTransform.position);

        v = playerTransform.position - (transform.position);
        dotFov = Mathf.Cos(fov * 0.5f * Mathf.Deg2Rad);
        dot = Vector3.Dot(transform.forward, v.normalized);
        if(dot >= dotFov)
        {
            //Debug.Log(timer);
            timer += Time.deltaTime;
            if (timer >= tiempoAiming/2)
            {
                miAnim.ResetTrigger("Idle");
                miAnim.ResetTrigger("Chase");

                miAnim.ResetTrigger("Death");
                miAnim.ResetTrigger("Shoot");
                miAnim.ResetTrigger("Aim2Down");
                miAnim.ResetTrigger("Stoping");
                miAnim.SetTrigger("Aiming");
            }
            if (timer >= tiempoAiming)
            {
               
                refStateManager.ChangeState("Shoot");
            }

        }
        else
        {
            miAnim.ResetTrigger("Idle");
            miAnim.ResetTrigger("Chase");
            miAnim.ResetTrigger("Reload");
            miAnim.ResetTrigger("Death");
            miAnim.ResetTrigger("Shoot");           
            miAnim.ResetTrigger("Stoping");
            miAnim.ResetTrigger("Aiming");
            miAnim.SetTrigger("Aim2Down");
            timer = 0;
        }
        float hearingDistance = Vector3.Distance(transform.position, playerTransform.position);
        if (hearingDistance > refEnemigo.distance2Retreat)
        {
            refStateManager.ChangeState("Patrol");
        }
    }

    //public void SalirAnimacion()
    //{
    //    refStateManager.ChangeState("Aiming");
    //}
}
