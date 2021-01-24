using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Exploding : MonoBehaviour
{
	public NavMeshAgent kami;
	public GameObject Player;
	Animator Anim;
	public GameObject explo;

	// Start is called before the first frame update
	void Start()
    {
		Player = GameObject.FindGameObjectWithTag("Player");
		kami = GetComponent<NavMeshAgent>();
		Anim = GetComponent<Animator>();
		Explote();
		
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	void Die()//PARA QUE MUERA, SE LE LLAMA DESDE UN EVENTO DE ANIMACION
	{
		gameObject.SetActive(false);
	}
	void Explote()//ACTIVA EL OBJETO EN EL QUE ESTA EL SCRIPT DE EXPLOSION
	{
		kami.speed = 0;
		kami.angularSpeed = 0;
		explo.SetActive(true);
	}
}
