using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public float lifetime, speedL;
    public int damage;
   
    
    // Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(this.gameObject);
        }


        transform.Translate(Vector3.up * speedL * Time.deltaTime);
    }
        void OnTriggerEnter2D(Collider2D other)            
        {
            other.GetComponent<Health>().IncrementHealth(damage);
            Destroy (gameObject);
        }
        
	
}
