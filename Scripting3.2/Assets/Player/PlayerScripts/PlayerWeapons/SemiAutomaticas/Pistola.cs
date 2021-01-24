using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class Pistola : ArmaBaseSemiAutomatica
{
    //Configurar variables del arma semiautomática desde el inspector. Hereda de la clase SemiAutomaticaBase, esta hereda de ArmaBase.

    public GameObject sonidoPistola;

    [SerializeField] bool shotMakeDamage = false;
    [SerializeField] float damageShotTime = 1.5f;

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
                    GetComponentInParent<VidaJugador>().TakeDamage(damageShotTime);
                }
            }
            InstanciarProyectil();

            BulletScreen();

            cmpAnimator.SetTrigger("Shooting");

            //PULIDO 

            //SoundVFX(vfxSoundDisparo);
            NuevoSonido(sonidoPistola, this.transform.position, 2f);
            ParticleVFX();
            CameraShaker.Instance.ShakeOnce(cameraShakeModifier.x, cameraShakeModifier.y, cameraShakeModifier.z, cameraShakeModifier.w);
        }
    }


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

    public override void Recargar()
    {
        //base.Recargar();
    }

    void NuevoSonido(GameObject sonido, Vector3 pos, float duracion)
    {
        Destroy(Instantiate(sonido, pos, Quaternion.identity), 2f);
    }
}
