using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class UIHealthbar : MonoBehaviour
{

    VidaJugador vida;
   // [SerializeField] Image imagenBarraVida = null;
    [SerializeField] Image panelTiempo;
   
    [SerializeField] Text textCantTempo;

    [SerializeField] Text textoTiempoVida;
    float contador = 0;
    float ContadorDeCambio = 1;
    public float tiempoAumentaDisminuye = 0;
    public GameObject panelEntero;

    void Start()
    {
        vida = GetComponent<VidaJugador>();
    }

    void LateUpdate()
    {
        UpdateVidaCircular();

        if (contador <= Time.time)
        {
            GetComponent<UIHealthbar>().PanelChangeColor(Color.white);
            textCantTempo.gameObject.SetActive(false);
        }

        
        textoTiempoVida.text = vida.VidaActual.ToString("f2"); //STRING HUD Tempo/ Vida
        //textoTiempoVida.text = Mathf.RoundToInt(vida.VidaActual).ToString();

    }

    private void UpdateVidaCircular()
    {
        float vidaActual = vida.VidaActual;
        float vidaMaxima = vida.VidaMaxima;
        float porcentaje = (vidaActual / vidaMaxima);
       // imagenBarraVida.fillAmount = porcentaje;
    }

    public void PanelChangeColor(Color CambiarColor)
    {
        contador = Time.time + ContadorDeCambio;

        panelTiempo.color = CambiarColor;
        textoTiempoVida.color = CambiarColor;

        textCantTempo.gameObject.SetActive(true);
    }

    public void TextoCantRecibida(float cantVidaRecibida, bool isDamage) //Recibe la cantidad adecuada. isDamage es un bool que recibe desde VidaJugdor. Si es True, restará vida. Si es false, sumará vida.
    {
        string cantVidaString = Mathf.RoundToInt(cantVidaRecibida).ToString(); //Convierto el número de cantidad en String

        if (isDamage)
        {
            textCantTempo.text = "-" + cantVidaString;
        }
        else
        {
            textCantTempo.text = "+" + cantVidaString;
        }
        //(isDamage) ? textCantTempo.text = "-" + cantVidaString : textCantTempo.text = cantVidaString;  //Operator Ternario. Si isDamage es es True, texto vida  negativo.  Si es false, sumará  vida positivo
    }
    public void AumentarTamaño()
    {
        StartCoroutine(CambiosdeTamanoAumento());
        /*
        tiempoAumentaDisminuye += Time.deltaTime;
        textoTiempoVida.fontSize = 90;
        if( tiempoAumentaDisminuye >=0.2f)
        {
            textoTiempoVida.fontSize = 70;
            print("70");
        }
       
          // textoTiempoVida.fontSize = 70;
          */

    }
    public void DisminuirTamaño()
    {
        StartCoroutine(CambiosdeTamanoAumento());
        /*
        textoTiempoVida.fontSize = 50;
        tiempoAumentaDisminuye += Time.deltaTime;
        if (tiempoAumentaDisminuye >= 2)
        {
           textoTiempoVida.fontSize = 70;
        }
        */
    }
    
   public IEnumerator CambiosdeTamanoAumento()
    {
        textoTiempoVida.fontSize = 90;
        panelEntero.transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);
        yield return new WaitForSeconds(0.5f);
        textoTiempoVida.fontSize = 70;
        panelEntero.transform.localScale = new Vector3(1f, 1f, 1f);

    }

     public IEnumerator CambiosdeTamanoDescenso()
    {
        textoTiempoVida.fontSize = 50;
        panelEntero.transform.localScale = new Vector3(0.99f, 0.9f, 0.99f);
        yield return new WaitForSeconds(0.5f);
        textoTiempoVida.fontSize = 70;
        panelEntero.transform.localScale = new Vector3(1f, 1f, 1f);

    }
}
