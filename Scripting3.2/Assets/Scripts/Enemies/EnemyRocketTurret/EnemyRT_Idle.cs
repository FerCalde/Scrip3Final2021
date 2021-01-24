using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRT_Idle : MonoBehaviour
{
    EnemyRocketTurret refEnemigo;
    Mov playerRef;
    
    StateMachine refStateManager;
    Animator miAnim;
    float cont;
    public GameObject modeloTorreta;
    public float speedAnim;
    Quaternion initialRotation;
    //// Start is called before the first frame update
    void Start()
    {
        initialRotation = modeloTorreta.transform.rotation;
        refStateManager = GetComponent<StateMachine>();
        refEnemigo = GetComponent<EnemyRocketTurret>();
        
        playerRef = FindObjectOfType<Mov>();
        miAnim = GetComponent<Animator>();
        
        Animaciones();
    }
    void Animaciones()
    {
        miAnim.SetTrigger("Idle");
        miAnim.ResetTrigger("Aiming");

        miAnim.ResetTrigger("ShootRocket");
        miAnim.ResetTrigger("StartMortero");
        miAnim.ResetTrigger("ShootMortero");
        miAnim.ResetTrigger("Death");
        
    }
    // Update is called once per frame
    void Update()
    {

        //AnimFuncion(speedAnim);

        float hearingDistance = Vector3.Distance(transform.position, playerRef.transform.position);

        if (hearingDistance <= refEnemigo.distance2Apuntar)
        {
            cont = 0;
            modeloTorreta.transform.rotation = initialRotation;
            refStateManager.ChangeState("Apuntar");
            
        }

    }
    //public void AnimFuncion(float speed)
    //{

    //    cont += Time.deltaTime * speed;
    //    modeloTorreta.transform.rotation = new Quaternion(modeloTorreta.transform.rotation.x, cont, modeloTorreta.transform.rotation.z, transform.rotation.w);


    //    Quaternion rot = new Quaternion(modeloTorreta.transform.rotation.x, modeloTorreta.transform.rotation.y + speed, modeloTorreta.transform.rotation.z, modeloTorreta.transform.rotation.w);
    //    modeloTorreta.transform.rotation = Quaternion.Slerp(modeloTorreta.transform.rotation, rot, 1);
    //}
}
