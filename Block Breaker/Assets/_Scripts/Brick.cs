using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	public int health = 5;
	public Sprite[] state;
	private int count = 0;
	void OnCollisionEnter2D (Collision2D collider)
	{
		health--;
		count++;

		//change the picture

		if (health <= 0) {
			Destroy (this.gameObject);
		}
		GetComponent<SpriteRenderer>().sprite = state[count];}
}
