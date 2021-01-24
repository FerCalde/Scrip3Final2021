using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathShield : Death
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
        miAnim.ResetTrigger("Iddle");
        miAnim.SetTrigger("Death");
        miAnim.ResetTrigger("Walk");
        miAnim.ResetTrigger("ShieldDown");
    }
}
