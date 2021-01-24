using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPatrol : MonoBehaviour
{ 
    
    //public Animator m_animator;
    //[SerializeField] public float hearingDistance;

    //public int m_lastPatrolPoint = -1;
    //private bool haveAttacked;
    //public int damage= 25;
    //private bool dead = false;
    //private UnityEngine.AI.NavMeshAgent m_agent;
    //public float healthBar=100;
    //public Image healthBarImage;
    //public Image healthBarFondo;
    //float healthStart;
    //public GameObject[] waypoints;
    //StateMachine refStateManager;
    //Transform playerTrans;
    //public GameObject parentGroup;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    playerTrans = FindObjectOfType<Player>().transform;
    //    healthStart = healthBar;
    //    refStateManager = GetComponent<StateMachine>();
    //    m_agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    //    m_animator = GetComponent<Animator>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    healthBarImage.fillAmount = healthBar / healthStart;
    //    healthBarImage.transform.LookAt(playerTrans);
    //    healthBarFondo.transform.LookAt(playerTrans);
    //    if (healthBar <= 0&&!dead)
    //    {
    //        Muerte();
    //    }
    //}
    //public void OnIdleAnimCompleted()
    //{
        
    //    m_animator.ResetTrigger("Idle");
    //    refStateManager.ChangeState("Patrol");
    //}
    //void Attack()
    //{
    //    haveAttacked = false;
    //}
    //void StopAttack()
    //{
    //    haveAttacked = true;
    //}
    //private void OnTriggerStay(Collider collision)
    //{
    //    if (collision.gameObject.tag == "Player" && !haveAttacked)
    //    {
    //        haveAttacked = true;
    //        GameManager.Instance.vidaPlayer -= damage;
    //    }
    //}
    //void Muerte()
    //{
    //    m_animator.SetTrigger("Dead");
    //    dead = true;
    //    m_agent.ResetPath();
    //}
    //void Destroy()
    //{
    //    parentGroup.SetActive(false);
    //    Destroy(this.gameObject);
    //}
}
