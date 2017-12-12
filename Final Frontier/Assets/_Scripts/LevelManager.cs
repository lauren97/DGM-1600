using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public static int brickCount;
    public float timeleft = 30f;
    public Health playerHealth;
    public PlayerControl player;
    
	public void Start()
	{	

	}

	public void OpenLevel(string lvl)
    {
        SceneManager.LoadScene(lvl);
    }
    public void QuitGame()
    {
        print("Exit?");
        Application.Quit();
    }
	public void LoadNextLevel()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}
    public void Update()
    {
           

    }
}
