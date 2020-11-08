using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    #region declare variables

    #region health, speed, movingleft bool and shots per second
    //Enemy health
    public float health = 3;    

    //Parent bool
    public bool movingLeft;


    #endregion health, speed, movingleft bool and shots per second

    #region Audio
    //audioClips
    public AudioClip poof;

    #endregion Audio

    #region ScoreValue and ScoreHealthLivesCounter
    //score
    public int scoreValue = 150;

    //scoreCounter
    private ScoreHealthLivesCounter myScoreCounter;

    #endregion ScoreValue and ScoreHealthLivesCounter

    #region particle gameObject
    public GameObject particles;
    #endregion particle gameObject

    #region kill timer
    public float killTimer = 0.1f;

    #endregion kill timer

    #endregion declare variables

    #region functions

    #region Start and Update functions

    // Use this for initialization
    void Start ()
    {
        #region get score counter
        //get ScoreHealthLivesCounter from ScoreHealthLives
        myScoreCounter = GameObject.Find("ScoreHealthLives").GetComponent<ScoreHealthLivesCounter>();

        #endregion get score counter
    }

    void Update()
    {
        #region out of health
        //out of health?
        if (health <= 0)
        {
            killTimer -= 1 * Time.deltaTime;
            

            #region kill when timer hits zero
            if (killTimer <= 0)
            {
                //play sound
                AudioSource.PlayClipAtPoint(poof, transform.position);

                //die
                Destroy(gameObject);

                //send points to scoreCounter
                myScoreCounter.increaseScore(scoreValue);

                //create particles
                Instantiate(particles, transform.position, Quaternion.identity);
            }
            #endregion kill when timer hits zero
        }
        #endregion out of health
    }

    #endregion Start and Update functions

    #region custom functions

    void OnTriggerEnter2D(Collider2D col)
    {
        #region get beam reference
        //create a variable of type Damage called beam, this represents the collided object (which will be the beams the butterfly shoots)
        Damage beamCol = col.gameObject.GetComponent<Damage>();

        #endregion get beam reference

        #region if the beam exist
        //if the beam exists
        if (beamCol)
        {
            //reduce health by the amount specified in GetDamage
            health -= beamCol.GetDamage();

            //destroy beam
            beamCol.Hit();            
        }
        #endregion if the beam exist
    }

    #endregion custom functions

    #endregion functions

}
