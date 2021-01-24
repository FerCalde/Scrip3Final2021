using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerObjetivo : MonoBehaviour
{
    public GameObject finalLevel;
    bool enObjetivo = false;
    public GameObject press;
    void Update()
    {
        if (enObjetivo)
        {
            if (Input.GetKey(KeyCode.E))
            {
                press.SetActive(false);
                finalLevel.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            enObjetivo = true;
            press.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            enObjetivo = false;
            press.SetActive(false);
        }
    }
}
