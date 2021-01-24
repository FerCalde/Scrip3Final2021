using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Shoot : MonoBehaviour
{
    public GameObject Bala;
    public float RefreshTime = 0;
    float TimetoShoot = 0;
    public float MaxAmmo = 40;
    public float MunicionInicial = 20f;
    public float Municion;
    public Image AMMO;
    public bool AllowShoot = true;

    void Awake()
    {
        TimetoShoot = RefreshTime;
        Municion = MunicionInicial;
    }
    void Update()
    {
        AMMO.fillAmount = (Municion / MaxAmmo) / 2;
        if (Input.GetMouseButton(0))
        {
            if(Time.time > TimetoShoot)
            {
                if (Municion > 0)
                {
                    if(AllowShoot == true)
                    {
                        TimetoShoot = Time.time + RefreshTime;
                        shootRay();
                    }
                }
            }
        }
    }
    void shootRay()
    {
        Municion--;
        GameObject.Instantiate(Bala, transform.position, transform.rotation);
    }
}
