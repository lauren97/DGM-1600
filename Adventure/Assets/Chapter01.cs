using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chapter01 : MonoBehaviour {

    public Text textObject;
//state machine
    public enum States {start, start_n, door01, bed, window, hallway, right, left, drinkPotion, GameOver, hide, fight, twoDoors, wood, steel, arena, sword, door02, toBeContinued, slayLion, escapeDoor, ending};
    public States myState;
    public bool needle = false, needleUsed = false, oldPotion = false, keys = false, sword = false;
    public int count = 0;
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
        //In Cell
        if (myState == States.start) { State_start(); }
        else if (myState == States.door01) { State_door_01(); }
        else if (myState == States.bed) { State_bed(); }
        else if (myState == States.window) { State_window(); }
        else if (myState == States.start_n) { State_start_n(); }
        //Corridors
        else if (myState == States.hallway) { State_hallway(); }
        else if (myState == States.left) { State_left(); }
        else if (myState == States.drinkPotion) { State_drinkPotion(); }
        else if (myState == States.right) { State_right(); }
        else if (myState == States.hide) { State_hide(); }
        else if (myState == States.fight) { State_fight(); }
        //Two Doors
        else if (myState == States.wood) { State_wood(); }
        else if (myState == States.steel) { State_steel(); }
        else if (myState == States.twoDoors) { State_TwoDoors(); }
        //Arena
        else if (myState == States.arena) { State_arena(); }
        else if (myState == States.sword) { State_sword(); }
        else if (myState == States.door02) { State_door02(); }
        else if (myState == States.slayLion) { State_slayLion(); }
        else if (myState == States.escapeDoor) { State_escapeDoor(); }
        //gameplay elements
        else if (myState == States.GameOver) { State_GameOver(); }
        else if (myState == States.toBeContinued) { State_toBeContinued(); }
        else if (myState == States.ending) { State_ending(); }
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
        textObject.text = "You steal the kesy from the guard. You come accross two doors. One made of Wood and one made of Steel." +
            "Which one do you choose?" +
            "\nWood (W)" +
            "\nSteel (S)";
        if (Input.GetKeyDown(KeyCode.W)) { myState = States.wood; }
        else if (Input.GetKeyDown(KeyCode.S)){ myState = States.steel; }             
    }
    void State_wood()
    {
        if (keys == true)
        {
            textObject.text = "The door won't move. Its locked." +
                "\nUse Keys(K)";
            if (Input.GetKeyDown(KeyCode.K)) {myState = States.ending; }
        }
        else if (keys == false)
        {
            textObject.text = "The door won't move. Its locked." +
                "\nGo Back(B)";
            myState = States.twoDoors;
        }
    }
    void State_steel()
    {
        textObject.text = "Open the Steel door?" +
            "\nYes (Y)" +
            "\nNo (N)";
        if (Input.GetKeyDown(KeyCode.Y))
            { myState = States.arena; }

    }
//Arena
    void State_arena()
    {
        textObject.text = "You unlock the door. You run outside, relieved to be free of the horrible smelling dungeons." +
            "You suddenly hear loud screams and cheers as you run out onto a sandy field." +
            "You're in an arena. You turn back only to find the door closed and locked behind you." +
            "\n\nYou need to hurry. You see:" +
            "\nA Door on the far side of the arena. (D)" +
            "\nA Sword between two rocks. (S)" +
            "\nA Gate that's being opened (G)";
        if (Input.GetKeyDown(KeyCode.D))
        {
            myState = States.door02; 
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.sword;
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            message = "You run to the gate as fast as you can. Once you reach it you dive inside. You get up and start to run down the narrow tunnel." +
                "You slam into something huge and furry. You take a step back, seeing the Lion's huge teeth before you're eaten.";
            myState = States.GameOver;
        }
    }
    void State_sword()
    {
        if (oldPotion == true)
        {
            textObject.text = "You run towards the sword, pulling on it, you realize it's stuck." +
                "\nUse Potion. (P)" +
                "\nRun for the door.(R)";
            if (Input.GetKeyDown(KeyCode.P))
            {
                sword = true;
                myState = States.door02;
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                myState = States.door02;
            }
        }
        else if (oldPotion == false)
        {
            textObject.text = "You run towards the sword, pulling on it, you realize it's stuck." +
                "\nRun for the door.(R)";
        }
    }
    void State_door02()
    {
        if (sword == true)
        {
            textObject.text = "The potion disolves the rocks, but don't harm the sword." +
                "After freeing the sword you run towards the door, running as fast as you can. You hear a roar behind you! " +
                    "Looking over your shoulder you see a massive Lion. It looks hungry and it's gaining!"+
                    "\n\nFight the Lion (F)" +
                    "\n\nRun (R)";
            if (Input.GetKeyDown(KeyCode.F))
            {
                myState = States.slayLion;
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                message = "You almost make it to the door. The lion pounces just as you reach for the handle.";
                myState = States.GameOver;
            }
        }
        else if (sword == false)
        {
            textObject.text = "You run towards the door, running as fast as you can. You hear a roar behind you! " +
                    "Looking over your shoulder you see a massive Lion. It looks hungry and it's gaining!" +
                    "\n\nRun (R)";
            if (Input.GetKeyDown(KeyCode.R))
            {
                message = "You almost make it to the door. The lion pounces just as you reach for the handle.";
                myState = States.GameOver;
            }
        }
    }
    void State_slayLion()
    {
        textObject.text = "You turn around, holding the sword out in front of you as the lion pounces." +
            "The impact knocks you to the ground, but you're unharmed." +
            "You get up and start to run back to the door." +
            "\n\nOpen door (O)";
        if (Input.GetKeyDown(KeyCode.O)) { myState = States.escapeDoor; }
    }
    void State_escapeDoor()
    {
    textObject.text = "You run out of the arena, angry cries following you as you squeeze between the bars of a gate." +
            "You run faster, escaping and running to freedom.";
        count++;
        if (count == 200) { myState = States.toBeContinued; }
    }
    //Basic Gameplay
    void State_GameOver()
    {
        //The user has died and the game will need to restart.
        textObject.text = "Game Over\n\n" + message;
    }
    void State_toBeContinued()
    {
        textObject.text = "To Be Continued...";
    }
    void State_ending()
    {
        textObject.text = "You open the door and run up a flight of stairs. A few seconds later you find yourself outside, seeing an arena nearby." +
           "You hear cheers, meaning there must be an event. You run the oposite way, escaping without being seen.";
        count++;
        if (count == 200)
        {
            myState = States.toBeContinued;
        }
    }
}
