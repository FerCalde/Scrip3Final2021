using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiradorApuntar : MonoBehaviour
{
    private Transform playerTransform;
    private UnityEngine.AI.NavMeshAgent agente;
    StateMachine refStateManager;

    EnemyTirador refEnemigo;
    Animator miAnim;


    float timer = 0;
    public float tiempoAiming;
    public float tiempo2Buscar;

    float timerFijado;

    Vector3 v = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

        refEnemigo = GetComponent<EnemyTirador>();
        refStateManager = GetComponent<StateMachine>();
        agente = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        playerTransform = FindObjectOfType<Mov>().transform;
        miAnim = GetComponent<Animator>();
        
        agente.isStopped = true;
        Animaciones();
    }
    void Animaciones()
    {
        miAnim.ResetTrigger("Idle");
        miAnim.SetTrigger("Aiming");
        miAnim.ResetTrigger("Reload");
        miAnim.ResetTrigger("Death");
        miAnim.ResetTrigger("Shooting");
    }
    // Update is called once per frame
    void Update()
    {
        if (refEnemigo.miraEnPlayer)
        {
            timer += Time.deltaTime;
            if (timer >= tiempoAiming)
            {
                refStateManager.ChangeState("Shoot");
            }
        }
        else
        {
            timer = 0;
        }
        


        float hearingDistance = Vector3.Distance(transform.position, playerTransform.position);

        if (hearingDistance > refEnemigo.distance2Apuntar+1&&!refEnemigo.miraEnPlayer)
        {
            refStateManager.ChangeState("Idle");

        }
        //si pasa x tiempo con rayo chocando con el player dispara

        //si pasa x tiempo sin verlo, pasa al estado buscar.
        //float hearingDistance = Vector3.Distance(transform.position, playerTransform.position);
        //if (hearingDistance > refEnemigo.distance2Retreat)
        //{
        //    refStateManager.ChangeState("Buscar");
        //}
    }
}
