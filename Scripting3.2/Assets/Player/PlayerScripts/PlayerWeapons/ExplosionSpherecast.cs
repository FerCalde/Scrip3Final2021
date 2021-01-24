using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpherecast : MonoBehaviour
{
    [SerializeField] protected float radiusSpherecast;
    [SerializeField] protected Vector3 centerSpherecast;


    public void SphereExplosion(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radiusSpherecast);
        foreach (var hitCollider in hitColliders)
        {
            if (GetComponent<VidaEnemyBase>() != null)
            {
                print(hitCollider.name + " nombreTocado " + " Puedo aplicar efecto si eres un enemigo");
            }
        }
    }


}


