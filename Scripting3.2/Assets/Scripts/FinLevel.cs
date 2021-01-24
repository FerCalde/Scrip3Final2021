using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinLevel : MonoBehaviour
{
    public Text time;
    public Text kills;
    public Text respesct;
    public Text textofinal;
    public Text scoreTotal;
    public GameObject CANVAS;
    bool final = false;
    float timer = 0f;
    float sumaTotal = 0;
    [SerializeField] GameManager gameManager;
    void Start()
    {
        CANVAS.SetActive(false);
        
    }
   /* void Update()
    {
        if (final == true)
        {
            Debug.Log("final");
            
            timer += 1* Time.deltaTime;
            if (timer > 1f)
            {
                Debug.Log("Cambiar");
                //SceneManager.LoadScene(5);
            }

        }
    }*/

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            final = true;
            float V = col.gameObject.GetComponentInParent<VidaJugador>().VidaActual;
            time.text =  " " + Mathf.RoundToInt(V).ToString();
            kills.text = " " + gameManager.contadorKillsEnemy.ToString();
            float k = gameManager.contadorKillsEnemy;
            float r = gameManager.contadorRespeto;
            
            sumaTotal = V + k * 10  + r*10;

            respesct.text = " " + Mathf.RoundToInt(sumaTotal).ToString();
            
            CANVAS.SetActive(true);
            if ( sumaTotal > 800)
            {
                scoreTotal.text = "S";
                textofinal.text = "Awesome";
            }
            if (sumaTotal < 600)
            {
                scoreTotal.text = "A";
                textofinal.text = "Very Good";
            }
            if (sumaTotal < 300)
            {
                scoreTotal.text = "B";
                textofinal.text = "Good";
            }
            if (sumaTotal <= 200)
            {
                scoreTotal.text = "C";
                textofinal.text = "Not Bad";
            }

            gameManager.FinLevelPauseTime();
        }
    }
}
