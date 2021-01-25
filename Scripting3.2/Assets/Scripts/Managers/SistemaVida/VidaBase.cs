using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VidaBase : SingletonTemporal<VidaBase> {
    
    [SerializeField] protected float vidaMaxima = 100;
    [SerializeField]  protected float vidaActual;
    [SerializeField] protected bool hited = false;

    protected bool inmune = false;
    float tiempoInmune = 0;
       
    public bool Inmune
    {
        get { return inmune; }
    }
    public float VidaMaxima
    {
        get { return vidaMaxima; }
    }

    public float VidaActual
    {
        get { return vidaActual; }
        set { vidaActual = value; }
    }
    public bool Hited
    {
        get { return hited; }
        set { hited = value; }
    }

    protected Animator cmpAnimator;


    protected float cantDamageRecibida;


    public override void Awake()
    {
        base.Awake();
        
        cmpAnimator = GetComponent<Animator>();
    }
    
  
    protected virtual void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void ActivarInmunidadTemporal(float tiempoInmunidad)
    {
        inmune = true;
        tiempoInmune = tiempoInmunidad;
    }

    protected virtual void Update()
    {
        if(inmune)
        {
            tiempoInmune -= Time.deltaTime;
            if(tiempoInmune <= 0) { inmune = false; }
        }
    }

    public virtual void TakeDamage(float damage)
    {
        
        if(!inmune)
        {
            vidaActual -= damage;
            cantDamageRecibida = damage;
            if (vidaActual <= 0)
            {
                StartCoroutine(Morir());
            }
            Hited = true;
        }
    }

    

    public virtual IEnumerator Morir()
    {
        yield return 0;
    }


    public void DamageHabilidad(float damage)
    {
        vidaActual -= damage;
    }
}
