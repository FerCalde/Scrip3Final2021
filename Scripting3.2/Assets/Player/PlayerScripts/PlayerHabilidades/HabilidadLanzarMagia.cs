using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadLanzarMagia : HabilidadBase
{
    [SerializeField] Rigidbody prefabMagia;
    [SerializeField] float fuerzaDisparo;
    [SerializeField] Transform puntoDisparo;
    
    protected override void AplicarEfecto()
    {
        Rigidbody nuevaMagia = Instantiate(prefabMagia, puntoDisparo.position, puntoDisparo.rotation);        
        nuevaMagia.AddForce(puntoDisparo.forward * fuerzaDisparo, ForceMode.Impulse);            
    }

}
