using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButonSelectorTry : MonoBehaviour
{
    public int numClase = 0;


    [SerializeField] public GameObject panelLoading;
    [SerializeField] public Text loadText;
    [SerializeField] public Slider sliderLoadBar;


    public void SeleccionButton()
    {
        SelectorClaseManager.claseSeleccionada = numClase;

        StartCoroutine(LoadMenuAsynchro(8));
       // SceneManager.LoadScene("NivelFinal");
    }

    IEnumerator LoadMenuAsynchro(int sceneIndex)
    {
        //yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex); //Comienza operacion de carga       LoadSceneMode.Single

        operation.allowSceneActivation = false; //Bloquear salto automatico entre escenas para controlar.

        panelLoading.SetActive(true); //activo el panel de carga

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f); //Operacion Clampear entre 0 y 1 
            sliderLoadBar.value = progress; //Seteo valor de Barra
            loadText.text = "Loading... " + progress * 100 + "%"; //Seteo texto

            if (operation.progress >= 0.9f) //Cuando esta cargada entera
            {
                operation.allowSceneActivation = true; //Doy control de que se actualice la escena.                
            }

            yield return null;
        }
    }
}
