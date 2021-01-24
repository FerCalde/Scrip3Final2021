using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAMMANAGER : MonoBehaviour
{
    GameObject player;
    GameObject camF;
    Camera cam;
    [SerializeField] float threshold;
    void Awake()
    {
        camF = GameObject.FindGameObjectWithTag("MainCamera");
        cam = camF.GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Aiming();
        }
        else
        {
            Follow();
        }
    }
    void Follow()
    {
        Vector3 targetpos = player.transform.position;
        this.transform.position = targetpos;
    }
    void Aiming()
    {
        Vector3 targetPos;
        Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 mousePos = cameraRay.GetPoint(rayLength);
            targetPos = (player.transform.position + mousePos)/2;

            targetPos.x = Mathf.Clamp(targetPos.x, -threshold + player.transform.position.x, threshold + player.transform.position.x);
            targetPos.z = Mathf.Clamp(targetPos.z, -threshold + player.transform.position.z, threshold + player.transform.position.z);
            targetPos.y = Mathf.Clamp(targetPos.y, -threshold + player.transform.position.y, threshold + player.transform.position.y);

            this.transform.position = targetPos;
        }
        
    }
}
