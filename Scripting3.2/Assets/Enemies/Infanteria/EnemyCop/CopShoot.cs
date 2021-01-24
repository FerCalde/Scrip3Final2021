using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopShoot : MonoBehaviour
{
    private Transform playerTransform;
    private UnityEngine.AI.NavMeshAgent agente;
    StateMachine refStateManager;

    CopEnemy refEnemigo;
    Animator miAnim;

    float timer;
    public float tiempoDisparo;
    public GameObject bulletPrefab;
    public GameObject fireSpot;
    bool canShoot = true;

    Vector3 v = Vector3.zero;
   
    
    [SerializeField] ParticleSystem vfxParticleMuzzleFlash;
    public GameObject disparoEnemigo;


    // Start is called before the first frame update
    void Start()
    {
        refEnemigo = GetComponent<CopEnemy>();
        refStateManager = GetComponent<StateMachine>();
        agente = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        playerTransform = FindObjectOfType<Mov>().transform;
        miAnim = GetComponent<Animator>();
        miAnim.SetTrigger("Shoot");
        agente.isStopped = true;
        
        Animaciones();
    }
    void Animaciones()
    {
        miAnim.ResetTrigger("Idle");
        miAnim.ResetTrigger("Aiming");

        miAnim.ResetTrigger("Death");
        miAnim.ResetTrigger("Shooting");
    }
    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(playerTransform.position);//tocar aqui si quiero hacer la anim mas smooth.
        timer += Time.deltaTime;
        if (canShoot)
        {
            Shoot();
            
        }
        if (timer >= tiempoDisparo)
        {
            miAnim.SetTrigger("Aim2Down");
            timer = 0;
            refStateManager.ChangeState("Aiming");
          
            

        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, fireSpot.transform.position, transform.rotation);
        canShoot = false;
        //SoundVFX(SoundDisparo);
        NuevoSonido(disparoEnemigo, this.transform.position, 1f);
        ParticleVFX();

    }
   
    protected void ParticleVFX()
    {
        vfxParticleMuzzleFlash.Play();
    }
    void NuevoSonido(GameObject sonido, Vector3 pos, float duracion)
    {
        Destroy(Instantiate(sonido, pos, Quaternion.identity), 2f);
    }
}
