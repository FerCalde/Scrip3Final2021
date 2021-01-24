using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMisiones : MonoBehaviour
{
    [Header("Mision 1")]
    public GameObject misionUnoPanel;
    public GameObject objetivoPlantillaPanel;
    public GameObject subObjetivoPlantilla;
    public int misionUnoObjetivos;
    public int misionUnoSubObjetivos;
    GameObject objetivoContenedor;


    public GameObject objetivoPlantillaSec;
    public GameObject subObjetivoPlantillaSec;
    public int misionUnoObjetivosSec;
    public int misionUnoSubObjetivosSec;


    // Start is called before the first frame update
    void Start()
    {
        StartMision1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region Mision 1
    void StartMision1()
    {
        for (int i = 0; i < misionUnoObjetivos; i++)
        {
            Debug.Log("entra");
            objetivoContenedor = Instantiate(objetivoPlantillaPanel, misionUnoPanel.transform);
            for (int t = 0; t < misionUnoSubObjetivos; t++)
            {
                Debug.Log("entra SubObjetivos");
                Instantiate(subObjetivoPlantilla, objetivoContenedor.transform);
            }
        }
    }

    #endregion
}
