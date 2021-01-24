using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiradorDeath : Death
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
        miAnim.ResetTrigger("Aiming");
        miAnim.ResetTrigger("Reload");
        miAnim.SetTrigger("Death");
        miAnim.ResetTrigger("Shooting");
    }
}
