using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScenas : MonoBehaviour
{
    public string nextScene;
    public int IndexScene;

    [SerializeField] GameObject loadingPanel;

    private void Start()
    {
        loadingPanel.SetActive(false);

    }
    public void ChangeScene()
    {
        loadingPanel.SetActive(true);
      
       SceneManager.LoadScene(nextScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoPlay()
    {
        GetComponent<LoadAsync>().LevelLoader(IndexScene);
    }

}
