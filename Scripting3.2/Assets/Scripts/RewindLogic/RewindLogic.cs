using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class RewindLogic : MonoBehaviour {

    [SerializeField] float recordTime = RewindManagment.recordTime;

    public GameObject EnemyRewinding;
    public VidaEnemyBase VidaEnemyRewinding;
    public StateMachine refStateManager;
    [SerializeField] ParticleSystem particleRewindEnemy;
    
    Kamikaze sonidoRewind;
    //TimerDestruccion;
    float destruccionTime = 0;

    List<ListsRewind> PointsInTime;
    void Start()
    {
        sonidoRewind = GetComponentInChildren<Kamikaze>();
        PointsInTime = new List<ListsRewind>();
    }
    void Rewind()
    {
       // sonidoRewind.SoundVFX(soundRewind);

        if (PointsInTime.Count > 0)
        {
           
            ListsRewind pointInTime = PointsInTime[0];
            EnemyRewinding.transform.position = pointInTime.position;
            EnemyRewinding.transform.rotation = pointInTime.rotation;
            ;
            refStateManager.ChangeState(pointInTime.estado);
            VidaEnemyRewinding.VidaActual = pointInTime.vida;

            PointsInTime.RemoveAt(0);
           
        }
        else 
        {
            RewindManagment.StopRewinding();
            
            print(" STOP Rewind");
        }
    }
    void Record()
    {
       
        if (PointsInTime.Count > Mathf.Round(recordTime / Time.deltaTime))
        {
            PointsInTime.RemoveAt(PointsInTime.Count - 1);
        }
        PointsInTime.Insert(0, new ListsRewind(EnemyRewinding.transform.position, EnemyRewinding.transform.rotation, refStateManager.currentState, VidaEnemyRewinding.VidaActual));
    }
    void Update()
    {
       
        if (RewindManagment.isRewinding)
        {
            
            Rewind();
            
            particleRewindEnemy.Play();
           //sonidoRewind.SoundVFX(soundRewind);
            //print("sonido");
            destruccionTime = 0f;
        }
        else
        {
            Record();
            particleRewindEnemy.Stop();
            
        }
        if (VidaEnemyRewinding.VidaActual <= 0)
        {
            destruccionTime += Time.deltaTime;
        }
        else
        {
            destruccionTime = 0f;
        }
        if (destruccionTime >= recordTime)
        {
            Destroy(gameObject);
        }
        
    }
}
