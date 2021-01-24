using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EZCameraShake;

public class VidaJugador : VidaBase {
   
    [SerializeField] float hitIntensity;
    [SerializeField] Light hitLight;
    [SerializeField] ParticleSystem vfxParticlesCuracion;
    [SerializeField] ParticleSystem vfxSangre;

    [SerializeField] Vector4 onHitShake;

    [SerializeField] SkinnedMeshRenderer cmpSkinnedMeshRenderer;
    float tiempoColor = 1f;
    [SerializeField] Material colorDamage;

    [SerializeField] Material regularColor;
    [SerializeField] Color colorDamageBrra;
    [SerializeField] Color colorVidaBrra;
    [SerializeField] Light rewindLight;
    [SerializeField] float rewindIntensity;
    [SerializeField] ParticleSystem particleRewind;
    [SerializeField] GameObject sfxMuerte;
    [SerializeField] GameObject SfxcurarVida;

    public GameObject sonidoPocaVida;

    bool sonidoPocaVidaActivaed = false;
    protected override void Start()
    {
        base.Start();
       // cmpAudioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (!Inmune)
        {
            if (VidaActual > 0)
            {
                vidaActual -= 1 * Time.deltaTime;
            }
            if (VidaActual <= 0)
            {
                vidaActual = 0;
                cmpAnimator.SetTrigger("Muerte");
                StartCoroutine(Morir());
            }
            if(Hited == true)
            {

                CameraShaker.Instance.ShakeOnce(onHitShake.x, onHitShake.y, onHitShake.z, onHitShake.w);
                StartCoroutine(ChangeColor());
                GetComponent<UIHealthbar>().PanelChangeColor(colorDamageBrra);
                GetComponent<UIHealthbar>().TextoCantRecibida(cantDamageRecibida, true);
                
                hitLight.intensity = hitIntensity;
                vfxSangre.Play();
                Hited = false;
                GetComponent<UIHealthbar>().DisminuirTamaño();
            }
            if (hitLight.intensity > 0)
            {
                hitLight.intensity -= hitIntensity * 2 * Time.fixedDeltaTime;
            }
            if (vidaActual <= 20)
            {
                if(!sonidoPocaVidaActivaed)
                {
                    NuevoSonido(sonidoPocaVida, this.transform.position, 2f);
                    print("suenaemergencia");
                    sonidoPocaVidaActivaed = true;
                    GetComponent<UIHealthbar>().PanelChangeColor(colorDamageBrra);
                    GetComponent<UIHealthbar>().TextoCantRecibida(0f, true);

                }
               
            }
        }

        if(RewindManagment.isRewinding == true)
        {
            rewindLight.intensity = hitIntensity;
            particleRewind.Play();
            //print("cacaParticula");
        }

        else
        {
            rewindIntensity = 0;
            rewindLight.intensity = rewindIntensity;
            particleRewind.Stop();
          
        }
    }

    public void CurarVida(float curacion)
    {
        if (vidaActual > 0)
        {
            vidaActual += curacion;
            if (vidaActual > vidaMaxima) { vidaActual = vidaMaxima; }
            NuevoSonido(SfxcurarVida, this.transform.position, 1f);
            vfxParticlesCuracion.Play(); //Particula de curacion
            GetComponent<UIHealthbar>().PanelChangeColor(colorVidaBrra); //Llama al método que cambia el color del panel VidaTempo-> Feedback
            GetComponent<UIHealthbar>().TextoCantRecibida(curacion, false); //Llama al metodo que indica la cantidad de vida que se suma-> Feedback
            GetComponent<UIHealthbar>().AumentarTamaño();
            //GetComponent<UIHealthbar>().tiempoNormal();
            if(sonidoPocaVidaActivaed)
            {
                sonidoPocaVidaActivaed = false;
            }
        }
    }

    public override IEnumerator Morir()
    {
        NuevoSonido(sfxMuerte, this.transform.position, 1f);
        //print("EmpiezaDie"); Desactivo componentes para que no pueda disparar, moverse, rotar...
        GetComponent<WeaponController>().ControllerStopFire(); //Dejar de disparar
        GetComponent<Mov>().enabled = false;
        GetComponent<WeaponController>().enabled = false; 
        GetComponentInChildren<Root>().enabled = false;


       
        
        yield return new WaitForSeconds(3);

        //print("finishDie");
    
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator ChangeColor()
    {
        //regularColor = cmpSkinnedMeshRenderer.material;
        cmpSkinnedMeshRenderer.material = colorDamage;
        //print(regularColor);
        yield return new WaitForSeconds(1);

        cmpSkinnedMeshRenderer.material = regularColor;
        //print("colorRegularPuta");

    }


    public void SetInvulnerable(bool isActiveInvulnerable)
    {
        inmune = isActiveInvulnerable;
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

    public void HabilityDamage(float damage)
    {
        vidaActual -= damage;
        cantDamageRecibida = damage;
        if (vidaActual <= 0)
        {
            StartCoroutine(Morir());
        }
        Hited = true;
    }

}
