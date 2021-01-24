using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopDeath : Death
{
    Animator miAnim;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        miAnim = GetComponent<Animator>();
        Animaciones();
    }
    void Animaciones()
    {
        miAnim.ResetTrigger("Idle");
        miAnim.ResetTrigger("Chase");

        miAnim.SetTrigger("Death");
        miAnim.ResetTrigger("Shoot");
        miAnim.ResetTrigger("Aim2Down");
        miAnim.ResetTrigger("Stoping");
        miAnim.ResetTrigger("Aiming");

    }
    // Update is called once per frame
    
}
