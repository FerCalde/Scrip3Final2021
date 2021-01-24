using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldWork : MonoBehaviour
{
    [SerializeField] float vidaMax;
    public float vida;
    [SerializeField] float incrementoVida;
    public bool escudoReset = false;
    [SerializeField] float timeShieldDown;
    float timer = 0f;
    [SerializeField] ParticleSystem hit;
    [SerializeField] Material[] shieldMats;
    [SerializeField] GameObject borde;

    Renderer bordeRend;

    Renderer rend;

    void Start()
    {
        bordeRend = borde.GetComponent<Renderer>();
        rend = GetComponent<Renderer>();
        vida = vidaMax;
    }
    void Update()
    {
        if (vida < vidaMax)
        {
            if (escudoReset == false)
            {
                vida += incrementoVida * Time.deltaTime;
            }
            else
            {
                vida = 0;
                vida += incrementoVida * 7 * Time.deltaTime;
            }
        }
        if (vida <= 0)
        {
            escudoReset = true;
        }
        if (escudoReset)
        {
            borde.SetActive(false);
            Collider Collision = GetComponent<Collider>();
            MeshRenderer Render = GetComponent<MeshRenderer>();
            Collision.enabled = false;
            Render.enabled = false;
        }
        else
        {
            borde.SetActive(true);
            Collider Collision = GetComponent<Collider>();
            MeshRenderer Render = GetComponent<MeshRenderer>();
            Collision.enabled = true;
            Render.enabled = true;
        }
        if (vida < vidaMax / 1.5)
        {
            ;

            if (vida < vidaMax / 2)
            {
                rend.material = shieldMats[2];
                bordeRend.material = shieldMats[2];
            }
            else
            {
                rend.material = shieldMats[1];
                bordeRend.material = shieldMats[1];
            }
        }
        else
        {
            rend.material = shieldMats[0];
            bordeRend.material = shieldMats[0];
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "BalaPlayer")
        {
            BulletBase cmpBullet = col.GetComponent<BulletBase>();
            if (cmpBullet != null)
            {
                vida -= cmpBullet.damageBala;
                cmpBullet.BulletColisiona();
            }
            
            hit.gameObject.transform.position = col.gameObject.transform.position;
            hit.Play();
        }
    }
}
