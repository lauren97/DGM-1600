using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

    // Use this for initialization
    public float startSpin;    
    //public Health metHealth;

    public MeteorHealth metHealth;
   
    //Random Generation of Meteors
    public Health playerHealth;
    public GameObject meteor;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    void Start ()
    {
        GetComponent<Rigidbody2D>().AddTorque(Random.Range(-startSpin,startSpin),ForceMode2D.Impulse);
        //call the Spawn Function
        //InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D collider)
    {
        metHealth.IncrementHealth(-1);
        collider.gameObject.GetComponent<Health>().IncrementHealth(-1);
	}
    /*void Spawn()
    {
        if (playerHealth.health >= 0)
            return;
        //find random index between 0 and 1 less than the number of spawnpoints
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        //create an instance of the metepr prefab at the randomly selected spawn point's position and rotation
        Instantiate(meteor, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }*/
    


    
}
