using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiradorRecargar : MonoBehaviour
{
   
    private UnityEngine.AI.NavMeshAgent agente;
    StateMachine refStateManager;
    EnemyTirador refEnemigo;
    Animator miAnim;
    public SniperGunController refWeapon;




    // Start is called before the first frame update
    void Start()
    {
        refEnemigo = GetComponent<EnemyTirador>();
        refStateManager = GetComponent<StateMachine>();
        agente = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        
        miAnim = GetComponent<Animator>();

        agente.isStopped = true;
        Animaciones();
    }
    void Animaciones()
    {
        miAnim.ResetTrigger("Idle");
        miAnim.ResetTrigger("Aiming");
        miAnim.SetTrigger("Reload");
        miAnim.ResetTrigger("Death");
        miAnim.ResetTrigger("Shooting");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Recargar()
    {
        refEnemigo.currentAmmo = refEnemigo.caseSize;
    }
    public void TerminarRecarga()
    {
        
        refStateManager.ChangeState("Apuntar");
    }
}
