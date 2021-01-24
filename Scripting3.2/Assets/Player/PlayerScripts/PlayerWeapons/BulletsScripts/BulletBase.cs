using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    public float speedBala = 10f;

    [SerializeField] float tiempoVida = 2f;

    public float damageBala = 10f;

    [SerializeField] GameObject prefParticulaExplosionBullet = null;
    public GameObject[] chocaPared;
    public GameObject[] chocaEnemigo;
    AudioSource cmpAudioSource;

    protected virtual void Start()
    {
        //cmpAudioSource = GetComponent<AudioSource>();
        Destroy(this.gameObject, tiempoVida);

        cmpAudioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        transform.position += transform.forward * speedBala * Time.deltaTime;
    }

    protected virtual void OnTriggerEnter(Collider collision) //EN ENEMIGO HACES OVERRIDE DE ESTE METODO E IDENTIFICAS AL PLAYER
    {
        if (collision.tag != "Player") //para evitar bugs   //AQUI ESTA IDENTIFICADO CUALQUIERA QUE NO ES PLAYER. EN EL ENEMIGO DETECTAS PLAYER Y LE HACES APLICAR EFECTO
        {
            if (collision.tag != "Enemy") //Identifica que NO es enemigo-
            {
                if (collision.tag != "IgnoreBala")
                {
                    if (chocaPared.Length != 0)
                    {
                        NuevoSonido(chocaPared[Random.Range(0, chocaPared.Length - 1)], this.transform.position, 5f);
                    }
                    // SoundVFX(ChocaPared);
                    BulletColisiona();
                }
            }
            else                           //CUANDO ES ENEMIGO A QUIEN IDENTIFICA
            {
                AplicarEfecto(collision);

                BulletColisiona();
            }

            InstanciarParticulasFeel();
        }
        /*if (collision.tag == "Enemy")
        {
            AplicarEfecto(collision);
            BulletColisiona();
        }*/

    }

    protected virtual void AplicarEfecto(Collider coll) // EN APLICAR EFECTO. BUSCA LA VIDA DEL PLAYER Y LE PASAS EL METODO TAKEDAMAGE(damageBala) ESTA VARIABLE LA TIENE 
    {                                                                                                                                       //EL SCRIPT

        VidaEnemyBase enemyColisionado = coll.GetComponent<VidaEnemyBase>();
        if (enemyColisionado != null)
        {
            if (chocaEnemigo.Length != 0)
            {
                NuevoSonido(chocaEnemigo[Random.Range(0, chocaEnemigo.Length - 1)], this.transform.position, 5f);
            }
            // SoundVFX(chocaEnemigo);
            enemyColisionado.TakeDamage(damageBala);
        }
        /* EnemyVida enemyColisionado = collision.GetComponent<EnemyVida>();   Comprobar que sea enemigo y enviarle el daño que hace el tipo de bullet
           if (enemyColisionado != null)
           {
               enemyColisionado.TakeDamage(damageBala);
           }
           */
    }


    public virtual void BulletColisiona()
    {

        Destroy(this.gameObject);
    }

    private void InstanciarParticulasFeel()
    {
        GameObject particulaColisionado = Instantiate(prefParticulaExplosionBullet, this.transform.position, this.transform.rotation);
        Destroy(particulaColisionado, 0.3f);
    }
    protected void SoundVFX(AudioClip[] vfxSoundActual)
    {
        int sonidoAleatorio = Mathf.RoundToInt(Random.Range(0, vfxSoundActual.Length - 1)); //Elige un sonido aleatorio dentro de la lista de Audioclips que le pasamos.

        cmpAudioSource.clip = vfxSoundActual[sonidoAleatorio]; //Cambia el clip del audio
        cmpAudioSource.Play();
    }
    protected void NuevoSonido(GameObject sonido, Vector3 pos, float duracion)
    {
        bool modificarPitch = true;
        GameObject obj = Instantiate(sonido, pos, Quaternion.identity);
        if (modificarPitch)
        {
            obj.GetComponent<AudioSource>().pitch *= 1 + Random.Range(-0.2f, 0.2f);
        }
        Destroy(obj, 3f);
    }
}
