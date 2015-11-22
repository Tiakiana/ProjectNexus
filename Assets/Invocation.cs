using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Invocation : MonoBehaviour {

    // Use this for initialization
    void Start() {

        gogo();
    }

    void st() {

        GameObject ngo = new GameObject();

        

    }

    void gogo() {
        Invoke("st", 2);
        
    }

    

	// Update is called once per frame
	void Update () {
	
	}
}
