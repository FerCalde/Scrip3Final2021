using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Detectedplayer : MonoBehaviour
{
	public NavMeshAgent kami;
	public GameObject Player;
	bool detected = false;
	Animator Anim;
	StateMachine ST;
	// Start is called before the first frame update
	void Start()
    {
		Player = GameObject.FindGameObjectWithTag("Player");
		kami = GetComponent<NavMeshAgent>();
		Anim = GetComponent<Animator>();
		ST = GetComponent<StateMachine>();
	}

    // Update is called once per frame
    void Update()
    {
		if (detected == true)//PLAYER DETECTADO, ANDA HACIA AL PLAYER A LA DISTANCIA ELEGIDA EXPLOTA
		{
			Anim.SetBool("Siguiendo", true);
			kami.destination = Player.transform.position;
			float Dist = Vector3.Distance(Player.transform.position, transform.position);
			if (Dist <= 2)
			{
				ST.ChangeState("Explosion");
				Anim.SetBool("Explota", true);
			}
		}
		else//PLAYER NO DETECTADO, SI ENTRA PASA A DETECTED TRUE Y A PERSEGUIRLO
		{
			float Dist = Vector3.Distance(Player.transform.position, transform.position);
			if (Dist <= 14)
			{
				detected = true;
			}
		}
	}
}
