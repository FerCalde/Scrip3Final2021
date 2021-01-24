using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePowerUp : MonoBehaviour
{
    Rigidbody rB;
    Collider col;
    float fuerzaX;
    float fuerzaZ;
    float timer;

    [SerializeField] float timeCantUse;
    [SerializeField] float timeToUse;
    [SerializeField] float maxFuerza;
    public float sumarVida;
    GameObject player;
    void Awake()
    {
        rB = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        fuerzaX = Random.Range(-maxFuerza, maxFuerza);
        fuerzaZ = Random.Range(-maxFuerza, maxFuerza);
        rB.AddForce(new Vector3(fuerzaX, 0, fuerzaZ));
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timeCantUse <= timer)
        {
            float distToPlayer;
            distToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if(distToPlayer < 4)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 6f * Time.deltaTime);
            }
        }
        if ((timeCantUse + timeToUse) <= timer)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponentInParent<VidaJugador>().CurarVida(sumarVida);
            Destroy(gameObject);
        }
        rB.velocity = Vector3.zero;
        rB.useGravity = false;
    }
}
