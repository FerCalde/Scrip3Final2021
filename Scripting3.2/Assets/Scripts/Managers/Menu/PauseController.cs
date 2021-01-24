using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    GameManager gm;

    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject panelOptions;

    [SerializeField] public GameObject panelLoading;
    [SerializeField] public Text loadText;
    [SerializeField] public Slider sliderLoadBar;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        //gm.PauseGame();
        pausePanel.SetActive(gm.IsPaused);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gm.PauseGame();
            pausePanel.SetActive(gm.IsPaused);
            if (!gm.IsPaused)
            {
                panelOptions.SetActive(false);
            }
        }
    }

    public void ResumeGame()
    {
        gm.PauseGame();
        pausePanel.SetActive(gm.IsPaused);
    }

    public void MainMenu()
    {
        // SceneManager.LoadScene(0);
        StartCoroutine(LoadMenuAsynchro(0));
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


    public void CaldeBorralo()
    {
        StartCoroutine(LoadMenuAsynchro(7));
    }
}



