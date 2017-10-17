using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	public int health = 5;
	void OnCollisionEnter2D (Collision2D collider)
	{
		health--;

		if (health <= 0) {
			Destroy (this.gameObject);
		}
	}
}
