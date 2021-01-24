using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperGunController : MonoBehaviour
{
    public int caseSize;
    public int currentAmmo;


    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = caseSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot()
    {

        currentAmmo--;
    }
    public void Recargar()
    {
          
            currentAmmo = caseSize;    
    }
}
