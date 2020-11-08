using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    #region variables
    
    #region script variables
    //text display script
    private ScoreHealthLivesCounter scoreHealthLivesCounter;

    //BeginTryAgain script
    private BeginTryAgain beginTryAgain;

    //player health script
    private PlayerHealth playerHealth;
    #endregion

    #region GameObject
    //playable character
    public GameObject butterflyPC;
    public GameObject newButterfly;
    #endregion

    #region Vector3
    //start point
    public Vector3 startPoint;
    #endregion

    #region bools
    //bools
    public bool PCisDestroyed = false;
    public bool timeTilRespawnActive = false;
    #endregion

    #region float
    //float
    public float timeTilRespawn = 1;
    public float timeTilPCisDestroyTurnsFalse = 0.1f;
    #endregion

    #region int
    //number of lives
    public int lives = 3;
    #endregion

    #region bulletManagerScript
    BulletManagerScript bulletManager;
    #endregion bulletManagerScript

    #endregion variables

    #region functions
    void Start()
    {
        #region find gameObject and scripts

        //get BulletManager Script
        #region find object of type bullet manager
        bulletManager = GameObject.FindObjectOfType<BulletManagerScript>();
        #endregion find object of type bullet manager

        //get ScoreHealthLivesCounter script
        scoreHealthLivesCounter = GameObject.FindObjectOfType<ScoreHealthLivesCounter>();

        //get beginTryAgain
        beginTryAgain = GameObject.FindObjectOfType<BeginTryAgain>();

        //get playerhealth
        playerHealth = GameObject.FindObjectOfType<PlayerHealth>();

        //get butterflyPC gameObject
        butterflyPC = GameObject.FindWithTag("Player");

        #endregion find gameObject and script
    }

    void Update()
    {
        #region reduce lives by one and set bool to true

        reduceLife();

        #endregion reduce lives by one and set bool to true

        #region create a new PC Butterfly

        createAnotherButterfly();

        #endregion create a new PC Butterfly

        #region game over when no lives left

        gameOver();

        #endregion game over when no lives left
    }

    void reduceLife()
    {
        //the PC is dead, a life is lost and try again is displayed
        if (!butterflyPC && !PCisDestroyed)
        {
            //call reduceLife function
            scoreHealthLivesCounter.lifeLost(1);        

            //stop this if statement being true constantly
            PCisDestroyed = true;

            //start the timer til PC respawn
            timeTilRespawnActive = true;

            if(lives >= 2)
            {
                //create text
                beginTryAgain.TryAgain();
            }
        }
    }

    void createAnotherButterfly()
    {
        #region start the countdown until the PC is respawned
        //start countdown until a new PCButterfly is made set health to 1000 
        if (timeTilRespawnActive)
        {            
            //set the new butterflies health to 1000
            scoreHealthLivesCounter.alterHealth(1000);

            //countdown
            timeTilRespawn = (timeTilRespawn - (1 * Time.deltaTime));

            #region when timer runs out, recreate a PC

            //when timer runs out, create a new PC and create a new text
            if (timeTilRespawn <= 0)
            {
                //remove all bullets
                bulletManager.destroyAllEnemyBullets();

                //timer set back to one
                timeTilRespawn = 1;

                //timer is no longer counting down
                timeTilRespawnActive = false;

                //lower life count in this script
                lives = lives - 1;                

                //instantiate a new gameObejct prefab
                GameObject PC;
                PC = Instantiate(newButterfly, startPoint, Quaternion.identity) as GameObject;

                //now that the butterflyPC has come back, it's time to re-initialize it
                butterflyPC = GameObject.FindWithTag("Player");
                                
                #region set PCisDestroyed back to false if there is a butterflyPC

                //if there is a butterflyPC
                if (butterflyPC)
                {
                    //set PCisDestroyed back to false so that reduceLife can be called the next time the PC disappears
                    PCisDestroyed = false;
                }
                #endregion
            }
            #endregion
        }
        #endregion 
    }

    void gameOver()
    {
        if(lives <= 0)
        {
            LevelManager.GameOver();
        }
    }
    #endregion functions

}
