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
        //when player dies, end game
        
         
    }
}
