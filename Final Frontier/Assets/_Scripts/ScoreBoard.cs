using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    // Use this for initialization
    //variables
    public int score;
    public Text display;
    //public Text highscoreDisplay;
    //public Text prevScoreDisplay;
    void Start ()
    {        
        if (display != null)        
            display.text = score.ToString();        
        /*if (highscoreDisplay != null)
            display.text = GetScore().ToString();
        if (prevScoreDisplay != null)
            display.text = PlayerPrefs.GetInt("PrevScore", score);*/
    }
    public void IncrementScoreboard(int value)
    {
        score += value;                
    }
    public void SaveScore()
    {
        //check previous score
        int oldScore =GetScore();
        //if newScore is greater than previousScore
        if(score > oldScore)
            PlayerPrefs.SetInt("PrevScore", score);
    }
    public int GetScore()
    {
        return PlayerPrefs.GetInt("Highscore");
    }
    public void OnDisable()
    {
        SaveScore();
    }

}
