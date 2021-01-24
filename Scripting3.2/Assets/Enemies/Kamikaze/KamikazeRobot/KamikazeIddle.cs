using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KamikazeIddle : MonoBehaviour
{
    NavMeshAgent kami;
    Animator miAnim;
    void Start()
    {
        miAnim = GetComponent<Animator>();
        Animaciones();
        kami = GetComponent<NavMeshAgent>();
        kami.isStopped = true;
    }
    void Animaciones()
    {
        miAnim.SetTrigger("Idle");
        miAnim.ResetTrigger("Chase");
        miAnim.ResetTrigger("Explote");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
