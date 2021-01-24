using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roof : MonoBehaviour
{
    MeshRenderer meshRoof;
    public bool cameraShouldView = false;
    public float timerRoofSpawn = 0f;
    void Start()
    {
        meshRoof = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        if (cameraShouldView)
        {
            meshRoof.enabled = false;
            timerRoofSpawn += 1 * Time.deltaTime;
            if (timerRoofSpawn >= 1)
            {
                cameraShouldView = false;
            }
        }
        else
        {
            meshRoof.enabled = true;
        }
    }
}
