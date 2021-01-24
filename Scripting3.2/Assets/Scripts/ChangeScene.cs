using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    public string nextScene;
    [SerializeField] int sceneToGo = 0;
    public void ChangeScenes()
    {
        //SceneManager.LoadScene("nextScene");
        SceneManager.LoadScene(nextScene);
    }
    public void MainMenu()
    {
        GameObject.FindObjectOfType<LoadAsync>().LevelLoader(sceneToGo);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ResetGame()
    {
        PlayerPrefs.SetInt("NivelesCompletados", 0);
    }
}
