using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGranadaSlow : BulletBase
{
    [SerializeField] float radiusSpherecast = 10f;
    [SerializeField] float tiempoSlow = 5f;
    [SerializeField] float cantRalenti = 1f;
    //AudioSource cmpAudioSource;
    //public AudioClip cmpAudioClip;

    bool isChocada = false;
    float tiempoDestroyGrenade = 5f;
    float timeActual;

    void Update()
    {
        if (isChocada)
        {
            if (timeActual <= Time.time)
            {
               
                Destroy(this.gameObject);
            }
        }
    }

    protected override void AplicarEfecto(Collider coll)
    {

        // GetComponent<ExplosionSpherecast>().SphereExplosion(this.transform.position, radiusSpherecast); //LLama al componente 
        SphereExplosion();
        speedBala = 0;
        isChocada = true;
        timeActual = Time.time + tiempoDestroyGrenade;
       // SoundVFX(chocaEnemigo);
    }


    public override void BulletColisiona()
    {
        //Destroy(this.gameObject, tiempoSlow);
    }
   
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(this.transform.position, radiusSpherecast);
    }

    void SphereExplosion()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, radiusSpherecast);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                hitCollider.GetComponent<AplicarEfectosTemporales>().IniciarEfecto(tiempoSlow, cantRalenti);
                print(hitCollider.name + " nombreTocado " + " Puedo aplicar efecto si eres un enemigo");
            }
        }
    }

}

    /*
    IEnumerator FinExplosion()
    {
        print("FESTOY GRENADE");
        yield return new WaitForSeconds(tiempoSlow);
        print("FINAL GRANADA");
        Destroy(this.gameObject);
    }
    /*protected void SoundVFX()
    {
        cmpAudioSource.clip = cmpAudioClip; //Cambia el clip del audio
        cmpAudioSource.Play();                //Reproduce el sonido.   
    }*/
