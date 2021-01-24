using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstruccionInvulnerable : InstruccionStopPlayer
{
    [SerializeField] bool setInvulnerable = false; 

    protected override void Unpause()
    {
        cmpInstruccionManager.InstruccionPaused("");

        GameObject.FindGameObjectWithTag("Player").GetComponent<VidaJugador>().SetInvulnerable(setInvulnerable); //Setear si quiere invulnerable o no
        Destroy(this.gameObject);
    }


}
