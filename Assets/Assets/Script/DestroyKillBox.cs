﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyKillBox : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(transform.parent.childCount == 1)
        {
            print("destroy");
            Destroy(gameObject);
        }
	}
}
