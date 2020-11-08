using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticles : MonoBehaviour
{
    public float timer = 0;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += 1 * Time.deltaTime;

        if (timer >= 1)
        {
            Destroy(gameObject);
                
        }
    }
}
