using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopEnemy : MonoBehaviour
{
    DashCast playerRef;

    public float distancePlayer;
    public float distance2Chase;
    public float distance2Shoot;
    public float distance2Retreat;
    [HideInInspector]public Vector3 posInicial;
    StateMachine refStateManager;
    public int m_lastPatrolPoint = -1;
    private UnityEngine.AI.NavMeshAgent agente;

    public float cantidadConoVision;
    public float angle2Player;
    public bool viendoPlayer;
    public bool identificadoPlayer;
    VidaEnemyBase vidaEnemy;
    Collider col;
    Animator miAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerRef = FindObjectOfType<DashCast>();
        refStateManager = GetComponent<StateMachine>();
        vidaEnemy = GetComponent<VidaEnemyBase>();
        posInicial = transform.position;
        col = GetComponent<Collider>();
        agente = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        miAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        distancePlayer = Vector3.Distance(playerRef.transform.position, transform.position);
        if (vidaEnemy.VidaActual <= 0)
        {
            refStateManager.ChangeState("Death");
            col.enabled = false;
            agente.isStopped = true;
        }
        else
        {
            col.enabled = true;
            agente.enabled = true;
            if (!refStateManager.currentState.Contains("Patrol") && !refStateManager.currentState.Contains("Idle"))
            {
                Vector3 lookVector = playerRef.transform.position - transform.position;
                lookVector.y = 0;
                Quaternion rot = Quaternion.LookRotation(lookVector);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, 0.05f);
                //Debug.Log("X= " + transform.rotation.x + "y= " + transform.rotation.y + "z= " + transform.rotation.z);
                //Debug.DrawLine(this.transform.position,playerRef.transform.position);
            }
            FOV(cantidadConoVision);
        }
    }
    public void FOV(float coneLength )
    {
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.green, 8);
        Vector3 lookVector = playerRef.transform.position - transform.position;
        angle2Player = Vector3.Angle(lookVector, transform.forward*50);
        if (angle2Player < coneLength)
        {
            viendoPlayer = true;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, 8))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance*200, Color.yellow);
                identificadoPlayer = true;
            }
            else
            {
                identificadoPlayer = false;
            }
        }
        else
        {
            viendoPlayer = false;
        }
   

    }
    public void endHit()
    {
        refStateManager.ChangeState("Chase");
    }
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("BalaPlayer")&& (refStateManager.currentState.Contains("Idle")|| refStateManager.currentState.Contains("Patrol")))
        {
            miAnim.SetTrigger("Hitted");
        }
       
    }
    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if (hit.gameObject.CompareTag("BalaPlayer"))
    //    {
    //        vida -= hit.gameObject.GetComponent<ShotBehavior>().damage;
    //        Destroy(hit.gameObject);
    //    }
    //    Debug.Log("entraColision");
    //}
}
