using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRT_Mortero : MonoBehaviour
{
    private Transform playerTransform;

    StateMachine refStateManager;

    EnemyRocketTurret refEnemigo;
    Animator miAnim;

    float timer;
    public float tiempoRetroceso;
    public GameObject bulletPrefab;
    public GameObject fireSpot;
    bool canShoot = true;
    public ParticleSystem disparoM;








    // Start is called before the first frame update
    void Start()
    {
        refEnemigo = GetComponent<EnemyRocketTurret>();
        refStateManager = GetComponent<StateMachine>();
        playerTransform = FindObjectOfType<Mov>().transform;
        miAnim = GetComponent<Animator>();

        Animaciones();
    }
    void Animaciones()
    {
        miAnim.ResetTrigger("Idle");
        miAnim.ResetTrigger("Aiming");
        
        miAnim.ResetTrigger("ShootRocket");

        miAnim.ResetTrigger("StartMortero");
        miAnim.SetTrigger("ShootMortero");
        miAnim.ResetTrigger("EndMortero");
        

        miAnim.ResetTrigger("Death");
        

    }
    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(playerTransform.position);//tocar aqui si quiero hacer la anim mas smooth.
        timer += Time.deltaTime;
        if (canShoot)
        {
            refEnemigo.disparos=0;
            Shoot();
        }
        //if (timer >= tiempoRetroceso)
        //{

        //    timer = 0;
            

        //}
        
    }

    void Shoot()
    {

        disparoM.Play();

        Instantiate(bulletPrefab, fireSpot.transform.position, transform.rotation, transform);


        canShoot = false;



    }
    public void GoToTerminarMorteroAnim()//eventoAnimacion
    {
        miAnim.ResetTrigger("ShootMortero");
        miAnim.SetTrigger("EndMortero");
    }
    public void GoToEstadoApuntar()//eventoAnimacion
    {
        refStateManager.ChangeState("Apuntar");
    }

}
