using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public Transform objectToFollow;
    public float zOffset;
    // Use this for initialization

    
	void Update ()
    {
        //create temp vector3 to adjust z pos, and gameobject pos

        Vector3 myPos = (gameObject.transform.position);
        //adjust z position
        myPos.z = zOffset;

        //adjust gameObject position.
        gameObject.transform.position = myPos;
        
	}
}
