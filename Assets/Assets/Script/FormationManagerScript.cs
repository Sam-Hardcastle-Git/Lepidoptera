using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationManagerScript : MonoBehaviour
{
    #region variables

    #region formationLists
    public GameObject[] formationList;
    public GameObject[] formationList2;
    public GameObject[] formationList3;
    #endregion formationLists

    #region formation GameObjects
    private GameObject formation;
    private GameObject formation2;
    private GameObject formation3;
    #endregion formation GameObjects

    #region formation number
    public int formationNumber = 0;
    public int formationNumber2 = 0;
    public int formationNumber3 = 0;
    #endregion formation number

    #region timer float
    public float timer = 0;
    public float resetFormationTimer = 0;
    #endregion timer float

    #region bools
    private bool bossAppeared = false;
    private bool regularMusicPlaying = true;
    #endregion bools

    #region manager scripts
    #region bulletManagerScript
    BulletManagerScript bulletManager;
    #endregion bulletManagerScript

    #region livesManagerScript
    LifeCount lifeCount;
    #endregion livesManagerScript

    #region musicPlayer
    MusicPlayer musicPlayer;
    #endregion musicPlayer

    #endregion manager scripts

    #endregion variables

    #region functions
    // Use this for initialization
    void Start ()
    {
        #region find objects of type bullet manager and life count
        //bullet manager
        bulletManager = GameObject.FindObjectOfType<BulletManagerScript>();

        //life count
        lifeCount = GameObject.FindObjectOfType<LifeCount>();

        //music player
        musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();

        #endregion find objects of type bullet manager and life count

        Instantiate(formationList[0], new Vector3(8f, 6.5f, 0f), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update ()
    {
        #region create formation
        //create a new formation if there is none
        createFormation();
        
        //formations are equal to the gameObject with the respective tag    
        formation = GameObject.FindWithTag("Formation");
        formation2 = GameObject.FindWithTag("Formation2");
        formation3 = GameObject.FindWithTag("Formation3");

        #endregion create formation

        #region increase timer values
        //set the timer
        if (timer < 0.1)
        {
            timer += 0.1f * Time.deltaTime;
        }

        if (resetFormationTimer < 0.5)
        {
            resetFormationTimer += 0.1f * Time.deltaTime;
        }

        #endregion increase timer values     

        #region reset formations
        resetFormations();
        #endregion reset formations

        #region playBossMusic
        //playBossMusic();
        #endregion playBossMusic

    }

    void createFormation()
    {
        // if there is no formation and the timer is greater than or equal to 0.5
        if (formation == null && formation2 == null && formation3 == null && timer >= 0.1 && !lifeCount.PCisDestroyed)
        {
            //destroy all bullets
            bulletManager.destroyAllEnemyBullets();

            //add one to the formation number
            if (formationNumber < 13)
            {
                formationNumber += 1;
            }

            //if the formation number limit is exceeded, reset formation number
            if (formationNumber >= 13)
            {
                formationNumber = 0;
                formationNumber2 = 0;
                formationNumber3 = 0;
            }

            //create a new formation list
            Instantiate(formationList[formationNumber], new Vector3(7.6f, 6.5f, 0f), Quaternion.identity);

            //reset timer
            timer = 0;

            #region instantiate formation 2
            // if there is no formation and the timer is greater than or equal to 0.5 and the first formation number has gone past 5
            if (formationNumber >= 6 && formationNumber < 12)
            {
                //create a new formation list
                Instantiate(formationList2[formationNumber2], new Vector3(7f, 6.5f, 0f), Quaternion.identity);

                //add one to the formation number
                if (formationNumber < 12)
                {
                    formationNumber2 += 1;
                }
            }
            #endregion instantiate formation 2

            #region instantiate formation 3
            // if there is no formation and the timer is greater than or equal to 0.5 and the first formation number has gone past 5
            if (formationNumber >= 3 && formationNumber < 12)
            {
                //create a new formation list
                Instantiate(formationList3[formationNumber3], new Vector3(7.3f, 6.5f, 0f), Quaternion.identity);

                //add one to the formation number
                if (formationNumber < 12)
                {
                    formationNumber3 += 1;
                }
            }
            #endregion instantiate formation 3
        }
    }

    void destroyAllEnemyBullets()
    {
        DamageThePlayerButterfly[] enemyBulletArray = GameObject.FindObjectsOfType<DamageThePlayerButterfly>(); 

        foreach(DamageThePlayerButterfly enemyBullet in enemyBulletArray)
        if (enemyBullet)
        {
            Destroy(enemyBullet.gameObject);
        }
    }

    void resetFormations()
    {
        SpawnEnemy[] existingFormations = GameObject.FindObjectsOfType<SpawnEnemy>();

        if (lifeCount.PCisDestroyed && resetFormationTimer >= 0.5)
        {

            //destroy all bullets
            bulletManager.destroyAllEnemyBullets();

            if (formationNumber >= 0)
            {
                formationNumber += -1;
            }

            if (formationNumber2 >= 1 && formationNumber2 <= 6)
            {
                formationNumber2 += -1;
            }

            if (formationNumber3 >= 1 && formationNumber3 <= 9)
            {
                formationNumber3 += -1;
            }

            resetFormationTimer = 0;

            foreach (SpawnEnemy existingFormation in existingFormations)
            {
                Destroy(existingFormation.gameObject);                
            }
        }
    }

    void playBossMusic()
    {
        if(formationNumber == 12 && !bossAppeared)
        {
            AudioClip bossMusic = musicPlayer.musicArray[3];

            musicPlayer.audioSource.clip = bossMusic;
            musicPlayer.audioSource.loop = true;
            musicPlayer.audioSource.Play();

            bossAppeared = true;
            regularMusicPlaying = false;
        }
     
        if (formationNumber == 0 && !regularMusicPlaying)
        {
            AudioClip regularMusic = musicPlayer.musicArray[1];

            musicPlayer.audioSource.clip = regularMusic;
            musicPlayer.audioSource.loop = true;
            musicPlayer.audioSource.Play();

            regularMusicPlaying = true;
            bossAppeared = false;
        }
    }
    #endregion 
}
