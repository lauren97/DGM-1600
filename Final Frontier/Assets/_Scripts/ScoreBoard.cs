using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    // Use this for initialization
    //variables
    public int score = 0;
    public Text display;
    public LevelManager level;
    //public Text highscoreDisplay;
    //public Text prevScoreDisplay;
    void Start ()
    {        
        if (display != null)        
            display.text = ("Score: " + score.ToString());        
    }
    public void IncrementScoreboard()
    {           
            score = score + 10;
            SetScoreText();
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
    public void SetScoreText()
    {
        display.text = ("Score: " + score.ToString());
    }

}
