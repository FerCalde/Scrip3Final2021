using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoMisionHUDCity : MonoBehaviour
{
    [SerializeField] Text textMisionTitle;
    [SerializeField] Text text_MisionDescripcion;
    int nivelSelectedPlay;

    void OnEnable()
    {
        //nivelSelectedPlay = LevelManager.Instance.nivelActualSelected;

        if (nivelSelectedPlay != 0)
        {
            textMisionTitle.text = "Nivel " + nivelSelectedPlay.ToString();
        }
        else
        {
            textMisionTitle.text = "Tutorial" ;
        }
         //TextosCiudad.text_misionDescripcion[nivelSelectedPlay];
    }
    public void SetCurrentMissionInfo(int nivelSelect, string textDescript,Color colorPanel)
    {
        nivelSelectedPlay = nivelSelect;
        text_MisionDescripcion.text = textDescript;
        GetComponent<Image>().color = colorPanel;
    }
    
}