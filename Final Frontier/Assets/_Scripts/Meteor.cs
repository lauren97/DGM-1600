using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

    // Use this for initialization
    public float startSpin;    
    public Health metHealth;
	void Start ()
    {
        GetComponent<Rigidbody2D>().AddTorque(Random.Range(-startSpin,startSpin),ForceMode2D.Impulse);	
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D collider)
    {
        metHealth.IncrementHealth(-1);
        collider.gameObject.GetComponent<Health>().IncrementHealth(-1);
	}
    


    
}
