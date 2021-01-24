using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstruccionStopPlayer : MonoBehaviour
{
    protected InstruccionManager cmpInstruccionManager;

    bool checkPaused = false;
    [SerializeField] KeyCode teclaContinue;

    [SerializeField] string textoInstruccionContinue;
    // Start is called before the first frame update
    protected void Start()
    {
        cmpInstruccionManager = GameObject.FindObjectOfType<InstruccionManager>().GetComponent<InstruccionManager>();
    }

    // Update is called once per frame
    protected void LateUpdate()
    {
        CheckInput();
    }

    protected void CheckInput()
    {
        if (checkPaused)
        {
            if (Input.GetKeyDown(teclaContinue))
            {
                Unpause();
            }
        }
    }

    protected virtual void Unpause()
    {
        cmpInstruccionManager.InstruccionPaused(" ");  //Revierte el pause y los componentes del jugador
        Destroy(this.gameObject);
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<VidaJugador>() != null)
        {
            cmpInstruccionManager.InstruccionPaused(textoInstruccionContinue); //Para el juego y desactiva los componentes necesarios del jugador
            checkPaused = true;

           // Destroy(this.GetComponent<Collider>()); //Rompo este collider para que no de errores de volver a detectarnos
        }
    }
}
