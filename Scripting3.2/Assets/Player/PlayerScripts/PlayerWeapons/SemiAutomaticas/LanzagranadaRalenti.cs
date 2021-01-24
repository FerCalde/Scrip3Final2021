using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzagranadaRalenti : ArmaBaseSemiAutomatica
{
    //Configurar variables desde el Inspector. 

    [SerializeField] float forceHorizontalImpulse = 30f;
    [SerializeField] float forceVertical = 10f;
    public AudioClip PinOut;

    public override void Disparar()
    {
        //base.Disparar();
        if (Time.time > tiempoProximoDisparo && currentAmmo > 0)
        {
            cmpAnimator.SetTrigger("Grenade");
           // SoundVFX(PinOut);
            GetComponentInParent<WeaponController>().isBusy = true;
        }
    }

    public void EventLanzarGrenade()
    {
        tiempoProximoDisparo = Time.time + tiempoEntreDisparo;
        if (GetComponentInParent<VidaBase>().Inmune == false)
        {
            currentAmmo -= 1;
        }

        InstanciarProyectil();

        if (autoReloading)
        {
            if (currentAmmo <= 0)
            {
                FinishReload();
            }
        }

        BulletScreen();

    }

    protected override void InstanciarProyectil()
    {
        GameObject nuevoProyectil = Instantiate(prefabProyectil, firePoint.position, firePoint.rotation);

        nuevoProyectil.GetComponent<Rigidbody>().AddForce((nuevoProyectil.transform.forward * forceHorizontalImpulse) + (nuevoProyectil.transform.up * forceVertical), ForceMode.Impulse);
    }
}
