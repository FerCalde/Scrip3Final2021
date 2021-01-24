using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRT_Apuntar : MonoBehaviour
{
    EnemyRocketTurret refEnemigo;
    Mov playerRef;

    StateMachine refStateManager;
    Animator miAnim;
    float timer;

    //// Start is called before the first frame update
    void Start()
    {

        refStateManager = GetComponent<StateMachine>();
        refEnemigo = GetComponent<EnemyRocketTurret>();

        playerRef = FindObjectOfType<Mov>();
        miAnim = GetComponent<Animator>();
        timer = 0;
        Animaciones();
    }
    void Animaciones()
    {
        miAnim.ResetTrigger("Idle");
        miAnim.SetTrigger("Aiming");

        miAnim.ResetTrigger("ShootRocket");
        miAnim.ResetTrigger("StartMortero");
        miAnim.ResetTrigger("ShootMortero");
        miAnim.ResetTrigger("Death");

    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= refEnemigo.cadencia)
        {
            
            if (refEnemigo.disparos >= 2)
            {
                miAnim.ResetTrigger("Aiming");
                miAnim.SetTrigger("StartMortero");
            }
            else
            {
                refStateManager.ChangeState("Rocket");
            }
            
        }

        float hearingDistance = Vector3.Distance(transform.position, playerRef.transform.position);

        if (hearingDistance > refEnemigo.distance2Apuntar)
        {
            refStateManager.ChangeState("Idle");

        }
    }
    public void GoToMortero()//animacion event
    {
        refStateManager.ChangeState("Mortero");
    }

}
