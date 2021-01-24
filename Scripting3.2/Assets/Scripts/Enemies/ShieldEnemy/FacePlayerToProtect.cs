using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayerToProtect : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        FacePlayer(player.transform.position);
    }
    void FacePlayer(Vector3 lookPos)
    {
        Vector3 lookTarget = lookPos - transform.position;
        lookTarget.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1f);
    }
}
