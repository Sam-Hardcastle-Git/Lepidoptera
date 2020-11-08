using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorAtRandom : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        // Pick a random, saturated and not-too-dark color
        GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
