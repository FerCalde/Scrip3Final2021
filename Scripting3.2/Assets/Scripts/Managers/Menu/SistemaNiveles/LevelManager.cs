using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : SingletonTemporal<LevelManager>
{
    [SerializeField] GameObject[] totalNiveles;
    [HideInInspector]public int nivelesCompletados;
    [SerializeField] GameObject[] modelsParticleFeedback;


    [Tooltip("Aqui debes hacer un array de tantos textos como niveles haya (vamos a tener 3, no te compliques.). a partir de ahi deja volar tu imaginacion y escribe buena mierda")]
    [SerializeField] [TextArea] public string[] text_misionDescripcion;
    
    [SerializeField] GameObject panelMisionInfo;
    int nivelJuegoScene;

    // Start is called before the first frame update
    void Start()
    {
        LoadCurrentLevels();

        if (totalNiveles != null && totalNiveles.Length != 0)
        {
            if (panelMisionInfo != null)
            {
                panelMisionInfo.SetActive(false);
            }

            for (int i = 0; i <= (totalNiveles.Length - 1); i++)
            {
                if (i < nivelesCompletados)
                {
                    GameObject particleFeedbackLevel = Instantiate(modelsParticleFeedback[0], totalNiveles[i].transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
                    particleFeedbackLevel.transform.SetParent(totalNiveles[i].transform);
                    if (particleFeedbackLevel.GetComponent<ParticleSystem>() != null)
                    {
                        particleFeedbackLevel.GetComponent<ParticleSystem>().Play();
                    }
                    // totalNiveles[i].SetActive(true);
                }
                if (i == nivelesCompletados)
                {
                    GameObject particleFeedbackLevel = Instantiate(modelsParticleFeedback[1], totalNiveles[i].transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
                    particleFeedbackLevel.transform.SetParent(totalNiveles[i].transform);
                    if (particleFeedbackLevel.GetComponent<ParticleSystem>() != null)
                    {
                        particleFeedbackLevel.GetComponent<ParticleSystem>().Play();
                    }
                }
                if (i > nivelesCompletados)
                {
                    GameObject particleFeedbackLevel = Instantiate(modelsParticleFeedback[2], totalNiveles[i].transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
                    particleFeedbackLevel.transform.SetParent(totalNiveles[i].transform);
                    if (particleFeedbackLevel.GetComponent<ParticleSystem>() != null)
                    {
                        particleFeedbackLevel.GetComponent<ParticleSystem>().Play();
                    }
                    // totalNiveles[i].SetActive(false);
                }
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            ResetLevels();
        }
    }
    void ResetLevels()
    {
        nivelesCompletados = 0;
        SaveCurrentGame();
    }
    public void SeleccionNivel(GameObject nivelSelected)
    {
        LoadCurrentLevels();

        for (int i = 0; i <= (nivelesCompletados); i++)
        {
            if (nivelSelected == totalNiveles[i])
            {
                if (panelMisionInfo != null)
                {
                    InfoMisionHUDCity cmpHUDmisioninfo = panelMisionInfo.GetComponent<InfoMisionHUDCity>();
                    //string textDescript = GetComponent<TextosCiudad>().text_misionDescripcion[i];

                    Color panelColor=Color.white;
                    if (i < nivelesCompletados)
                    {
                        panelColor = Color.green;
                    }
                    cmpHUDmisioninfo.SetCurrentMissionInfo(i, text_misionDescripcion[i], panelColor);
                        panelMisionInfo.SetActive(true);
                }
                nivelJuegoScene = i + 1; //Se suma 1 para igualar a la posicion de las escenas en BuildSetting. Los niveles estan situados a partir de la escena inicial de menú.
            }
        }
    }

    public void GoLevel()
    {
        FindObjectOfType<LoadAsync>().LevelLoader(nivelJuegoScene);
    }


    public void UnlockNextLevel()
    {
        nivelesCompletados++;
        SaveCurrentGame();
    }
    void SaveCurrentGame()
    {
        PlayerPrefs.SetInt("NivelesCompletados", nivelesCompletados);
    }
    void LoadCurrentLevels()
    {
        nivelesCompletados = PlayerPrefs.GetInt("NivelesCompletados");
    }

    /* void SetearParticleEffectCiudad(int modelType, int currentNivel)
    {
        Instantiate(modelsParticleFeedback[1], totalNiveles[i].transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
    }*/
}

/*public static class TextosCiudad
{
    [SerializeField] [TextArea] public static string[] text_misionDescripcion;
}*/