using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    #region variables
    //Enemy health
    public int PCHealth = 1000;

    //Poof Sound
    public AudioClip poof;

    //ScoreHealthLives
    private ScoreHealthLivesCounter scorehealthlivescounter;
    #endregion variables

    void Start()
    {
        //get ScoreHealthLivesCounter from ScoreHealthLives
        scorehealthlivescounter = GameObject.Find("ScoreHealthLives").GetComponent<ScoreHealthLivesCounter>();       
    }

    // On trigger function
    void OnTriggerEnter2D(Collider2D col)
    {
        #region get beam reference

        //create a variable of type DamageThePlayerButterfly called beam, this represents the collided object (which will be the beams the enemy butterfly shoots)
        DamageThePlayerButterfly beam = col.gameObject.GetComponent<DamageThePlayerButterfly>();

        #endregion get beam reference

//        if(col.tag == "Enemy")
//        {
//            PCHealth = 0;
//            print("don'tTouchMEEEE");
//        }

        #region if the beam exists...

        if (beam)
        {
            #region reduce health and destroy beam
            //reduce health by the amount specified in GetDamage
            PCHealth -= beam.GetDamage();

            //pass the new health value to the ScoreHealthLivesCounter
            scorehealthlivescounter.alterHealth(PCHealth);

            //destroy beam
            beam.Hit();

            #endregion

            #region if health is below zero...
            //out of health?
            if (PCHealth <= 0)
            {
                #region play sound and die
                //play sound
                AudioSource.PlayClipAtPoint(poof, transform.position);

                //die
                Destroy(gameObject);

                #endregion
            }

            #endregion 
        }

        #endregion
    }        
}
