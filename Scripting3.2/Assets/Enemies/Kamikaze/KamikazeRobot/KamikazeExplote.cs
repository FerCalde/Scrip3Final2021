using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KamikazeExplote : Death
{
    [SerializeField] float exploteAtTime;
    [SerializeField] float duracionExplosion;
    public GameObject explosion;
    NavMeshAgent kamiNav;
    Animator miAnim;
    Collider exploCol;
    public Light luzExplo;
    bool luzIntermitente;
   
    protected override void Start()
    {
        base.Start();

        exploCol = explosion.GetComponent<Collider>();
        miAnim = GetComponent<Animator>();
        Animaciones();

        kamiNav = GetComponent<NavMeshAgent>();
        kamiNav.isStopped = true;
    }
    void Animaciones()
    {
        miAnim.ResetTrigger("Idle");
        miAnim.ResetTrigger("Chase");
        miAnim.SetTrigger("Explote");
    }
    protected override void Update()
    {
        base.Update();
        if (timer > exploteAtTime)
        {
            luzExplo.intensity = 0;
            if (timer > (duracionExplosion + exploteAtTime))
            {
                rend.enabled = false;
               // Debug.Log("desactivarKamikace");
                explosion.SetActive(false);
            }
            else
            {
                explosion.SetActive(true);
                if (timer > (exploteAtTime + 0.1f))
                {
                    exploCol.enabled = false;
                }
                else
                {
                    exploCol.enabled = true;
                }
                
            }
        }
        else
        {
            if (luzIntermitente == false)
            {
                luzExplo.intensity = 20 * timer;
                luzIntermitente = true;

            }
            else
            {
                luzExplo.intensity = 0;
                luzIntermitente = false;
            }

        }

        
    }
    void LateUpdate()
    {
        
    }
}
