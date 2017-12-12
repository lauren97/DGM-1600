using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCoin : MonoBehaviour {

    // Use this for initialization
    public ScoreBoard coinCollected;
    public int score;
    void Start ()
    {

	}
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.GetComponent<PlayerControl>())
        {
            coinCollected.IncrementScoreboard();
            Destroy(gameObject);
        }
    }

}
