using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IddleShield : MonoBehaviour
{
    Animator miAnim;
    NavMeshAgent agent;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        miAnim = GetComponent<Animator>();
        Animaciones();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Animaciones()
    {
        miAnim.SetTrigger("Iddle");
        miAnim.ResetTrigger("Death");
        miAnim.ResetTrigger("Walk");
        miAnim.ResetTrigger("ShieldDown");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        FacePlayer(player.transform.position);
    }
    void FacePlayer(Vector3 lookPos)
    {
        Vector3 lookTarget = lookPos - transform.position;
        lookTarget.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.01f);

    }
}
