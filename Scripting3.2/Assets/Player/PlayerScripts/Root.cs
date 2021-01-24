using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    public Mov movimiento;
    Vector3 mousePos;
    Camera cam;
    CharacterController P;
    Vector3 pointToLook;

    float radio;
    [SerializeField] Transform firePointTransform;

    private void Awake()
    {
        cam = Camera.main;
        P = GetComponent<CharacterController>();
    }
    void Start()
    {
        radio = GetComponent<EnemyInfo>().radiusAim;
    }
    void Update()
    {
        
        Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);        
        float rayLength;
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            
            pointToLook = cameraRay.GetPoint(rayLength);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            
            GetComponent<EnemyInfo>().SetUpFireDirection(pointToLook);
        }
        

        /*RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            //pointToLook = ray.GetPoint();
            transform.LookAt(new Vector3(hit.transform.position.x, firePointTransform.position.y, hit.transform.position.z));
        }
        */
    }

    // PA DEBUGG
    /*void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(pointToLook, radio);
    }

    */
}
