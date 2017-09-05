using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberGuessing : MonoBehaviour {
	//variables
	int maxValue = 100, minValue = 1, guess = 50, temp;

	// Use this for initialization
	void Start ()
	{
	//Script
		print ("Welcome to The Number Guesser!");
		print ("Choose a number and keep it secret. I will begin guessing soon.");

		print ("The highest number you can pick is: " + maxValue);
		print ("The lowest number you can pick is: " + minValue);

		print ("Is the number higher or lower than: " + guess);
		print ("Up arrow for higher, Down for lower, Enter for Equal");

		maxValue= maxValue +1;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			minValue = guess;
			guess = (maxValue + minValue) / 2;
			print ("Is the number higher or lower than: " + guess);
		} 

		if (Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			maxValue = guess;
			guess = (maxValue + minValue) / 2;
			print ("Is the number higher or lower than: " + guess);
		}

		if (Input.GetKeyDown (KeyCode.Return)) 
		{
			print ("Your number is: " + guess);
		}
	}
}
