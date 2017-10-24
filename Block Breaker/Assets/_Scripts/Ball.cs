using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public GameObject paddle;
	private bool launched = false;
	private Rigidbody2D rigid;

	private Vector3 paddleToBallVector; //distance from ball to paddle
	// Use this for initialization

	void Start () 
	{
		//Set the position
		paddleToBallVector =this.transform.position - paddle.transform.position;
		this.rigid = this.GetComponent<Rigidbody2D>();		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!launched)
		{
			//ball's position stays constantly on the paddle until game has started
			this.transform.position = paddle.transform.position + paddleToBallVector;	
		}

		//if push start button
		if(Input.GetMouseButtonDown(0))
		{
			//ball goes flying
			rigid.velocity = new Vector2(4,20);
			//launched = true
			launched = true;

		}

	}
}
