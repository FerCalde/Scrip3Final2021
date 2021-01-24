using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadAsync : MonoBehaviour
{
    [SerializeField] public GameObject panelLoading;
    [SerializeField] public Text loadText;
    [SerializeField] public Slider sliderLoadBar;

    [SerializeField] bool needInputParaContinue = true;

    public void LevelLoader(int sceneIndex)
    {
        StartCoroutine(LoadAsynchro(sceneIndex));
    }

    IEnumerator LoadAsynchro(int sceneIndex)
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex); //Comienza operacion de carga       LoadSceneMode.Single
        if (needInputParaContinue)
        {
            operation.allowSceneActivation = false; //Bloquear salto automatico entre escenas para controlar.
        }
        panelLoading.SetActive(true); //activo el panel de carga

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f); //Operacion Clampear entre 0 y 1 
            sliderLoadBar.value = progress; //Seteo valor de Barra
            loadText.text = "Loading... " + progress * 100 + "%"; //Seteo texto

            if (operation.progress >= 0.9f) //Cuando esta cargada entera
            {
                loadText.text = "Pulsa Space para continuar"; //Actualizo Texto
                if (needInputParaContinue)
                {
                    if (Input.GetKeyDown(KeyCode.Space)) //Input para pasar a siguiente escena
                    {
                        operation.allowSceneActivation = true; //Doy control de que se actualice la escena.
                    }
                }
            }

            yield return null;
        }
    }
}
