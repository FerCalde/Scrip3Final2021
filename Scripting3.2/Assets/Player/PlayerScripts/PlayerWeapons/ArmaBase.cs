using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class ArmaBase : MonoBehaviour
{
    [Header("Tipo Weapon")]
    [SerializeField] public bool isOneHandWeapon = false; // True= Armas a una mano (pistola, cuchillo....) False= Arma Dos Manos (Metralleta, escopeta, bazoka.....)
    [SerializeField] public bool isGrenade = false;
    [SerializeField] protected bool autoReloading = true;

    [Header("Weapon Settings")]

    [SerializeField] float ammoTotal = 0f;
    public float currentAmmo = 0f;
    [SerializeField] float clipSize = 0f;


    [SerializeField] protected float tiempoEntreDisparo;
    protected float tiempoProximoDisparo;
    [SerializeField] public float tiempoRecarga = 3f;

    [SerializeField] protected Transform firePoint;
    [SerializeField] protected GameObject prefabProyectil;
    [SerializeField] public GameObject weaponModelPrefab;

    protected Animator cmpAnimator;
    //protected AudioSource cmpAudioSource;

    //Variables y útiles para pulido posterior 
    [Header("VFX Weapon")]

    //[SerializeField] protected AudioClip vfxSoundDisparo, vfxSoundRecarga;
    [SerializeField] ParticleSystem vfxParticleMuzzleFlash;

    [SerializeField] protected Vector4 cameraShakeModifier;

    [Header("HUDWeapon")]

    Text currentAmmoText;
    public Text CurrentAmmoText { get => currentAmmoText; set => currentAmmoText = value; }
    //[SerializeField] Image screenBulletsImg = null;
    [SerializeField] Sprite screenWeaponImg = null;
    [SerializeField] Image hudBulletImg = null;
    [SerializeField] public Animator animState = null;
    public Sprite ScreenWeaponImg { get => screenWeaponImg; }
    [SerializeField] RuntimeAnimatorController screenWeaponHUDAnimatorController = null;
    public RuntimeAnimatorController ScreenWeaponHUDAnimatorController { get => screenWeaponHUDAnimatorController; }
    public GameObject sonidoMetralleta;
    public GameObject sonidoRecarga;

    [SerializeField] bool reloadCostTime = true;
    [SerializeField] float costeReload = 5f;
    private void Start()
    {
        currentAmmo = clipSize;
        //COMPONENTE EN OBJETO PADRE
        cmpAnimator = GetComponentInParent<Animator>();
        // cmpAudioSource = GetComponentInParent<AudioSource>();

        animState = hudBulletImg.GetComponent<Animator>();
    }

    public virtual void ApretarGatillo()
    {

    }

    public virtual void SoltarGatillo()
    {

    }

    public virtual void Disparar()
    {
        if (Time.time > tiempoProximoDisparo && currentAmmo > 0)
        {
            tiempoProximoDisparo = Time.time + tiempoEntreDisparo;
            if (GetComponentInParent<VidaBase>().Inmune == false)
            {
                currentAmmo -= 1;
            }
            InstanciarProyectil();

            BulletScreen();

            cmpAnimator.SetTrigger("Shooting");

            //PULIDO 

            // SoundVFX(vfxSoundDisparo);
            NuevoSonido(sonidoMetralleta, firePoint.position, 3f);
            // print("suena");
            ParticleVFX();
            CameraShaker.Instance.ShakeOnce(cameraShakeModifier.x, cameraShakeModifier.y, cameraShakeModifier.z, cameraShakeModifier.w);
        }
    }

    protected virtual void InstanciarProyectil()
    {

        GameObject nuevoProyectil = Instantiate(prefabProyectil, firePoint.position, firePoint.rotation);
    }

    public virtual void Recargar()
    {
        if (ammoTotal >= 0) //BUG CONTROL No recarga a menos que tenga balas en los bolsillos
        {
            if (currentAmmo < clipSize) //BUG CONTROL No recarga a menos que haya gastado minimo una bala
            {

                cmpAnimator.gameObject.GetComponent<WeaponController>().StartReload(tiempoRecarga);
                NuevoSonido(sonidoRecarga, this.transform.position, 1f);

                // SoundVFX(vfxSoundRecarga); //Proximo pulido para deteccion sonido de las armas

            }
        }

    }
    public void FinishReload()
    {
        if (!reloadCostTime)
        {
            if (ammoTotal >= clipSize)
            {
                ammoTotal -= clipSize; //Resta cantAmmoMaximaActual que tiene
                currentAmmo = clipSize;

            }
            else
            {
                currentAmmo = ammoTotal;
                ammoTotal = 0;
            }

        }


        RecargarCuestaTiempo();

        BulletScreen();
    }

    public void BulletScreen()
    {
        //screenBulletsImg.fillAmount = (currentAmmo / clipSize) / 2; //Circulo alrededor player

        hudBulletImg.fillAmount = (currentAmmo / clipSize) * 0.75f;
        //PlayAnimationBulletScreen();

        if (!reloadCostTime)
        {
            CurrentAmmoText.text = currentAmmo.ToString() + "    " + ammoTotal.ToString(); //HUD Canvas-> numerico
        }
        if (reloadCostTime)
        {
            currentAmmoText.text = currentAmmo.ToString() + "    " + clipSize.ToString();
        }
    }

    protected void ParticleVFX()
    {
        vfxParticleMuzzleFlash.Play();
    }
    void NuevoSonido(GameObject sonido, Vector3 pos, float duracion)
    {
        Destroy(Instantiate(sonido, pos, Quaternion.identity), 3f);
    }



    protected void RecargarCuestaTiempo()
    {
        if (reloadCostTime)
        {
            if (GetComponentInParent<VidaBase>().VidaActual >= (costeReload + 1)) //Condicion de que tenga Vida Sobrante tras recargar
            {
                //print("TENGO VIDA DE SOBRA!");
                currentAmmo = clipSize;
                GetComponentInParent<VidaBase>().TakeDamage(costeReload);

                // print(currentAmmo);
                //Condiciones para retirar/activar el autoreload-> Si la Vida actual es menor al Doble que cuesta realizar la recarga
                if (GetComponentInParent<VidaBase>().VidaActual <= (costeReload * 2))
                {
                    autoReloading = false;
                }
                if (GetComponentInParent<VidaBase>().VidaActual >= (costeReload * 2))
                {
                    autoReloading = true;
                }
                // print(autoReloading);
            }
        }
    }

    void PlayAnimationBulletScreen()
    {
        print(hudBulletImg.GetComponent<AnimationState>().name + "            "  );
        hudBulletImg.GetComponent<AnimationState>().time = currentAmmo / clipSize;
        animState.GetComponent<AnimationState>().time = currentAmmo / clipSize;


    }
}
