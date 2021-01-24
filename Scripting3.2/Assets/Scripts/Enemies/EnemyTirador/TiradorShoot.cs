using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiradorShoot : MonoBehaviour
{
    private Transform playerTransform;
    private UnityEngine.AI.NavMeshAgent agente;
    StateMachine refStateManager;

    EnemyTirador refEnemigo;
    Animator miAnim;
    public SniperGunController refWeapon;
    float timer;
    public float tiempoRetroceso;
    public GameObject bulletPrefab;
    public GameObject fireSpot;
    bool canShoot=false;
    


   // public AudioSource cmpAudioSource;
    //[SerializeField] protected AudioClip DisparoLargo;
    [SerializeField] ParticleSystem vfxParticleMuzzleFlash;
    public GameObject sonidoFranco;



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

    // Update is called once per frame
    void Update()
    {
        if(refEnemigo.currentAmmo <= 0)
        {
            refStateManager.ChangeState("Recargar");
        }
        Debug.Log(refEnemigo.currentAmmo);
        //transform.LookAt(playerTransform.position);//tocar aqui si quiero hacer la anim mas smooth.
        timer += Time.deltaTime;
        if (canShoot)
        {
            if (refEnemigo.currentAmmo > 0)
            {
                Shoot();
              
            }
            //else
            //{
                
            //}
        }
        if (timer >= tiempoRetroceso)
        {
            //SoundVFX(DisparoLargo);
            timer = 0;
            refStateManager.ChangeState("Apuntar");
           // SoundVFX(DisparoLargo);
        }
    }
    void Animaciones()
    {
        miAnim.ResetTrigger("Idle");
        miAnim.ResetTrigger("Aiming");
        miAnim.ResetTrigger("Reload");
        miAnim.ResetTrigger("Death");
        miAnim.SetTrigger("Shooting");
    }
    public void ShootInAnim() //evento de animacion
    {
        //SoundVFX(DisparoLargo);
        canShoot = true;
        // SoundVFX(DisparoLargo);
        NuevoSonido(sonidoFranco, this.transform.position, 2f);
    }
    void Shoot()
    {

        ParticleVFX();
        Instantiate(bulletPrefab, fireSpot.transform.position, transform.rotation);
        refEnemigo.currentAmmo--;
        canShoot = false;
        


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
