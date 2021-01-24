using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AplicarEfectosTemporales : MonoBehaviour
{

    [SerializeField] float tempoActual;
    bool isEffectApply = false;

    float speedActual; //Diferentes velocidades para modificarlas y luego restablecerlas
    float speedWalk = 3.5f; //SPEED ANDAR 
    NavMeshAgent cmpAgent;

    void Start()
    {
        cmpAgent = GetComponent<NavMeshAgent>();
        speedActual = speedWalk;
        cmpAgent.speed = speedActual;
    }

    void Update()
    {
       /* if (tempoActual >= Time.time)
        {
            isEffectApply = true;
        }

        else
        {
            if (tempoActual != 0)
            {
                isEffectApply = false;
            }
        }

        if (!isEffectApply)
        {
            RestablecerSpeed();
        }*/
        //cmpAgent.speed = speedActual;
    }

    public void IniciarEfecto(float tiempoEfecto, float speedRalentizada)
    {
        //print("EMPIEZA EFECTTT");
        tempoActual = Time.time + tiempoEfecto;
        RalentizarSpeed(speedRalentizada);
    }

    public void EfectoTriggerEnter(float speedRalenti)
    {
        //speedWalk = cmpAgent.speed;

        speedActual = speedRalenti;
        //print("SALISTE DEL TRIGGER");
    }
    public void EfectoTriggerExit()
    {
        speedActual = speedWalk;
        cmpAgent.speed = speedActual;
    }

    void RalentizarSpeed(float speedRalentizada)
    {
        speedActual = speedRalentizada; //Valor para el navMesh
        cmpAgent.speed = speedRalentizada;
    }

    void RestablecerSpeed()
    {
        speedActual = speedWalk;
    }

    public IEnumerator AplicarEfectoTemporal(float tiempoDuracionEfecto, float speedRalentizada)
    {

        speedActual = speedRalentizada;
        //print("CAMBIO SPEED");
        yield return new WaitForSeconds(tiempoDuracionEfecto);

        speedActual = speedWalk;
        //print("DEVUELVO SPEED");
        //StopCoroutine(AplicarEfectoTemporal(tiempoDuracionEfecto, speedRalentizada));
    }

    public void GrenadeSlowerEffect(float speedRalentizada)
    {
        speedActual = speedRalentizada;
        cmpAgent.speed = speedRalentizada;
    }

}
