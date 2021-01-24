using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorteroBala : MonoBehaviour
{
    
    Rigidbody miRb;
    public float signo;
    public float speed;
    Vector3 initialPlayerPos;
    public float damage;
    float R;
    float G;
    float tanAlpha;
    float H;
    EnemyRocketTurret enemyRef;
    GameObject camera;
    float distSueloInicial;
    float distSuelo;
    public GameObject circuloInterior;
    Vector3 circuloInteriorInicial;
    public GameObject circuloExterior;
    float t;
    float timer;
    public float tiempoCaida;
    [SerializeField]LayerMask layerMask;
    public ParticleSystem vfxExplosion;

    // Start is called before the first frame update
    void Start()
    {
        enemyRef = GetComponentInParent<EnemyRocketTurret>();
        miRb = GetComponent<Rigidbody>();
        transform.parent = null;
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        if (signo < 0)
        {
            miRb.AddForce(-1*transform.up */* new Vector3(0,2,1)**/ speed * 100);
            Vector3 spawnPoint = transform.position;
            //layerMask = 1 << LayerMask.NameToLayer("Suelo"); //layer del suelo
            RaycastHit hit;
            if (Physics.Raycast(spawnPoint, -transform.up, out hit, Mathf.Infinity, layerMask))
            {
                distSueloInicial = spawnPoint.y - hit.point.y;
                circuloExterior.transform.position = new Vector3(hit.point.x, hit.point.y + 0.1f, hit.point.z);
            }
        }
        else
        {
            miRb.AddForce((signo * transform.up) */* new Vector3(0,2,1)**/ speed * 100);

        }

        t = 0;
        
    }
    //private void Awake()
    //{
    //    circuloInteriorInicial = circuloInterior.transform.localScale;
    //}

    // Update is called once per frame
    void Update()
    {
        
        
        //int layerMask = LayerMask.GetMask("Suelo"); //layer del suelo
        RaycastHit hit;
        //Debug.Log(layerMask);
        if (Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity, layerMask)&&signo<0)
        {

            Debug.Log(hit.collider.gameObject.name);
            distSuelo =  transform.position.y-hit.point.y;
            
           // vfxExplosion.Play();
        }
        
        t = (distSueloInicial - distSuelo) / distSueloInicial;

        if (transform.position.y >=camera.transform.position.y&&signo>0)
        {
            enemyRef.morteroOn = true;
           // vfxExplosion.Play();
            this.gameObject.SetActive(false);
            
            print("explosion");
            //Destroy(gameObject);
           
        }

        if (signo<0)
        {
            timer += Time.deltaTime;

            circuloInterior.transform.localScale = new Vector3(Mathf.Lerp(0, 1, t), Mathf.Lerp(0, 1, t), circuloInterior.transform.localScale.z);
           
            //if (timer >= tiempoCaida)
            //{
            //    Destroy(circuloExterior.gameObject);
            //}
        }


        //miRb.velocity = BallisticVelocity(initialPlayerPos, launchAngle);

        //TiroParabolico();

        //Vector3 Vo = CalculateCatapult(playerTransform.position, transform.position, duration);

        //transform.GetComponent<Rigidbody>().velocity = Vo;

    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponentInParent<VidaJugador>().TakeDamage(damage);
            vfxExplosion.Play();
            gameObject.SetActive(false);
            //V.Tempo -= 8f;

        }

        gameObject.SetActive(false);
        circuloExterior.gameObject.SetActive(false);
    }
    private Vector3 BallisticVelocity(Vector3 destination, float angle)
    {
        Vector3 dir = destination - transform.position; // get Target Direction
        float height = dir.y; // get height difference
        dir.y = 0; // retain only the horizontal difference
        float dist = dir.magnitude; // get horizontal direction
        float a = angle * Mathf.Deg2Rad; // Convert angle to radians
        dir.y = dist * Mathf.Tan(a); // set dir to the elevation angle.
        dist += height / Mathf.Tan(a); // Correction for small height differences

        // Calculate the velocity magnitude
        float velocity = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return velocity * dir.normalized; // Return a normalized vector.
    }

    //Vector3 CalculateCatapult(Vector3 target, Vector3 origen, float time)
    //{
    //    Vector3 distance = target - origen;
    //    Vector3 distanceXZ = distance;
    //    distanceXZ.y = 0;

    //    float Sy = distance.y;
    //    float Sxz = distanceXZ.magnitude;

    //    float Vxz = Sxz / time;
    //    float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

    //    Vector3 result = distanceXZ.normalized;
    //    result *= Vxz;
    //    result.y = Vy;

    //    return result;
    //}
    void TiroParabolico()
    {


        Vector3 targetXZPos = new Vector3(initialPlayerPos.x, 0.0f, initialPlayerPos.z);

        // rotate the object to face the target
        transform.LookAt(targetXZPos);

        // shorthands for the formula


        // calculate the local space components of the velocity 
        // required to land the projectile on the target object 
        float Vz = Mathf.Sqrt(G * R * R / (2.0f * (H - R * tanAlpha)));
        float Vy = tanAlpha * Vz;

        // create the velocity vector in local space and get it in global space
        Vector3 localVelocity = new Vector3(0f, Vy, Vz);
        Vector3 globalVelocity = transform.TransformDirection(localVelocity);

        // launch the object by setting its initial velocity and flipping its state
        miRb.velocity = globalVelocity;

        //float speed =1f;
        //float arcHeight = 20;


    }

}
