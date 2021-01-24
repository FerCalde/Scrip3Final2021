using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraHabilidades : MonoBehaviour
{
    [SerializeField] GameObject jugador = null;
    [SerializeField] GameObject prefabBoton = null;

    void Start()
    {
       /* HabilidadBase[] habilidades = jugador.GetComponentsInChildren<HabilidadBase>();
        foreach (HabilidadBase h in habilidades)
        {
            Sprite icono = h.Icono;

            GameObject nuevoBoton = Instantiate(prefabBoton);
            nuevoBoton.GetComponent<BotonHabilidad>().Habilidad = h;
            nuevoBoton.transform.SetParent(this.transform, false);


        }*/
    }

}
