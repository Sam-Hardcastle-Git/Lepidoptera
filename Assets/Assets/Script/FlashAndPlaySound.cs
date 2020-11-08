using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashAndPlaySound : MonoBehaviour
{
    #region variables
    //audioClip
    public AudioClip hurt;

    //colorTimer
    public float timer = 0.1f;

    //SpriteRenderers in parents and children
    public SpriteRenderer[] spriteRendererArray;


    #endregion variables

    void Start()
    {
        spriteRendererArray = this.GetComponentsInChildren<SpriteRenderer>();
    }

	// Update is called once per frame
	void Update ()
    {
        if (this.GetComponent<SpriteRenderer>().color == Color.red)
        {
            countDown();
        }

        if (timer <= 0)
        {
            foreach (SpriteRenderer spriteRenderer in spriteRendererArray)
            {                       
                spriteRenderer.color = Color.white;

                timer = 0.1f;
            }
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "Beam")
        {
            //PlayClip
            AudioSource.PlayClipAtPoint(hurt, transform.position);

            foreach (SpriteRenderer spriteRenderer in spriteRendererArray)
            {
                //change colour to red
                spriteRenderer.color = Color.red;               
            }
        }              
    }

    void countDown()
    {
        //start timer
        timer -= 1 * Time.deltaTime;
    }
}
