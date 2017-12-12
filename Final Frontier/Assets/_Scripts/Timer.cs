using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    // Use this for initialization
    public float timeleft = 30f;
    public Text timer;
    private bool isPlayerDead;
    
    public LevelManager level;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeleft -= Time.deltaTime;
        timer.text = ("Timer: " + timeleft);
        if (timeleft <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            isPlayerDead = false;
        }
        else
        {
            isPlayerDead = true;
            PlayerDead();
        }
    }
    void PlayerDead()
    {
        level.OpenLevel("GameOver");
    }    
}
