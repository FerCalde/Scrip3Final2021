using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Detecting : MonoBehaviour
{
	public UnityEngine.AI.NavMeshAgent COP;
	public GameObject Player;
	public float speed = 2.5f;
	public float iSpeed;
	RaycastHit hit;

	public float enemyLimit;
	public float detectarPlayer;
	Vector3 v = Vector3.zero;
	public float distance = 0f;
	public float dot = 0f;
	bool follow;

	public float fov = 35f;
	public float dotFov = 0f;


	public Transform shPoint;
	public bool shoot = false;
	public float shRefresh = 2f;
	float timerRefresh;
	public GameObject Bala;
	public Transform EsquivarIz;
	public Transform EsquivarDerch;
	bool Esquivar;

	Vector3 Inicio;

	StateMachine ST;

	Animator Anim;
    public AudioSource cmpAudioSource;
    [SerializeField] protected AudioClip GritoLoco;

    void Awake()
	{
		iSpeed = speed;
		Inicio = transform.position;
		timerRefresh = shRefresh;
		Anim = GetComponent<Animator>();
		Player = GameObject.FindGameObjectWithTag("Player");
		COP = GetComponent<NavMeshAgent>();
		ST = GetComponent<StateMachine>();
	}
	void Update()
	{
		
		COP.speed = speed;
		//Anim.SetFloat("speed", COP.speed / speed);
	}
	void FixedUpdate()
	{
		//Calculas la distancia y el angulo de vision de los enemigos.
		v = Player.transform.position - (transform.position + new Vector3(0, 1, 0)); ///////////////////// <--------- CALCULA LA DISTANCIA UNA GILIPOLLEZ, PARECIDO O IGUAL A VECTOR3.DISTANCE
		distance = v.magnitude;//Vector3.Distance(Player.transform.position, transform.position + new Vector3(0, 1, 0));

		v.Normalize();
		////////////////////////////////////////////////////////////   ESTAS SON LAS QUE CREAN EL ANGULO ("SON ANGULOS ARTIFICIALES" NO SE COMO EXPLICARLO)
		dotFov = Mathf.Cos(fov * 0.5f * Mathf.Deg2Rad);//<------------------------------ CREA EL ANGULO DE VISION DEL PLAYER fov son los grados del angulo
		dot = Vector3.Dot(transform.forward, v);//<----------------------------------- VALOR EQUIVALENTE AL ANGULO QUE SE CREA ENTRE EL VECTOR v (enemigo-player) Y EL FORWARD DEL ENEMIGO
												////////////////////////////////////////////////////////////  ESTOS DOS VALORES SE COMPARAR EN LA LINEA 87 COMO 2 ANGULOS
												//setea al jugador como objetivo cuando el player esta a la distancia minima
		if (distance <= detectarPlayer)
		{
			follow = true;
			Debug.Log("molotov");
			ST.ChangeState("Molotov");
			transform.LookAt(Player.transform.position + new Vector3(0, -1f, 0));
            SoundVFX(GritoLoco);

		}
		else
		{
			COP.destination = Inicio;
			follow = false;
		}
		
	}

    protected void SoundVFX(AudioClip vfxSoundActual)
    {
        cmpAudioSource.clip = vfxSoundActual; //Cambia el clip del audio
        cmpAudioSource.Play();                //Reproduce el sonido.   
    }

}
