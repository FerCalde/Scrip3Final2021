using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadPausarTiempo : HabilidadBase
{
    [SerializeField] float radiusSpherecast = 20f;
    [SerializeField] float tiempoSlow = 5f;
    [SerializeField] float ralentiFrenar = 0f;
    [SerializeField] LayerMask layerMask;
    VidaJugador playerVida;

    [SerializeField] float cantDamageAlUsarHabilidad;

    void Start()
    {
        playerVida = GetComponentInParent<VidaJugador>();
    }

    protected override void AplicarEfecto()
    {
        //CREAR EVENTO PARA MANDAR EFECTO CONGELADO/PAUSA A LOS ENEMIGOS
        SphereExplosion();
        
        playerVida.TakeDamage(cantDamageAlUsarHabilidad);
    }

    void SphereExplosion()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, radiusSpherecast);

        foreach (var hitCollider in hitColliders)
        {
            print(hitCollider.name);
            if (hitCollider.CompareTag("Enemy"))
            {
                hitCollider.GetComponent<AplicarEfectosTemporales>().IniciarEfecto(tiempoSlow, ralentiFrenar);
                print(hitCollider.name + " nombreTocado " + " Puedo aplicar efecto si eres un enemigo");
            }
        }
    }

    /*void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(this.transform.position, radiusSpherecast);
    }*/
}
