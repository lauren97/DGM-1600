using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chapter01 : MonoBehaviour {

    public Text textObject;
    //state machine
    public enum States {start, dead, door01, bed, window};
    public States myState;

	// Use this for initialization
	void Start ()
    {
        //textObject.text = "Play Game";
        myState = States.start;

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (myState == States.start) {State_start();}
        else if (myState == States.door01) {State_door_01();}
        else if (myState == States.bed) { State_bed(); }
        else if (myState == States.window) { State_window();}
    }
    void State_start()
    {
        textObject.text = "You wake up to find yourself in a cell." +
            "\nYou don't know where you are or even who you are." +
            "\nYou see:" +
            "\nThe Door(D)" +
            "\nA Window(W)" +
            "\nThe Bed (B)";
        //Door_01
        if (Input.GetKeyDown(KeyCode.D))
        {
            myState = States.door01;
        }
        //Window
        else if (Input.GetKeyDown(KeyCode.W))
        {
            myState = States.window;
        }
        //Bed
        else if (Input.GetKeyDown(KeyCode.B))
        {
            myState = States.bed;
        }

    }
    void State_dead()
    {

    }
    void State_door_01()
    {
        textObject.text = "The door is locked.";
    }
    void State_bed()
    {
        textObject.text = "The most uncomfortale bed in existence.";
    }
    void State_window()
    {
        textObject.text = "It's Dark Outside.";
    }
}
