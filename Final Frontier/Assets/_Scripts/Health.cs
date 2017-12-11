using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public GameObject explosionEffects;
    public int health;
    public GameObject[] hearts;      
    public GameObject scoreBoard;
    public ScoreBoard scoreScript;
    //public int score;
    private bool mePlayer;

    private void Start()
    {
        //if mePLayer() it tests if the Player is the object
        if (MePlayer())
        {
         //Calls showhearts funtion to display health bar if player exists
            ShowHearts();
            scoreBoard = FindObjectOfType<ScoreBoard>().gameObject;
        }
    }
    //increases health
    public void IncrementHealth(int value)
    {
        health += value;
        //Destroys the meteor or player once health is equal or less than 0
        if (health <= 0)
        {   Destroy(gameObject);  
            Instantiate(explosionEffects, transform.position, Quaternion.identity);
            if (MePlayer() == false)
                scoreScript.IncrementScoreboard(10);           
        }
        ShowHearts();
    }
    public void ShowHearts()
    {
        //Turn all hearts off
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(false);
        }
        //turn hearts on by health
        for (int i = 0; i < health; i++)
        {
            hearts[i].SetActive(true);
        }

    }
    private bool MePlayer()
    {
        if (GetComponent<PlayerControl>())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
   


}
