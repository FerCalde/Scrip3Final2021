using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Shuriken : ArmaBaseSemiAutomatica
{
    //Configurar variables del arma semiautomática desde el inspector. Hereda de la clase SemiAutomaticaBase, esta hereda de ArmaBase.

    public GameObject sonidoShuriken;


    [SerializeField] bool shotMakeDamage = false;
    [SerializeField] float damageShot = 1.5f;

    [SerializeField] float cantidadBulletsRafaga = 3f;
    [SerializeField] float fireRateRafaga=1f;
    float timeRafagaActual;

    void Update()
    {
        if (Time.time > tiempoProximoDisparo)
        {
            currentAmmo = 1;
            BulletScreen();
        }
        else
        {
            currentAmmo = 0;
        }
    }

    public override void Disparar()
    {
        if (Time.time > tiempoProximoDisparo)
        {
            tiempoProximoDisparo = Time.time + tiempoEntreDisparo;

            if (GetComponentInParent<VidaBase>().Inmune == false)
            {
                currentAmmo -= 1;

                if (shotMakeDamage)
                {
                    GetComponentInParent<VidaJugador>().TakeDamage(damageShot);
                }
            }

            
            InstanciarProyectil();

            BulletScreen();

            cmpAnimator.SetTrigger("Shooting");

            //PULIDO 

            //SoundVFX(vfxSoundDisparo);
            NuevoSonido(sonidoShuriken, this.transform.position, 2f);
            print("suena");
            ParticleVFX();
            CameraShaker.Instance.ShakeOnce(cameraShakeModifier.x, cameraShakeModifier.y, cameraShakeModifier.z, cameraShakeModifier.w);
        }
    }

    public override void Recargar()
    {
        //base.Recargar();
    }
    void NuevoSonido(GameObject sonido, Vector3 pos, float duracion)
    {
        Destroy(Instantiate(sonido, pos, Quaternion.identity), 2f);
    }


    protected override void InstanciarProyectil()
    {
        StartCoroutine(RafagaShurikensInstantiate());
        
        
        /*for (int i = 0; i < cantidadBulletsRafaga; i++)
        {

               
            print(i);

            /*    timeRafagaActual -= Time.deltaTime;
            if (timeRafagaActual<=0)
            {
                GameObject nuevoProyectil = Instantiate(prefabProyectil, firePoint.position, firePoint.rotation);

                tiempoProximoDisparo = tiempoEntreDisparo;

                timeRafagaActual = fireRateRafaga;
                i++;
            }
            else
            { 
            }

        }*/
    }
  
    IEnumerator RafagaShurikensInstantiate() 
    {
        for (int i = 0; i < cantidadBulletsRafaga; i++)
        {
            GameObject nuevoProyectil = Instantiate(prefabProyectil, firePoint.position, firePoint.rotation);


            yield return new WaitForSeconds(fireRateRafaga);
            print(i);
        }
        //new WaitForSeconds(fireRateRafaga);
    }

  

}
