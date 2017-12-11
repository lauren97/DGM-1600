using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {
    //Instructions
    //Add to Ship
    //Move Ship with arrow keys

    //Make speed adjustable in inspector
    public float speed = 0.1f;    
    //laser variables
    public GameObject projectile;
    public Transform shotPos;
    public float shotForce;
    public ParticleSystem particle;
    public Sprite[] ships;
    
	void Start () 
	{
       
    }
	
	// Update is called once per frame
	void Update () 
	{         
		//Move Ship with Arrow Keys
		if (Input.GetKey (KeyCode.W)) 
		{
			//move player Up
			//print ("Up");
            transform.Translate(0, speed, 0);
            //get thrusters to activate
            
		}
		if (Input.GetKey (KeyCode.S)) 
		{
			//move player Down
			//print ("Down");
            transform.Translate(0, speed * -1, 0);
        }
		if (Input.GetKey (KeyCode.A)) 
		{
			//move player Left
			//print ("Left");
            transform.Translate(speed * -1, 0, 0);
        }
		if (Input.GetKey (KeyCode.D)) 
		{
			//move player Right
			//print ("Right");
            transform.Translate(speed, 0, 0);
        }
        //fire laser
        if (Input.GetButtonUp("Fire1"))
        {
            GameObject shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as GameObject;
            shot.GetComponent<Rigidbody2D>().AddForce(shotPos.up * shotForce);
            //shot.AddForce(shotPos.forward * shotForce);
        }
        		
	}
   


}
