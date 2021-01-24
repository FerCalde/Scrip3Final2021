using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerLevelCompleted : MonoBehaviour
{
    [SerializeField] int nextScene = 0;
    [SerializeField] float puntuacionParaSuperarNivel = 100;
    
    public void CheckScore()
    {
        //LevelManager.Instance.UnlockNextLevel();
        FindObjectOfType<GameManager>().UnlockNextLevel();
        GetComponent<LoadAsync>().LevelLoader(0);
    }


}
