using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chakram : ArmaBaseSemiAutomatica
{
    [SerializeField] GameObject goBoomerang;
    [SerializeField] Transform weaponAttach;

    [SerializeField] float damageBoomerang = 15f;
    [SerializeField] float distanceBoomerang = 5f;
    [SerializeField] float speedBoomerang = 10f;

    [SerializeField] bool shotMakeDamage = false;
    [SerializeField] float damageShotTime = 1f;
    bool ableToShoot = true;
    bool front = true;
    Vector3 locationInFrontOfPlayer;

    GameObject goPlayer;
    public GameObject sfxChakram;
   // Start is called before the first frame update
   void Start()
    {
        ableToShoot = true;
        goPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (!ableToShoot)
        {
            if (front)
            {
                if (Vector3.Distance(goBoomerang.transform.position, locationInFrontOfPlayer) <= 0.1f)
                {
                    front = false;
                }
               
                goBoomerang.transform.position = Vector3.MoveTowards(goBoomerang.transform.position, locationInFrontOfPlayer, Time.deltaTime * speedBoomerang);
            }
            if (!front)
            {
                if (Vector3.Distance(goBoomerang.transform.position, firePoint.position) <= 0.1f)
                {
                    RecibirBoomerang();
                }
               
                goBoomerang.transform.position = Vector3.MoveTowards(goBoomerang.transform.position, firePoint.position, Time.deltaTime * speedBoomerang);
            }
            
        }
        */
    }

    public override void Disparar()
    {
        if (ableToShoot)
        {
            //NuevoSonido(sfxChakram, this.transform.position, 2f);
            goPlayer.GetComponent<Animator>().SetTrigger("BoomerLanza");
            goPlayer.GetComponent<Animator>().ResetTrigger("Retorno");
            goPlayer.GetComponent<WeaponController>().BusyState();
            ableToShoot = false;
            //locationInFrontOfPlayer = (firePoint.position) + firePoint.forward * distanceBoomerang;
        }

    }

    public void RecibirBoomerang()
    {
       

        goBoomerang.transform.SetParent(this.transform, false);

        goBoomerang.GetComponent<SphereCollider>().enabled = false; //Se desactiva collider del boomerang

        currentAmmo = 1;
        goBoomerang.transform.position = weaponAttach.position; //Seteamos posicion del boomerang en las manos.
        
        BulletScreen();

        GetComponentInParent<Animator>().ResetTrigger("BoomerLanza");
        GetComponentInParent<Animator>().ResetTrigger("Retorno");
       
        goPlayer.GetComponent<WeaponController>().BusyState();

        //Reset Variables
        ableToShoot = true;

    }


    public void EventLanzarBoomer()
    {

            if (GetComponentInParent<VidaBase>().Inmune==false)
            {
                if (shotMakeDamage)
                {
                    GetComponentInParent<VidaJugador>().TakeDamage(damageShotTime);
                }
            }
            goBoomerang.transform.position = firePoint.transform.position;
            goBoomerang.transform.rotation = firePoint.transform.rotation;

            goBoomerang.transform.SetParent(null, false);
            goBoomerang.GetComponent<SphereCollider>().enabled = true;

            Vector3 posLanzamiento = (firePoint.position) + firePoint.forward * distanceBoomerang;
            goBoomerang.GetComponent<BulletBoomerang>().LanzarBoomerang(posLanzamiento, speedBoomerang, damageBoomerang);
            
            
            currentAmmo = 0;
            BulletScreen();
    }


    public void VueltaBoomerAnim()
    {
        GetComponentInParent<Animator>().SetTrigger("Retorno");
    }
    void NuevoSonido(GameObject sonido, Vector3 pos, float duracion)
    {
        Destroy(Instantiate(sonido, pos, Quaternion.identity), 2f);
    }
}
