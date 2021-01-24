using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocketTurret : MonoBehaviour
{
    StateMachine refStateManager;
    Animator miAnim;
    public float playerDistance;
    public int disparos;
    public bool morteroOn=false;
    public bool balaBajando=false;
    Mov playerRef;
    public GameObject torreta;
    public float distance2Apuntar;
    public float cadencia;
    public GameObject rangeObj;
    public Material safeMaterial;
    public Material dangerMaterial;
    public GameObject balaMortero;
    public GameObject camara;
    public float alturaMortero;
    public float tiempoParaCaer;
    float mortCont;
    float distSuelo;
    VidaEnemyBase vida;

    

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        playerRef = FindObjectOfType<Mov>();
        miAnim = GetComponent<Animator>();
        refStateManager = GetComponent<StateMachine>();
        vida = GetComponent<VidaEnemyBase>();
        newScale(rangeObj, distance2Apuntar);
    
    }

    // Update is called once per frame
    void Update()
    {
        
       playerDistance = Vector3.Distance(transform.position, playerRef.transform.position);

        if (!refStateManager.currentState.Contains("Idle"))
        {
            rangeObj.GetComponent<MeshRenderer>().material = dangerMaterial;
            MirarPlayer(); 
        }
        else
        {
            rangeObj.GetComponent<MeshRenderer>().material = safeMaterial;
            
        }
        if (morteroOn)
        {
            Vector3 spawnPoint = new Vector3(playerRef.transform.position.x, playerRef.transform.position.y+alturaMortero, playerRef.transform.position.z);
           timer += Time.deltaTime;

            int layerMask = 1 << 10; //layer del suelo
            RaycastHit hit;
            if(Physics.Raycast(spawnPoint, -transform.up,out hit,layerMask))
            {
                distSuelo = hit.point.y - spawnPoint.y;


            }
            if (timer >= tiempoParaCaer)
            {
                balaBajando = true;
                morteroOn = false;
                Instantiate(balaMortero, spawnPoint, transform.rotation);
                
                timer = 0;
            }
            
        }
        if (vida.VidaActual<= 0)
        {
            refStateManager.ChangeState("Destroy");
        }
        //if (bala.transform.position.y >= alturaMortero)
        //{
        //    morteroOn = true;
        //    bala.SetActive(false);
        //}
    }

    public void newScale(GameObject theGameObject, float newSize)
    {
        
        float sizeX = theGameObject.GetComponent<Renderer>().bounds.size.x;
        float sizeZ = theGameObject.GetComponent<Renderer>().bounds.size.z;

        Vector3 rescale = theGameObject.transform.localScale;

        rescale.x = newSize * rescale.x / sizeX*2;
        rescale.z = newSize * rescale.z / sizeZ *2;


        theGameObject.transform.localScale = rescale;

    }
    void MirarPlayer()
    {

        Vector3 lookVector = playerRef.transform.position - transform.position;
        lookVector.y = 0;
        Quaternion rot = Quaternion.LookRotation(lookVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 0.05f);
    }

}
