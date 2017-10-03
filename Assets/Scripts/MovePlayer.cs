﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.LeftArrow))  //if you want to check whether a key has been released, use GetKeyDown instead
	    {
	        gameObject.transform.Translate(Vector3.left*0.1f); //o.1m to the left
	    }
	    if (Input.GetKey(KeyCode.RightArrow))
	    {
	        gameObject.transform.Translate(Vector3.right * 0.1f);
	    }
	    if (Input.GetKey(KeyCode.UpArrow))
	    {
	        gameObject.transform.Translate(Vector3.up * 0.1f);
	    }
	    if (Input.GetKey(KeyCode.DownArrow))
	    {
	        gameObject.transform.Translate(Vector3.down * 0.1f);
	    }
    }
}
//CTRL+P to stop game scene