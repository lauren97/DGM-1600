using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 
{

    public void OpenLevel(string lvl)
    {
        SceneManager.LoadScene(lvl);
    }
    public void QuitGame()
    {
        print("Exit?");
        Application.Quit();
    }
}
