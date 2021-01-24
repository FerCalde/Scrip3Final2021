using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRT_Rocket : MonoBehaviour
{
    private Transform playerTransform;

    StateMachine refStateManager;

    EnemyRocketTurret refEnemigo;
    Animator miAnim;

    float timer;
    public float tiempoRetroceso;
    public GameObject bulletPrefab;
    public GameObject fireSpot;
    public GameObject fireSpot2;
    public GameObject sfxMisil;
    public GameObject sfxVozMisil;
    bool canShoot = true;

    public ParticleSystem disparo;
    




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
        
        miAnim.SetTrigger("ShootRocket");
        miAnim.ResetTrigger("StartMortero");
        miAnim.ResetTrigger("ShootMortero");
        miAnim.ResetTrigger("Death");

    }
    // Update is called once per frame
    void Update()
    {
        fireSpot.transform.LookAt(playerTransform/*, Vector3.right*/);
        //transform.LookAt(playerTransform.position);//tocar aqui si quiero hacer la anim mas smooth.
        timer += Time.deltaTime;
        if (canShoot)
        {
           // NuevoSonido(sfxVozMisil, this.transform.position, 1f);
            refEnemigo.disparos++;
            Shoot();
        }
        if (timer >= tiempoRetroceso)
        {
            
            timer = 0;
            refStateManager.ChangeState("Apuntar");
            
        }
    }


    void Shoot()
    {
        disparo.Play();

        Instantiate(bulletPrefab, fireSpot.transform.position, fireSpot.transform.rotation);
        Instantiate(bulletPrefab, fireSpot2.transform.position, fireSpot2.transform.rotation);

        NuevoSonido(sfxMisil, this.transform.position, 0.5f);
        canShoot = false;




    }
    void NuevoSonido(GameObject sonido, Vector3 pos, float duracion)
    {
        bool modificarPitch = true;
        GameObject obj = Instantiate(sonido, pos, Quaternion.identity);
        if (modificarPitch)
        {
            obj.GetComponent<AudioSource>().pitch *= 1 + Random.Range(-0.2f, 0.2f);
        }
        Destroy(obj, 3f);
    }
}
