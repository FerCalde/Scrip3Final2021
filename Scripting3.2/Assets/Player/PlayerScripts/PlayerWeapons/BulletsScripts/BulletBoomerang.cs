using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoomerang : BulletBase
{

    bool isMoving = false;
    bool front = true;
    GameObject goPlayer;
    [SerializeField] GameObject goFirePoint;


    Vector3 locationInFrontOfPlayer, locationStart;
    float speedBoomerang;

    Transform meshBoomerang;
    Vector3 rotationInicial;
    float rotBoomer;
    [SerializeField] float speedRotation = 10f;
    [SerializeField] Transform weaponAttach;
    public GameObject sfxChakrm;

    // Start is called before the first frame update
    protected override void Start()
    {
        isMoving = false;
        goPlayer = GameObject.FindGameObjectWithTag("Player");
        meshBoomerang = GetComponentInChildren<Transform>();
        rotationInicial = new Vector3(meshBoomerang.rotation.x, meshBoomerang.rotation.y, meshBoomerang.rotation.z);
    }

    protected override void FixedUpdate()
    {
        if (isMoving)
        {
            if (front)
            {
                if (Vector3.Distance(this.transform.position, locationInFrontOfPlayer) <= 0.5f)
                {
                    front = false;
                }

                transform.position = Vector3.MoveTowards(transform.position, locationInFrontOfPlayer, Time.deltaTime * speedBoomerang);
            }
            if (!front)
            {
                if (Vector3.Distance(this.transform.position, goFirePoint.transform.position) <= 0.5f)
                {
                    transform.position = goFirePoint.transform.position;
                    goPlayer.GetComponentInChildren<Chakram>().RecibirBoomerang();
                    isMoving = false;
                }
                if(Vector3.Distance(this.transform.position, goFirePoint.transform.position) <= 3f)
                {
                    goPlayer.GetComponentInChildren<Chakram>().VueltaBoomerAnim();
                }
                transform.position = Vector3.MoveTowards(transform.position, goFirePoint.transform.position, Time.deltaTime * speedBoomerang);
            }
            //ROTACION DEL BOOMERANG 
            rotBoomer += Time.deltaTime * speedRotation;
            meshBoomerang.rotation = Quaternion.Euler(meshBoomerang.rotation.x,rotBoomer, meshBoomerang.rotation.z);
        }

        if (!isMoving)
        {
            this.transform.position = weaponAttach.position;
        }


    }

    public void LanzarBoomerang(Vector3 posLanzamiento, float speed, float damageWeapon)
    {
        transform.position = goFirePoint.transform.position;
        locationInFrontOfPlayer = posLanzamiento;
        speedBoomerang = speed;
        damageBala = damageWeapon;
        front = true;
        isMoving = true;
        NuevoSonido(sfxChakrm, this.transform.position,2f);
    }


    protected override void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            if (other.tag != "IgnoreCollision")
            {
                if (other.GetComponent<VidaEnemyBase>() != null)
                {
                    AplicarEfecto(other);
                    NuevoSonido(chocaEnemigo[Random.Range(0, chocaEnemigo.Length - 1)], this.transform.position, 5f);
                }
                if (other.tag != "IgnoreBala")
                {
                    if (chocaPared.Length != 0)
                    {
                        NuevoSonido(chocaPared[Random.Range(0, chocaPared.Length - 1)], this.transform.position, 5f);
                    }
                }
            }
        }
    }

    protected override void AplicarEfecto(Collider coll)
    {
        VidaEnemyBase enemyColisionado = coll.GetComponent<VidaEnemyBase>();
        if (enemyColisionado != null)
        {
            enemyColisionado.TakeDamage(damageBala);
        }
    }

    public override void BulletColisiona()
    {

    }
    
}
