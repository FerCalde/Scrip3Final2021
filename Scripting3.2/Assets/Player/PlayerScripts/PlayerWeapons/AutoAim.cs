using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAim : MonoBehaviour
{
    public GameObject particleVida;
    float contador;
    // Start is called before the first frame update
    void Start()
    {
        if (particleVida != null)
        {
            particleVida.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (contador > 0)
        {
            contador -= Time.deltaTime;
            particleVida.SetActive(true);
        }
        if (contador <= 0)
        {
            if (particleVida != null)
            {
                particleVida.SetActive(false);
            }
            contador = 0;
        }
    }
    public void activarParticulavida(float tiempoRecibidio)
    {
        contador = tiempoRecibidio;

        print("achedAssetBundle");
    }


}
