using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dron : MonoBehaviour
{
    /*
    NavMeshAgent Dr;
    public GameObject[] Enemy;
    public VidaEnemigo[] VidasCheck;

    public GameObject[] Fx;

    bool Curando;

    int curandose = 0;
    void Start()
    {
        Dr = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (Curando == false)
        {
            if (Enemy[0] != null)
            {
                if (VidasCheck[0].vida < 25)
                {
                    Curando = true;
                    curandose = 1;
                }
            }
            else if (Enemy[1] != null)
            {
                if (VidasCheck[1].vida < 25)
                {
                    Curando = true;
                    curandose = 2;
                }
            }
            else if (Enemy[2] != null)
            {
                if (VidasCheck[2].vida < 25)
                {
                    Curando = true;
                    curandose = 3;
                }
            }

        }
        Curar(curandose);
    }
    void Curar(int i)
    {
        if (Curando == true)
        {
            if (Enemy[i - 1] != null)
            {
                Dr.destination = Enemy[i - 1].transform.position;
                transform.LookAt(Enemy[i - 1].transform.position);
                VidasCheck[i - 1].vida += 9 * Time.deltaTime;
                Fx[i - 1].SetActive(true);
                if (VidasCheck[i - 1].vida >= VidasCheck[i - 1].maxVida)
                {
                    VidasCheck[i - 1].vida = VidasCheck[i - 1].maxVida;
                    Curando = false;
                    Fx[i - 1].SetActive(false);
                }
            }
            else
            {
                Curando = false;
            }
        }
        





    }*/
}
