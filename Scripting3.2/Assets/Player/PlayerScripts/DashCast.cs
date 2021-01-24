using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DashCast : MonoBehaviour
{
    RaycastHit hit;
    public CharacterController Player;
    public Transform DashP;
    public Transform dashNoOffset;
    public float maxDashDistance;
    public bool dash;
    void Start()
    {
    }
    void Update()
    {
        Dash();
    }

    void Dash()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDashDistance))
        {
            DashP.localPosition = dashNoOffset.localPosition + new Vector3 (0,0, hit.distance - 0.5f);
            dash = true;
            /*dash = true;
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            if (Physics.Raycast(transform.position, transform.forward, out hit, DashPII.position.z + 0.5f))
            {
                dash = true;
                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);
                if (Physics.Raycast(transform.position, transform.forward, out hit, DashPIII.position.z + 1))
                {
                    dash = true;
                    Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.green);
                    if(Physics.Raycast(transform.position, transform.forward, out hit, 1))
                    {
                        dash = false;
                    }
                }
                else
                {
                    DashP.position = DashPIII.position;
                }
            }
            else
            {
                DashP.position = DashPII.position;
            }*/
        }
        else
        {
            dash = true;
            //Debug.Log("DashMax");
            DashP.localPosition = dashNoOffset.localPosition + new Vector3(0, 0, maxDashDistance);
        }

    }
}
