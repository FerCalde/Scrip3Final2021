using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasherEffect : MonoBehaviour
{
    public bool tashed = false;
    public Mov controller;
    public float timer = 0f;
    public float stunTime;
    [SerializeField]Material blur;
    float speedCorriente = 7.5f;
    [SerializeField] Light flash;
    bool luz = false;
    void Start()
    {
        speedCorriente = controller.speed;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (tashed)
        {
            controller.speed = speedCorriente / 4;
            blur.SetFloat("Vector1_6425954C", timer * 0.05f / stunTime) ;
            blur.SetFloat("Vector1_A92DCA01", timer / stunTime);
            if(flash.intensity > 1.9f)
            {
                luz = true;
            }
            if (flash.intensity < 0.2f)
            {
                luz = false;
                
            }
            if (luz)
            {
                flash.intensity -= Time.deltaTime * 2f;
            }
            else
            {
                flash.intensity += Time.deltaTime * 2f;
            }
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                tashed = false;
            }
        }
        else
        {
            controller.speed = speedCorriente;
            blur.SetFloat("Vector1_6425954C", 0);
            blur.SetFloat("Vector1_A92DCA01", 0);
        }
    }
}
