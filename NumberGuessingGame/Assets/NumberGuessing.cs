﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberGuessing : MonoBehaviour {

	public Text theGuesser;
	//variables
	private int maxValue = 100, minValue = 1, guess = 50; 
	public int count;

	// Use this for initialization
	void Start ()
	{
		int guess = Random.Range(minValue, maxValue);

		theGuesser.text = "\nWelcome! I am The Guesser. "
			+ "\nChoose a number and keep it secret. I will being guessing soon. "
			+ "\n\nThe highest number you can pick is " + maxValue
			+ "\nThe lowest number you can pick is " + minValue
			+"\nUp arrow for Higher, Down Arrow for Lower, and Enter/Return for equal."
			+"\n\nIs the number lower or higher than " + guess;
		
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
			theGuesser.text = "You win!";				
		}
		//Higher, lower, or equal
		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			minValue = guess;
			guess = (maxValue + minValue) / 2;
			count--;
			theGuesser.text = "Is the number higher or lower than:\n" + guess;
		} 

		else if (Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			maxValue = guess;
			guess = (maxValue + minValue) / 2;
			count--;
			theGuesser.text = "Is the number higher or lower than:\n" + guess;
		}

		else if (Input.GetKeyDown (KeyCode.Return)) 
		{
			theGuesser.text = "Your number is:\n" + guess
					+ "I win!";
		}

		if (count == 0) 
		{
			count--;
		}


			
		
		//when counter reaches zero and the number has not been guessed, players wins
	}
}
