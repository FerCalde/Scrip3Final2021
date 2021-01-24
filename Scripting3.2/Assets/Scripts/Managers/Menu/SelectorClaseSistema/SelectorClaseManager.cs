using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorClaseManager : MonoBehaviour
{
    public static int claseSeleccionada; //Indica la posicion que ocupa la clase en la lista

    [SerializeField] List<GameObject> goPlayerClases = new List<GameObject>();
    [SerializeField] List<GameObject> goCamerasPlayers = new List<GameObject>();//Han de tener el mismo numero que clases, en el mismo orden segun cameras follow a Cam manager
    public GameObject goClaseEquipada;
    GameObject goCamFollow;


    void Awake()
    {
        goClaseEquipada = goPlayerClases[claseSeleccionada];
        goCamFollow = goCamerasPlayers[claseSeleccionada];
    }

    
    void Start()
    {
        if (goCamerasPlayers != null) //Active Camera 
        {
            foreach(var camsPlayer in goCamerasPlayers)
            {
                if (camsPlayer != goCamFollow)
                {
                    camsPlayer.SetActive(false);
                }
                else
                {
                    camsPlayer.SetActive(true);
                }

            }
        }
        if (goPlayerClases != null) //Active Player
        {
            foreach (var clasesPlayer in goPlayerClases)
            {
                if (clasesPlayer != goClaseEquipada)
                {
                    clasesPlayer.SetActive(false);
                }
                else
                {
                    clasesPlayer.SetActive(true);
                }
            }
        }
    }

}
