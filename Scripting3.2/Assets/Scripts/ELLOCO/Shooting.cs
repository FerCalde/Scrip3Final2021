using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Shooting : MonoBehaviour
{
	public NavMeshAgent COP;
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


	Animator Anim;
    public AudioSource cmpAudioSource;
    [SerializeField] protected AudioClip disparoLoco;
	void Awake()
	{
		iSpeed = speed;
		Inicio = transform.position;
		timerRefresh = shRefresh;
		Anim = GetComponent<Animator>();
		Player = GameObject.FindGameObjectWithTag("Player");
		COP = GetComponent<NavMeshAgent>();
	}
	void Update()
	{
		Shoot();
		if (shoot == false)
		{
			if (follow == true)
			{

				COP.destination = Player.transform.position;
			}

		}
		COP.speed = speed;
		Anim.SetFloat("speed", COP.speed / speed);
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

			transform.LookAt(Player.transform.position + new Vector3(0, -1f, 0));

		}
		else
		{
			COP.destination = Inicio;
			follow = false;
		}
		//CUANDO EL PLAYER ESTA  EN SU ANGULO DE VISION Y A LA DISTANCIA CORRECTA EL ENEMIGO APUNTARA HACIA AL PLAYER
		if ((distance <= enemyLimit) && (dot >= dotFov))
		{
			if (follow == true)
			{
				LockPlayer();
			}

		}
		else
		{
			shoot = false;
			timerRefresh = 0.5f;
		}
	}
	void Shoot()
	{
		//DISPARAR AL PLAYER NO TIENE MUCHO MAS
		if (shoot == true)
		{
            Anim.SetTrigger("Shooting");
            SoundVFX(disparoLoco);
			timerRefresh += Time.deltaTime;
			if (timerRefresh >= shRefresh)
			{
				timerRefresh = 0;
				GameObject.Instantiate(Bala, shPoint.position, transform.rotation);
			}
		}

	}
	void LockPlayer()//CUANDO SE TIENE LOCKEADO AL PLAYER SE LANZA UN RAYCAST QUE ACTIVARA EL DISPARAR Y QUE SE MUEVA AL REDEDOR DEL PLAYER(el moverse en circulos es muy chapuzero setea la posicion objetivo como un gameobject vacio que tiene a los lados)
	{
		if (Physics.Raycast(transform.position + new Vector3(0, 1.4f, 0), transform.forward, out hit, 9))
		{
			Debug.DrawRay(transform.position + new Vector3(0, 1, 0), transform.forward * hit.distance, Color.red);
			if (hit.collider.tag == "Player")
			{

				int R = Random.Range(0, 1);
				if (R == 0)
				{
					COP.destination = EsquivarIz.position;

				}
				else
				{

					COP.destination = EsquivarDerch.position;
				}

				shoot = true;
			}
			else
			{
				shoot = false;
				timerRefresh = 0.5f;
			}
		}
	}
    protected void SoundVFX(AudioClip vfxSoundActual)
    {
        cmpAudioSource.clip = vfxSoundActual; //Cambia el clip del audio
        cmpAudioSource.Play();                //Reproduce el sonido.   
    }
}
