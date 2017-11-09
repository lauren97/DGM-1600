using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

    // Use this for initialization
    public float startSpin;
    public int health = 5;
	void Start ()
    {
        GetComponent<Rigidbody2D>().AddTorque(Random.Range(-startSpin,startSpin),ForceMode2D.Impulse);	
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D collider)
    {
        health--;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
