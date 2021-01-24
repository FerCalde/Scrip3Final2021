using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    bool once;
    [SerializeField] float dañoExplo = 20f;
    //EXPLOSION DE ENEMIGO SUICIDA RESTA VIDA
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.layer == 8)
        {
            col.gameObject.GetComponentInParent<VidaJugador>().TakeDamage(dañoExplo);
            Debug.Log("GiveDamage");
        }
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<VidaEnemyBase>().TakeDamage(dañoExplo * 100);
            Debug.Log("GiveDamage");
        }
    }
}
