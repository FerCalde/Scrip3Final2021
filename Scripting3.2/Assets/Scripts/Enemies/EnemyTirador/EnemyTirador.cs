using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTirador : MonoBehaviour
{
    public float distance2Apuntar;
    public GameObject fireSpot;
    Mov playerRef;
    StateMachine refStateManager;
    public bool miraEnPlayer;
    public LineRenderer lr;
    public GameObject lrGO;
    public int caseSize = 4;
    public int currentAmmo;
    Collider col;
    VidaEnemyBase vidaEnemy;

    // Start is called before the first frame update
    void Start()
    {
        playerRef = FindObjectOfType<Mov>();
        refStateManager = GetComponent<StateMachine>();
        col = GetComponent<Collider>();
        vidaEnemy = GetComponent<VidaEnemyBase>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vidaEnemy.VidaActual <= 0)
        {
            refStateManager.ChangeState("Death");
            col.enabled = false;
            lrGO.SetActive(false);
        }
        else
        {
            col.enabled = true;
            if (refStateManager.currentState.Contains("Apuntar"))
            {
                MirarPlayer();
                LaserPOV();
                Debug.Log("Entra");
                lrGO.SetActive(true);
            }
            else
            {
                lrGO.SetActive(false);
            }
        }
    }
    void MirarPlayer()
    {

        Vector3 lookVector = playerRef.transform.position - transform.position;
        lookVector.y = 0;
        Quaternion rot = Quaternion.LookRotation(lookVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 0.05f);
    }
    void LaserPOV()
    {
        int layerMask = 1 << 9;
        layerMask = ~layerMask;//todas las layers menos la de los enemigos

        RaycastHit hit;

        if (Physics.Raycast(fireSpot.transform.position, fireSpot.transform.forward, out hit, Mathf.Infinity,layerMask))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                miraEnPlayer = true;
            }
            else
            {
                miraEnPlayer = false;
            }
            if (hit.collider)
            {
                lr.SetPosition(1, new Vector3(0, 0, hit.distance));
            }
            else
            {
                lr.SetPosition(1, new Vector3(0, 0, Mathf.Infinity));
            }
        }
    }
}
