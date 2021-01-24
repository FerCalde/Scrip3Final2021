using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeSlowerAreaExplosion : MonoBehaviour
{
    [SerializeField] float tiempoAreaExplosionActiva = 5f;

    [SerializeField] float cantRalenti = 1f;
    [SerializeField] float radiusSpherecast;

    // Start is called before the first frame update
    void Start()
    {
        radiusSpherecast = (this.transform.localScale.x * GetComponent<SphereCollider>().radius); //ajuste esfera al radio del trigger para un mejor debug
        Destroy(this.gameObject, tiempoAreaExplosionActiva);
        //radiusSpherecast = GetComponent<SphereCollider>().radius; ANTIGUA! Linea de referencia NO BORRAR
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag != "BalasPlayer")
        {
            if (other.CompareTag("Enemy"))
            {
                if (other.GetComponent<AplicarEfectosTemporales>() != null)
                {
                    other.GetComponent<AplicarEfectosTemporales>().GrenadeSlowerEffect(cantRalenti);
                }
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player" && other.tag != "BalasPlayer")
        {
            if (other.CompareTag("Enemy"))
            {
                if (other.GetComponent<AplicarEfectosTemporales>() != null)
                {
                    other.GetComponent<AplicarEfectosTemporales>().GrenadeSlowerEffect(cantRalenti);
                }
            }
        }



        /* if (other.tag != "Player" && other.tag != "BalasPlayer")
         {
             if (other.CompareTag("Enemy"))
             {
                 SphereExplosion();
             }
         }*/
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player" && other.tag != "BalasPlayer")
        {
            if (other.CompareTag("Enemy"))
            {
                //SphereExplosion();
                print(other.name);

                if (other.GetComponent<AplicarEfectosTemporales>() != null)
                {
                    other.GetComponent<AplicarEfectosTemporales>().EfectoTriggerExit();
                }
            }
        }
    }

    void SphereExplosion()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, radiusSpherecast);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                if (hitCollider.GetComponent<AplicarEfectosTemporales>() != null)
                {
                    hitCollider.GetComponent<AplicarEfectosTemporales>().GrenadeSlowerEffect(cantRalenti);
                    print(hitCollider.name + " nombreTocado " + " Puedo aplicar efecto si eres un enemigo");
                }
            }
        }
    }

    /*void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(this.transform.position, radiusSpherecast);
    }*/

}
