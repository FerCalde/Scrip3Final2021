using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{

    [SerializeField] public List<ArmaBase> armasEquipadas = new List<ArmaBase>();
    ArmaBase armaActual;


    GameObject armaEquipada, armaEquipada2, armaEquipada3;
    [SerializeField] public List<ArmaBase> claseSeleccionadaWeapons = new List<ArmaBase>();

    //float tiempoEspera = 0f; //Utilizado para setear valores de la espera Recarga/Cambiar Arma
    [SerializeField] bool isReloading = false;
    [SerializeField] bool isChangingWeapon = false;
    public bool isBusy = false;

    [SerializeField] Animator Anim;

    [SerializeField] Image weaponEquipadaImg;
    [SerializeField] Image weaponEquipadaImg2;
    [SerializeField] GameObject weaponEquipada1;
    //[SerializeField] GameObject weaponEquipada2;
    [SerializeField] Text currentAmmoText;
    [SerializeField] Animator animHud;
    
    public bool IsReloading { get => isReloading; set => isReloading = value; }
    
    

    float delayReloading;


    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();

        /*  CODIGO RESERVADO PARA LA UPDATE CUANDO TENGAMOS LAS CLASES HECHAS, PARA ELEGIR LAS ARMAS Y HABILIDADES QUE CORRESPONDEN A CADA ARMA!
         *  NO BORRAR NO BORRAR NO BORRAR
         *  CODIGO EN PROGRESO
        string nameEquiped1 = WeaponSelectManager.weaponNameSelected;
        armaEquipada = GameObject.Find(nameEquiped1);
        if (armaEquipada != null)
        {
            ArmaBase armaSelected1 = armaEquipada.GetComponent<ArmaBase>();
            claseSeleccionadaWeapons.Add(armaSelected1);
        }

        string nameEquiped2 = WeaponSelectManager.weaponNameSelected2;
        armaEquipada2 = GameObject.Find(nameEquiped2);
        if(armaEquipada2 != null)
        {
            ArmaBase armaSelected2 = armaEquipada2.GetComponent<ArmaBase>();
            claseSeleccionadaWeapons.Add(armaSelected2);
        }

        string nameEquiped3 = WeaponSelectManager.weaponNameSelected3;
        armaEquipada3 = GameObject.Find(nameEquiped3);
        if(armaEsquipada3!=null)
        {
            ArmaBase armaSelected3 = armaEquipada3.GetComponent<ArmaBase>();
            claseSeleccionadaWeapons.Add(armaSelected3);
        }
         *  NO BORRAR NO BORRAR NO BORRAR
        */
        //((InputManager)InputManager.Instance).PressFire += ControllerFire();

        foreach (var arma in armasEquipadas) //Desactivo todas las armas
        {
            arma.gameObject.SetActive(false);
            arma.weaponModelPrefab.SetActive(false); //DesactivaModeloArma

            arma.CurrentAmmoText = currentAmmoText; //Seteo del texto donde ira el Ammo actual del weapon.
        }

        if (claseSeleccionadaWeapons.Count != 0) //En caso de haber una clase seleccionada con sus correspondientes weapons, se actualizan las armas que lleva el player.
        {
            armasEquipadas = new List<ArmaBase>();
            armasEquipadas = claseSeleccionadaWeapons;
        }


        armaActual = armasEquipadas[0]; //seteo arma actual
        armaActual.gameObject.SetActive(true);
        armaActual.weaponModelPrefab.SetActive(true);//Activa modelo del arma
        CheckerAnimator();

        //weaponEquipadaImg.sprite = armaActual.ScreenWeaponImg; //Update Imagen Weapon Equipada

        ChangeWeaponInHUD();

        armaActual.BulletScreen();
    }

    

    // Update is called once per frame
    void Update()
    {
        if (!isReloading && !isChangingWeapon && !isBusy)
        {
            CambiarWeapon(); //Es instantáneo. DISEÑO, ¿QUIERE COOLDOWN PARA CAMBIAR ARMAS? QUIERE QUE TARDE UN TIEMPO EN REALIZAR EL CAMBIO?

            InputDisparo();

            InputRecarga();
        }

        if (isReloading)
        {
            if (Time.time >= delayReloading)
            {
                AnimEventFinishReload();
                
            }
        }
          
    }

    private void InputRecarga() //TIEMPO DE RECARGA CONTROLADO POR DURACION ANIMACION!
    {
        if (Input.GetKeyDown(KeyCode.R)) //Press R
        {

            armaActual.SoltarGatillo();

            isReloading = true;

            armaActual.Recargar();

            armaActual.BulletScreen();
            animHud.SetBool("recargando", true);

            Anim.SetBool("Reloading", true);            
        }        
    }
    public void autoReloadController()
    {
        armaActual.SoltarGatillo();

        isReloading = true;

        armaActual.Recargar();

        armaActual.BulletScreen();
        animHud.SetBool("recargando", true);

        Anim.SetBool("Reloading", true);
    }
    public void StartReload(float delayWeaponReload)
    {
        delayReloading = Time.time + delayWeaponReload;
    }
    private void InputDisparo()
    {
        if (Input.GetMouseButtonDown(0)) //Press FIRE
        {
            if (!armaActual.isGrenade)
            {

            }
            armaActual.ApretarGatillo();

            armaActual.BulletScreen();
        }

        if (Input.GetMouseButtonUp(0)) //Release FIRE
        {
            armaActual.SoltarGatillo();

            if (armaActual.isGrenade)
            {
                Anim.ResetTrigger("Grenade");
            }
            else
            {
                Anim.ResetTrigger("Shooting");
            }
        }
    }


    void ControllerFire()
    {
        armaActual.ApretarGatillo();
    }
    public void ControllerStopFire()
    {
        armaActual.SoltarGatillo();
    }
    private void CambiarWeapon()
    {
        for (int i = 1; i <= armasEquipadas.Count; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                armaActual.gameObject.SetActive(false);
                armaActual.weaponModelPrefab.SetActive(false); //DesactivaModeloArma
                armaActual = armasEquipadas[i - 1];
                armaActual.gameObject.SetActive(true);
                armaActual.weaponModelPrefab.SetActive(true);  //Activa modelo del arma
                CheckerAnimator();

                
                ChangeWeaponInHUD();    //Update Imagen del arma equipada
                armaActual.BulletScreen();

                /*if( i == 1 )
                {
                    weaponEquipada1.SetActive(true);
                    weaponEquipada2.SetActive(false);
                }
                if( i == 2)
                {
                    weaponEquipada1.SetActive(false);
                    weaponEquipada2.SetActive(true);
                }*/
                
            }
            
        }
    }
    void CheckerAnimator()
    {
        //Layer 1-> 2HandWeapon
        //Layer 2-> OneHandWeapon
        //Layer 3-> Greanade

        //print("Cambio Layer");
        if (armaActual.isGrenade)
        {
            Anim.SetLayerWeight(3, 1f);
            Anim.SetLayerWeight(1, 0f);
            Anim.SetLayerWeight(2, 0f);
        }
        else if (armaActual.isOneHandWeapon && !armaActual.isGrenade)
        {
            Anim.SetLayerWeight(2, 1f);
            Anim.SetLayerWeight(1, 0f);
            Anim.SetLayerWeight(3, 0f);
        }
        else if (!armaActual.isOneHandWeapon && !armaActual.isGrenade)
        {
            Anim.SetLayerWeight(1, 1f);
            Anim.SetLayerWeight(2, 0f);
            Anim.SetLayerWeight(3, 0f);
        }
    }

    private void ChangeWeaponInHUD()
    {
        weaponEquipada1.GetComponent<Image>().sprite = armaActual.ScreenWeaponImg;
        weaponEquipada1.GetComponent<Animator>().runtimeAnimatorController = armaActual.ScreenWeaponHUDAnimatorController;
    }


    //EVENTOS ANIMACION

    public void AnimEventLanzarGrenade() //Activa eventos para instanciar la granada
    {
        armaActual.GetComponent<LanzagranadaRalenti>().EventLanzarGrenade();
    }

    public void AnimEventAcabaGranada() //Activa AnimEvent para finalizar granada;
    {
        Anim.ResetTrigger("Grenade");
        isBusy = false;
    }

    public void AnimEventFinishReload()
    {

        armaActual.FinishReload();
        Anim.SetBool("Reloading", false);
        animHud.SetBool("recargando", false);
        isReloading = false;
    }

    public void AnimEventLanzarBoomer()
    {
        if (armaActual.GetComponent<Chakram>() != null)
        {
            armaActual.GetComponent<Chakram>().EventLanzarBoomer();        
        }
    }
    
    public void BusyState()
    {
        isBusy = !isBusy;
    }
}
