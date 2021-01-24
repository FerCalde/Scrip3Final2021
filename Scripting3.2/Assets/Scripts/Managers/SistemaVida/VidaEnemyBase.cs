using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemyBase : VidaBase
{
    //ControlEnemigo controlEnemigo;
    //AtaqueEnemigo ataqueEnemigo;
    public bool hitted = false;
    public Vector3 lookForPlayer;
    InputManager managerCursor;
    public ParticleSystem sangre;

   // public AudioSource cmpAudioSource;
   // [SerializeField] protected AudioClip MuerteEnemigo;
    SkinnedMeshRenderer[] cmpSkinnedMeshRenderer;
    float tiempoColor = 1f;
    [SerializeField] Material colorDamage;

    [SerializeField] Material regularColor;
   // [SerializeField] protected AudioClip[] muerteEnemigo;

    public int contadorKills;
    public int contadorCombo;
    public float time;
    public GameObject[] sonidoExplosion;

    protected override void Awake()
    {
        base.Awake();
        cmpSkinnedMeshRenderer = GetComponentsInChildren<SkinnedMeshRenderer>();
        //cmpAudioSource = GetComponentInParent<AudioSource>();

        //Elegir los elementos que se quieren desactivar, o directamente el gameObject Entero-> Depende de lo que necesite el Rewind
        //controlEnemigo = GetComponent<ControlEnemigo>();-
        //ataqueEnemigo = GetComponent<AtaqueEnemigo>();
    }

    public override IEnumerator Morir()
    {


        //controlEnemigo.enabled = false;
        //ataqueEnemigo.enabled = false;

        GameObject.FindObjectOfType<GameManager>().ContadorMuerte();

        //SoundVFX(muerteEnemigo);
        if (sonidoExplosion.Length != 0)
        {
            NuevoSonido(sonidoExplosion[Random.Range(0, sonidoExplosion.Length - 1)], this.transform.position, 5f);
        }
        //cmpAnimator.SetTrigger("die");
        yield return new WaitForSeconds(3);


        // Destroy(this.gameObject);
    }
    private void FixedUpdate()
    {
        if (vidaActual <= 0)
        {

            //SoundVFX(muerteEnemigo);
            // print("sonidos de muerte");

        }
        //Debug.Log(VidaActual);
    }
    IEnumerator ChangeColor()
    {
        for (int i = 0; i < cmpSkinnedMeshRenderer.Length; i++)
        {
            cmpSkinnedMeshRenderer[i].material = colorDamage;
        }
        //regularColor = cmpSkinnedMeshRenderer.material;
        //cmpSkinnedMeshRenderer.material = colorDamage;
        //print(regularColor);
        yield return new WaitForSeconds(1);
        for (int i = 0; i < cmpSkinnedMeshRenderer.Length; i++)
        {
            cmpSkinnedMeshRenderer[i].material = regularColor;
        }
        //cmpSkinnedMeshRenderer.material = regularColor;
        //print("colorRegularPuta");

    }
    public override void TakeDamage(float damage)
    {
        
        base.TakeDamage(damage);

        sangre.Play();

        StartCoroutine(ChangeColor());

        hitted = true;
        lookForPlayer = GameObject.FindGameObjectWithTag("Player").transform.position;
      //  managerCursor.CambiarCursor();
        
    }
  
    

    public void ContadorCombo()
    {
        contadorCombo++;
    }

    void NuevoSonido(GameObject sonido, Vector3 pos, float duracion)
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
