using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class RewindLogicBalas : MonoBehaviour
{
    public bool isRewinding = false;
    float tiempo;

    [SerializeField] float recordTime = RewindManagment.recordTime;

    public GameObject BalaRewinding;

    //TimerDestruccion;
    public float destruccionTime = 0;

    List<ListsRewindBalas> PointsInTime;
    void Start()
    {
        PointsInTime = new List<ListsRewindBalas>();
    }
    void Rewind()
    {
        if(PointsInTime.Count == 1)
        {
            ListsRewindBalas pointInTime = PointsInTime[0];
            if(tiempo < recordTime)
            {
                Destroy(gameObject);
            }
            
        }
        if (PointsInTime.Count > 0)
        {
            ListsRewindBalas pointInTime = PointsInTime[0];
            BalaRewinding.transform.position = pointInTime.position;
            BalaRewinding.SetActive(pointInTime.activo);
            BalaRewinding.GetComponent<ShotBehavior>().speed = pointInTime.speed;
            PointsInTime.RemoveAt(0);
        }
        else 
        {
            Destroy(gameObject);
        }
    }
    void Record()
    {
        if (PointsInTime.Count > Mathf.Round(recordTime / Time.deltaTime))
        {
            PointsInTime.RemoveAt(PointsInTime.Count - 1);
        }
        PointsInTime.Insert(0, new ListsRewindBalas(BalaRewinding.transform.position, tiempo, BalaRewinding.activeSelf, BalaRewinding.GetComponent<ShotBehavior>().speed));
    }
    void Update()
    {
        if (RewindManagment.isRewinding)
        {
            Rewind();
            destruccionTime = 0f;
        }
        else
        {
            Record();
        }
        if (BalaRewinding.activeSelf == false)
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
