using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PatrolShield : MonoBehaviour
{
    ShieldEnemy main;
    NavMeshAgent agent;
    GameObject player;
    Animator miAnim;
    void Start()
    {
        miAnim = GetComponent<Animator>();
        Animaciones();
        agent = GetComponent<NavMeshAgent>();
        main = GetComponent<ShieldEnemy>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent.isStopped = false;
    }
    void Update()
    {
        agent.SetDestination(main.protectPoint);
        transform.rotation = main.EnemiesCover[0].transform.rotation;
        FacePlayer(player.transform.position);
    }
    void Animaciones()
    {
        miAnim.ResetTrigger("Iddle");
        miAnim.ResetTrigger("Death");
        miAnim.SetTrigger("Walk");
        miAnim.ResetTrigger("ShieldDown");
    }
    void FacePlayer(Vector3 lookPos)
    {
        Vector3 lookTarget = lookPos - transform.position;
        lookTarget.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1f);

    }
}
