using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRT_Destroy : MonoBehaviour
{
    public GameObject[] objectParts;
    public float explosionForce;
    float timer;
    public float explosionTime;
    bool explosion=false;
    Animator miAnim;

    public ParticleSystem Muerte;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        miAnim = GetComponent<Animator>();
        Animaciones();
        Muerte.Play();

    }
    void Animaciones()
    {
        miAnim.ResetTrigger("Idle");
        miAnim.ResetTrigger("Aiming");
        miAnim.ResetTrigger("ShootRocket");
        miAnim.ResetTrigger("StartMortero");
        miAnim.ResetTrigger("ShootMortero");
        miAnim.SetTrigger("Death");

    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        

        //if (!explosion)
        //{
        //    for (int i = 0; i < objectParts.Length; i++)
        //    {
        //        //objectParts[i].transform.Translate(3, 3, 3);
        //        objectParts[i].GetComponent<Rigidbody>().AddForce((transform.up + transform.forward) * explosionForce, ForceMode.Impulse);
        //    }
        //    explosion = true;
        //}
        if (timer >= explosionTime)
        {
            gameObject.SetActive(false);

            
        }
    }
}
