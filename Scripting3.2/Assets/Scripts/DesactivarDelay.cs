using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarDelay : MonoBehaviour
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
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Dash.Ddelay = 0;
        }
    }
}
