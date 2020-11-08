using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtlasBigEntranceAndDeath : MonoBehaviour
{
    #region timer floats
    //timer floats
    public float entranceTimer = 0;
    public float timeBetweenBurst = 0;
    public float timeUntilBurstsStop = 6;
    #endregion timer floats

    #region timer threshold float
    //timer threshold floats
    public float timeToBurst = 0.5f;
    #endregion timer threshold float

    #region manager scripts
    #region musicPlayer
    MusicPlayer musicPlayer;
    #endregion musicPlayer

    #region bulletManagerScript
    BulletManagerScript bulletManager;
    #endregion bulletManagerScript

    #region ScoreValue and ScoreHealthLivesCounter
    //score
    public int scoreValue = 1500;

    //scoreCounter
    private ScoreHealthLivesCounter myScoreCounter;

    #endregion ScoreValue and ScoreHealthLivesCounter
    #endregion manager scripts

    #region scripts
    //scripts
    AtlasBullets atlasBullets;
    EnemyHealth enemyHeatlh;
    SpawnEnemy spawnEnemy;    
    #endregion scripts

    #region particle gameObject

    public GameObject particles;

    #endregion particle gameObject

    #region Audio
    //audioClips
    public AudioClip poof;
    public AudioClip finalPoof;
    #endregion Audio

    //box collider
    PolygonCollider2D polyCollider2D;

	// Use this for initialization
	void Start ()
    {
        //get scripts on this object
        atlasBullets = GetComponent<AtlasBullets>();
        polyCollider2D = GetComponent<PolygonCollider2D>();
        enemyHeatlh = GetComponent<EnemyHealth>();
        spawnEnemy = transform.parent.parent.GetComponent<SpawnEnemy>();

        //music player
        musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();

        //bullet manager
        bulletManager = GameObject.FindObjectOfType<BulletManagerScript>();

        #region get score counter
        //get ScoreHealthLivesCounter from ScoreHealthLives
        myScoreCounter = GameObject.Find("ScoreHealthLives").GetComponent<ScoreHealthLivesCounter>();

        #endregion get score counter
    }

    // Update is called once per frame
    void Update ()
    {
        entrance();

        //when Atlas is out of health
        if(enemyHeatlh.health <= 0)
        {
            //clear bullets
            bulletManager.destroyAllEnemyBullets();

            //disable movement and death
            enemyHeatlh.enabled = false;
            spawnEnemy.enabled = false;
            atlasBullets.enabled = false;

            //disable soundtrack
            musicPlayer.audioSource.mute = true;

            //increase timeBetweenBurst value
            timeBetweenBurst += 1 * Time.deltaTime;

            //reduce timeUntilBustsStop
            timeUntilBurstsStop -= 1 * Time.deltaTime;

            if(timeUntilBurstsStop <= 3f)
            {
                timeToBurst = 0.125f;
            }

            if (timeUntilBurstsStop <= 1.5f)
            {
                timeToBurst = 0.0625f;
            }

            //if the time between bursts has reached half a second
            if (timeBetweenBurst >= timeToBurst && timeUntilBurstsStop > 0)
            {
                //create particles
                Instantiate(particles, transform.position + new Vector3(Random.Range(-2,2), Random.Range(-2,2), 0), Quaternion.identity);

                //play sound
                AudioSource.PlayClipAtPoint(poof, transform.position);

                timeBetweenBurst = 0;
            }

            //if its time for the bursts to stop
            if(timeUntilBurstsStop <= 0)
            {

                //enable the disabled scripts
                spawnEnemy.enabled = true;

                //play sound
                AudioSource.PlayClipAtPoint(finalPoof, transform.position);

                //music player is enabled
                musicPlayer.audioSource.mute = false;

                //send points to scoreCounter
                myScoreCounter.increaseScore(scoreValue);

                if (spawnEnemy.enabled && !musicPlayer.audioSource.mute)
                {
                    //destroy
                    Destroy(transform.gameObject);
                }
                
                print("spawn enemy is " + spawnEnemy.enabled);
            }
        }
	}    

    void entrance()
    {
        //if timer is less than 5 disable shooting and polygon collider and add to timer. Also disable SpawnEnemy so that Atlas doesn't move left to right when entering
        if (entranceTimer < 5)
        {
            atlasBullets.enabled = false;
            polyCollider2D.enabled = false;
            spawnEnemy.enabled = false;

            entranceTimer += 1 * Time.deltaTime;
        }

        else
        //otherwise enable shooting and polygon collider and allow Spawn Enemy to move Atlas
        {
            atlasBullets.enabled = true;
            polyCollider2D.enabled = true;
            spawnEnemy.enabled = true;
        }
    }

}
