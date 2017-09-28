using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chapter01 : MonoBehaviour {

    public Text textObject;
//state machine
    public enum States {start, start_n, door01, bed, window, hallway, right, left, drinkPotion, GameOver, hide, fight, twoDoors, wood, steel};
    public States myState;
    public bool needle = false, needleUsed = false, oldPotion = false, keys = false;
    public int gems = 0;
    public string message;

// Use this for initialization
	void Start ()
    {
        //textObject.text = "Play Game";
        myState = States.start;

	}
// Update is called once per frame
	void Update ()
    {
        if (myState == States.start) { State_start(); }
        else if (myState == States.door01) { State_door_01(); }
        else if (myState == States.bed) { State_bed(); }
        else if (myState == States.window) { State_window(); }
        else if (myState == States.start_n) { State_start_n(); }
        else if (myState == States.hallway) { State_hallway(); }
        else if (myState == States.left) { State_left(); }
        else if (myState == States.drinkPotion) { State_drinkPotion(); }
        else if (myState == States.right) { State_right(); }
        else if (myState == States.hide) { State_hide(); }
        else if (myState == States.fight) { State_fight(); }
        else if (myState == States.wood) { State_wood(); }
        else if (myState == States.steel) { State_steel(); }
        //when death occurs
        else if (myState == States.GameOver) { State_GameOver(); }
        
    }
//In Cell
    void State_start()
    {
        //This is the main start of the game.
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
    void State_door_01()
    {
        if (needle == false)
        {
            textObject.text = "The door is locked." +
                  "\nBack (B)";
            if (Input.GetKeyDown(KeyCode.B))
            {
                myState = States.start;
            }
        }
        else if (needle == true && needleUsed == false)
        {
            textObject.text = "The door is locked, but you could probably pick the lock with the needle." +
                "\nUse sewing needle? (U)";
            if (Input.GetKeyDown(KeyCode.U))
            {
                myState = States.hallway;
                needleUsed = true;
            }

        }
        else if (needleUsed == true)
        {

            myState = States.hallway;
        }            
        
    }
    void State_bed()
    {
        textObject.text = "The most uncomfortale bed in existence." +
            "\n Look Under the Bed?" +
            "\nYes (Y) " +
            "\nNo (N)";
        if (Input.GetKeyDown(KeyCode.Y))
        {
            needle = true;
            myState = States.start_n;
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            myState = States.start;
        }
    }
    void State_window()
    {
        textObject.text = "It's dark outside." +
            "You won't fit through this window." +
            "\nGo Back (B)";
        if (Input.GetKeyDown(KeyCode.B) && needle == false)
        {
            myState = States.start;
        }
       else if (Input.GetKeyDown(KeyCode.B) && needle == true)
        {
            myState = States.start_n;
        }
    }
    void State_start_n()
    {
        //Examining the bed is no longer neccessary.
        if (needleUsed == false)
        { 
            textObject.text = "Got an Old Needle." +
                "\nYou see:" +
                "\nThe Door(D)" +
                "\nA Window(W)";
        }
        else if (needleUsed == true)
        {
            textObject.text = "The cell you woke up in." +
                "\nThe Door(D)" +
                "\nA Window(W)";
        }
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

    }
//Corridors
    void State_hallway()
    {
        if (oldPotion == false)
        {
            textObject.text = "You make your way down the hall and come to a split." +
              "You can go:" +
              "\nRight (R)\nLeft (L)\nGo Back (B)";
            if (Input.GetKeyDown(KeyCode.R))
            {
                myState = States.right;
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                myState = States.left;
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                myState = States.start_n;
            }
        }
        else if (oldPotion == true)
        {
            textObject.text = "Which way now?" +
             "You can go:\nRight (R)\nGo Back (B)";
            if (Input.GetKeyDown(KeyCode.R))
            {
                myState = States.right;
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                myState = States.start_n;
            }
        }
    }
    void State_left()
    {
        textObject.text = "You walk down the hall only to find a dead end." +
            "\n You notice an open crate." +
            "\n Look inside?" +
            "\n" +
            "\nYes(Y)\nNo(N)";
        if (Input.GetKeyDown(KeyCode.Y))
        {
            oldPotion = true;
            myState = States.drinkPotion;
        }
    }
    void State_drinkPotion()
    {
        textObject.text = "Drink Potion?" +
            "\n Drink(D)\nBetter not(N)";
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Death by Acid
            myState = States.GameOver;
            message = "Turns out that potion was acid...\n You've died.";
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            //Death by Acid
            myState = States.hallway;            
        }
    }
    void State_right()
    {
        textObject.text = "You walk down the corridor as quietly as you can. It smells terrible down here." +
            "\nYou hear voices approaching. They might be guards!" +
            "\n" +
            "\nHide(H)\nFight(F)";
        if (Input.GetKeyDown(KeyCode.H))
        {
            myState = States.hide;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            myState = States.fight;
        }
    }
    void State_hide()
    {
        textObject.text = "Better safe than sorry. You hide inside an unoccupied cell." +
            "\n Two guards walk passed your hiding place, unaware of youre prescecnce." +
            "\n You see a set of keys on one of the gurads belt." +
            "\n" +
            "\nSteal the Keys (K)\nDon't steal the Keys(D).";
        if (Input.GetKeyDown(KeyCode.K))
        {
            keys = true;
            myState = States.twoDoors;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            myState = States.twoDoors;
        }
    }
    void State_fight()
    {
        message = "I fear nothing! You bravely leapt into battle. But you didn't have a weapon." +
                "\nYou are easily slain by the guards.";
        myState = States.GameOver;               
    }
//Two Doors
    void State_TwoDoors()
    {
        if (keys == true)
        {
            textObject.text = "You steal the kesy from the guard. You come accross two doors. One made of Wood and one made of Steel." +
                "Which one do you choose?" +
                "\nWood (W)" +
                "\nSteel (S)";
            if (Input.GetKeyDown(KeyCode.W)) { myState = States.wood; }
            else if (Input.GetKeyDown(KeyCode.S)){ myState = States.steel; }
        }
        else if (keys == false)
        {
            textObject.text = "You come accross two doors. One made of Wood and one made of Steel." +
                "Which one do you choose?" +
                "\nWood (W)" +
                "\nSteel (S)";
            if (Input.GetKeyDown(KeyCode.W)) { myState = States.wood; }
            else if (Input.GetKeyDown(KeyCode.S)){ myState = States.steel; }
        }
    }
    void State_steel()
    {
        textObject.text = "test";
    }
    void State_wood()
    {
        textObject.text = "test";
    }
    //Basic Gameplay
    void State_GameOver()
    {
        //The user has died and the game will need to restart.
        textObject.text = "Game Over\n" + message;
    }
}
