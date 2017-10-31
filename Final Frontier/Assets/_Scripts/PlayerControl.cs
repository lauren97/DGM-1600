using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {
	//Instructions
	//Add to Ship
	//Move Ship with arrow keys

	//Make speed adjustable in inspector
	public float speed = 1;

	// Use this for initialization

	void Start () 
	{
		//add
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Move Ship with Arrow Keys
		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			//move player Up
			print ("Up");
		}
		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			//move player Down
			print ("Down");
		}
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			//move player Left
			print ("Left");
		}
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			//move player Right
			print ("Right");
		}

		
	}
}
