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

    //private bool mePlayer;

    private void Start()
    {
        if (MePlayer())
        {
         //Calls showhearts funtion to display health bar if player exists
            ShowHearts();
            scoreBoard = FindObjectOfType<ScoreBoard>().gameObject;
        }
    }

    public void IncrementHealth(int value)
    {
        health += value;
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosionEffects, transform.position, Quaternion.identity);
            if (!MePlayer())
                IncrementScore();
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
    private void IncrementScore()
    {
        //find scoreKeeper object
       //scoreboard.text = int.Parse(scoreboard.text) + 10;
     }


}
