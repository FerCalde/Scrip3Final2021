using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHitReaction : MonoBehaviour
{
    NavMeshAgent agent;
    VidaEnemyBase vida;
    float speedMax;
    float speedHitted;
    Animator anim;

    void Start()
    {
        vida = GetComponent<VidaEnemyBase>();
        agent = GetComponent<NavMeshAgent>();
        speedMax = agent.speed;
        speedHitted = 0;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
       
        if (vida.hitted)
        {
            agent.speed = speedHitted;
            vida.hitted = false;
        }
        else
        {
            if (agent.speed <= speedMax)
            {
                agent.speed += Time.deltaTime * speedMax;
            }
            else
            {
                agent.speed = speedMax;
            }
        }
    }
}
