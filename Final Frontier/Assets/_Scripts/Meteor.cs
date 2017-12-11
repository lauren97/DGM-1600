using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

    // Use this for initialization
    public float startSpin;    
    public Health metHealth;
   
    //Random Generation of Meteors
    public Health playerHealth;
    public GameObject meteor;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    void Start ()
    {
        GetComponent<Rigidbody2D>().AddTorque(Random.Range(-startSpin,startSpin),ForceMode2D.Impulse);       
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D collider)
    {
        //Decreases health of the meteors
        metHealth.IncrementHealth(-1);
        //decreases players health
        collider.gameObject.GetComponent<Health>().IncrementHealth(-1); 
	}
    
    


    
}
