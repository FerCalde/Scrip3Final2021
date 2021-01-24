using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonHabilidad : MonoBehaviour
{
    [SerializeField] HabilidadBase habilidad;
    [SerializeField] Image imagenCooldown = null;
    Image imagenIcono = null;

   // [SerializeField] Image panelHabilidadFilter;
    public HabilidadBase Habilidad { get => habilidad; set => habilidad = value; }

    //float porcentajeRelleno = 1f;
    float porcentajeRelleno;

    private void Start()
    {
        //imagenIcono.sprite = Habilidad.Icono;
        imagenCooldown.fillAmount = 0;
       // panelHabilidadFilter.enabled=false;
    }

    private void Update()
    {
        // CODIGO EN PROCESO PARA SETEAR GUAY EL FILL AMOUNT DE LAHABILIDAD
        if (habilidad != null)
        {
            if (habilidad.isActiveHability)
            {
                porcentajeRelleno = habilidad.TiempoDuracionActual / habilidad.TiempoDuracionActivadoMaximo;
                imagenCooldown.fillAmount = porcentajeRelleno;
           //     panelHabilidadFilter.enabled=true;
            }
            if (!habilidad.isActiveHability)
            {
                porcentajeRelleno = habilidad.TiempoReutilizacionActual / habilidad.TiempoReutilizacionMaximo;
                imagenCooldown.fillAmount = porcentajeRelleno;
              //  panelHabilidadFilter.enabled=(false);
            }
        }

    }

    /*public void BotonPulsado()
    {
       // habilidad.Activar();
    }*/

}
