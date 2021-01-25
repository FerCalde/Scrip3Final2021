using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]  HabilidadBase habilidadRewind, habilidadClase;
   
    public delegate void OnStart();
     public event OnStart PressFire;
     public event OnStart ReleaseFire;
    public event OnStart ReloadInput;


    public static InputManager Instance
    {
        get;
        private set;
    }

    public void Awake()
    {
        Instance = this;

    }

    void Start()
    {
        //habilidad = GameObject.FindGameObjectWithTag("Player").GetComponent<HabilidadBase>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PressFire();
        }
        if (Input.GetMouseButtonUp(0))
        {
            ReleaseFire();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadInput();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            RewindManagment.StartRewinding();
            
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            habilidadClase.Activar();
        }
    }

   
}
