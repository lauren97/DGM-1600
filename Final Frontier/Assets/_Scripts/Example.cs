using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AdderUpper(100,25);
	}
    public void AdderUpper(int value1, int value2)
    {
        print(value1 + value2);
    }
}
