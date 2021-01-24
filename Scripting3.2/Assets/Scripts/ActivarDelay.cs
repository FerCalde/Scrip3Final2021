using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarDelay : MonoBehaviour
{
    public Mov Dash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Dash.Ddelay = 1.25f;
        }
    }
}
