using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectRoofs : MonoBehaviour
{
    RaycastHit hit;
    void Start()
    {

    }
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.gameObject.tag == "Roof")
            {
                Roof roof = hit.collider.gameObject.GetComponent<Roof>();
                roof.cameraShouldView = true;
                roof.timerRoofSpawn = 0f;
            }
        }


    }
}
