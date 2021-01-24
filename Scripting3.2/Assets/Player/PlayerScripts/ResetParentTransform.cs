using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetParentTransform : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        this.transform.SetParent(null, false); 
    }

}
