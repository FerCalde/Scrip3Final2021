using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class shootShield : MonoBehaviour
{
    Animator miAnim;
    GameObject player;
    NavMeshAgent agent;
    [SerializeField] float maxTasherDist;
    float tasherDist;
    RaycastHit hit;
    [SerializeField] LineRenderer lr;
    [SerializeField] Transform shootPoint;
    StateMachine stMachine;
    public ShieldWork shield;
    [SerializeField] float tasherSpeed;
    [SerializeField] float stunTime;
    public GameObject sfxTaser;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        FacePlayer(player.transform.position);
        miAnim = GetComponent<Animator>();
        Animaciones();
        agent = GetComponent<NavMeshAgent>();
        stMachine = GetComponent<StateMachine>();
        
        tasherDist = 0f;
        agent.isStopped = true;
        

        lr.gameObject.SetActive(true);
    }
    void Update()
    {
        if (tasherDist < maxTasherDist)
        {
            if (Physics.Raycast(shootPoint.position, shootPoint.forward, out hit, tasherDist))
            {
                //NuevoSonido(sfxTaser, this.transform.position, 1f);
                if(hit.collider.tag == "Player")
                {
                    NuevoSonido(sfxTaser, this.transform.position, 1f);
                    lr.gameObject.SetActive(false);

                    hit.collider.gameObject.GetComponent<TasherEffect>().timer = stunTime;
                    hit.collider.gameObject.GetComponent<TasherEffect>().stunTime = stunTime;
                    hit.collider.gameObject.GetComponent<TasherEffect>().tashed = true;
                    
                    stMachine.ChangeState("Iddle");
                    shield.escudoReset = false;
                }
                else
                {
                    lr.gameObject.SetActive(false);
                    stMachine.ChangeState("Iddle");
                    shield.escudoReset = false;
                }
                if (hit.collider)
                {
                    lr.SetPosition(1, new Vector3(0, 0, hit.distance));
                }
            }
            else
            {
                tasherDist += tasherSpeed * Time.deltaTime;
                lr.SetPosition(1, new Vector3(0, 0, tasherDist));
            }
        }
        else
        {
            lr.gameObject.SetActive(false);
            stMachine.ChangeState("Iddle");
            shield.escudoReset = false;        
        }
    }
    void FacePlayer(Vector3 lookPos)
    {
        Vector3 lookTarget = lookPos;
        lookTarget.y = 0;
        /*Quaternion rotation = Quaternion.LookRotation(lookTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.005f);*/
        transform.LookAt(lookTarget);
        print(player.transform.position + " player  " + lookTarget + " look");
    }
    void Animaciones()
    {
        miAnim.ResetTrigger("Iddle");
        miAnim.ResetTrigger("Death");
        miAnim.ResetTrigger("Walk");
        miAnim.SetTrigger("ShieldDown");
    }
    void NuevoSonido(GameObject sonido, Vector3 pos, float duracion)
    {
        
        GameObject obj = Instantiate(sonido, pos, Quaternion.identity);
       
        Destroy(obj, 3f);
    }
}

