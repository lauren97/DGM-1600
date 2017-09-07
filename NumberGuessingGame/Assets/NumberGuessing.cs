using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberGuessing : MonoBehaviour {
	//variables
	private int maxValue = 100, minValue = 1, guess = 50; 
	public int count;

	// Use this for initialization
	void Start ()
	{
		int guess = Random.Range(minValue, maxValue);
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
	void Update () 
	{
		//You Win Statement
		if (count == -1) 
		{
			if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.DownArrow)) 
			{
				print ("You win!");
			}		
		}
		//Higher, lower, or equal
		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			minValue = guess;
			guess = (maxValue + minValue) / 2;
			count--;
			print ("Is the number higher or lower than: " + guess);
		} 

		else if (Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			maxValue = guess;
			guess = (maxValue + minValue) / 2;
			count--;
			print ("Is the number higher or lower than: " + guess);
		}

		else if (Input.GetKeyDown (KeyCode.Return)) 
		{
			print ("Your number is: " + guess);
		}
		//no more guesses
		if (count == 0) 
		{
			count--;
		}
			
		
		//when counter reaches zero and the number has not been guessed, players wins
	}
}
