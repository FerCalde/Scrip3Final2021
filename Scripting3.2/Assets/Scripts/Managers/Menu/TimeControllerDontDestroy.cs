using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControllerDontDestroy : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (Time.timeScale < 1)
        {
            Time.timeScale = 1;
        }

    }

}
