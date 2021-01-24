using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform Player;
    public Vector3 Offset;
    public float smoothSpeed;
    void LateUpdate()
    {
        Vector3 CamPos = Player.position + Offset;
        Vector3 SmoothCam = Vector3.Lerp(transform.position, CamPos, smoothSpeed);
        transform.position = SmoothCam; //CamPos;
    }
    void Update()
    {
        
    }
}
