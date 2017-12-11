using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorHealth : MonoBehaviour {

    public int meteorHealth = 1;
    public GameObject explosionEffects;

    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void IncrementHealth(int value)
    {
        if (meteorHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosionEffects, transform.position, Quaternion.identity);
        }    
        
        meteorHealth += value;
        
    }
            
}
