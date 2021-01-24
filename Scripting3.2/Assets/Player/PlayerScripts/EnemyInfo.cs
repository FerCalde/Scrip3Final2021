using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInfo : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] float maxDist;
    float vidaTarget;
    float vidaTargetMax;
    int layerMask;
    [SerializeField] GameObject[] enemyTipes;
    [SerializeField] Image vidaBarra;

    [SerializeField] public float radiusParticle = 0.2f;
    [SerializeField] public float radiusAim = 2.5f;
    [SerializeField] float radiusAutoAiming = 1.5f;
    [SerializeField] GameObject firePoint;
    [SerializeField] GameObject fireForwardDirection;
    [SerializeField] GameObject pointSelected; //JUST FOR TESTING!!
    public GameObject particulaVida;

    [SerializeField] bool isAutoAiming = true;

    Vector3 fireVector;

    void Start()
    {
        layerMask = 1 << LayerMask.NameToLayer("Enemy");

        if (fireForwardDirection == null)
        {
            fireForwardDirection = GameObject.Find("FireForwardPoint");
        }
    }

    //Raycast(transform.position, transform.forward, out hit, maxDist)
    void Update()
    {
        //Debug.Log(LayerMask.LayerToName(9));
        if (Physics.SphereCast(transform.position, radiusAim, transform.forward, out hit, maxDist, layerMask))
        {
            if (hit.collider.GetComponent<VidaEnemyBase>() != null)
            {
                if (hit.collider.GetComponent<CopEnemy>() != null)
                {
                    enemyTipes[0].SetActive(true);
                    enemyTipes[1].SetActive(false);
                    enemyTipes[2].SetActive(false);
                }
                else if (hit.collider.GetComponent<EnemyTirador>() != null)
                {
                    enemyTipes[0].SetActive(false);
                    enemyTipes[1].SetActive(true);
                    enemyTipes[2].SetActive(false);
                }
                else if (hit.collider.GetComponent<Kamikaze>() != null)
                {
                    enemyTipes[0].SetActive(false);
                    enemyTipes[1].SetActive(false);
                    enemyTipes[2].SetActive(true);
                }
                else
                {
                    enemyTipes[0].SetActive(false);
                    enemyTipes[1].SetActive(false);
                    enemyTipes[2].SetActive(false);
                }
                vidaBarra.gameObject.SetActive(true);
                vidaTarget = hit.collider.GetComponent<VidaEnemyBase>().VidaActual;
                vidaTargetMax = hit.collider.GetComponent<VidaEnemyBase>().VidaMaxima;
                vidaBarra.fillAmount = vidaTarget / vidaTargetMax;


            }
            else
            {
                /*if (isAutoAiming)
                {
                    
                    //firePoint.transform.LookAt(fireVector);
                    firePoint.transform.transform.LookAt(fireForwardDirection.transform);
                    pointSelected = fireForwardDirection;
                }*/
                vidaBarra.gameObject.SetActive(false);
                enemyTipes[0].SetActive(false);
                enemyTipes[1].SetActive(false);
                enemyTipes[2].SetActive(false);
            }

        }
        else
        {
            /*if (isAutoAiming)
            {
                //firePoint.transform.LookAt(fireVector);
                firePoint.transform.transform.LookAt(fireForwardDirection.transform);
                pointSelected = fireForwardDirection;
            }*/
            vidaBarra.gameObject.SetActive(false);
            enemyTipes[0].SetActive(false);
            enemyTipes[1].SetActive(false);
            enemyTipes[2].SetActive(false);
        }


        AutoAimingSetUp();

        if (Physics.SphereCast(transform.position, radiusParticle, transform.forward, out hit, maxDist, layerMask))
        {
            if (hit.collider.GetComponent<VidaEnemyBase>() != null)
            {
               // particulaVida.SetActive(true);
                hit.collider.GetComponentInChildren<AutoAim>().activarParticulavida(3);
            }
           
        }
    }


    public void AutoAimingSetUp()
    {

        if (Physics.SphereCast(transform.position, radiusAutoAiming, transform.forward, out hit, maxDist, layerMask))
        {
            if (hit.collider.GetComponent<VidaEnemyBase>() != null)
            {
                if (isAutoAiming)
                {
                    firePoint.transform.LookAt(hit.collider.GetComponentInChildren<AutoAim>().transform);
                    pointSelected = hit.collider.GetComponentInChildren<AutoAim>().gameObject;
                }
            }
            else
            {
                if (isAutoAiming)
                {
                    firePoint.transform.LookAt(fireVector);

                    //firePoint.transform.transform.LookAt(fireForwardDirection.transform);
                    pointSelected = fireForwardDirection;
                }
            }
        }
        else
        {
            if (isAutoAiming)
            {
                firePoint.transform.LookAt(fireVector);

                //firePoint.transform.transform.LookAt(fireForwardDirection.transform);
                pointSelected = fireForwardDirection;
            }
        }
    }

    public void SetUpFireDirection(Vector3 camRayPosition)
    {
        fireVector = new Vector3 (camRayPosition.x, firePoint.transform.position.y,camRayPosition.z);
        //fireVector = new Vector3(camRayPosition.x - fireForwardDirection.transform.position.x, fireForwardDirection.transform.position.y, camRayPosition.z - fireForwardDirection.transform.position.z);
    }
    
}
