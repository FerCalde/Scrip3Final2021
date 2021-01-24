using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InstruccionManager : MonoBehaviour
{
    bool pausedGame = false;
    GameObject goPlayer;

    [SerializeField] Text textoInstruccion;

    // Start is called before the first frame update
    void Start()
    {
        goPlayer = GameObject.FindGameObjectWithTag("Player");
        textoInstruccion.text = " ";
    }

    public void InstruccionPaused(string instruccionRecibida)
    {
        textoInstruccion.text = instruccionRecibida;
        pausedGame = !pausedGame;

        if (pausedGame)
        {
        Time.timeScale = 0;
        goPlayer.GetComponent<WeaponController>().ControllerStopFire(); //Dejar de disparar
        }
        else
        {           
            Time.timeScale = 1;
            textoInstruccion.text = " ";
        }

        //Desactivo/Activo componentes del player para que se cumpla Pause en Player

       
        goPlayer.GetComponent<VidaBase>().enabled = !pausedGame; //Desactivo vida para evitar Bugs de que el tiempo siga corriendo y muera el Player mientras está en Pausa
        goPlayer.GetComponent<Mov>().enabled = !pausedGame;
        goPlayer.GetComponentInChildren<Root>().enabled = !pausedGame;
        goPlayer.GetComponent<WeaponController>().enabled = !pausedGame;
        print(pausedGame);
    }

}
