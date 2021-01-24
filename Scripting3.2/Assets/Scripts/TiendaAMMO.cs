using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiendaAMMO : MonoBehaviour
{
    public GameObject Icono;
    public GameObject CanvasAmmo;
   // public Vida V;
    public Shoot S;
    bool AbrirTienda = false;
    bool EnTienda = true;

    public Text Ammo;
    public Text time;

    public Text Prof;
    public Text Cost;
    Color ProfC;
    Color CostC;
    void Awake()
    {
        Icono.SetActive(false);
        CanvasAmmo.SetActive(false);
        ProfC = Prof.color;
        CostC = Cost.color;
    }
    void Update()
    {
        TiendaCanvas();
        Tienda();
        Prof.color = ProfC;
        Cost.color = CostC;
        if (ProfC.a > 0)
        {
            ProfC.a -= 0.01f;
        }
        if (CostC.a > 0)
        {
            CostC.a -= 0.01f;
        }
        
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            Icono.SetActive(true);
            AbrirTienda = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Icono.SetActive(false);
            AbrirTienda = false;
        }
    }
    void Tienda()
    {
        if (AbrirTienda == true)
        {
            if (Input.GetKeyDown("e"))
            {
                if (EnTienda == false)
                {
                    CanvasAmmo.SetActive(true);
                    Time.timeScale = 0f;
                    EnTienda = true;
                    S.AllowShoot = false;
                }
                else
                {
                    CanvasAmmo.SetActive(false);
                    Time.timeScale = 1f;
                    EnTienda = false;
                    S.AllowShoot = true;
                }
                
            }
        }
    }
    void TiendaCanvas()
    {
        //time.text ="" + V.Tempo;
        Ammo.text = "" + S.Municion;
    }
    public void TiendaUso()
    {
        ProfC.a = 1;
        CostC.a = 1;
        if (S.Municion < S.MaxAmmo)
        {
           // V.Tempo -= 5;
            S.Municion += 10;
        }
        
        if (S.Municion >= S.MaxAmmo)
        {
            S.Municion = S.MaxAmmo;
        }

    }
}
