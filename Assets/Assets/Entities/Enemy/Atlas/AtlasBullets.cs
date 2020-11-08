using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtlasBullets : MonoBehaviour
{
    #region Audio
    //audioClips
    public AudioClip pop;
    public AudioClip poof;

    #endregion Audio

    #region projectile speed and gameObject
    //Projectile speed and gameObject
    public float enemyProjectileSpeed;
    public GameObject beam;

    #endregion projectile speed and gameObject

    #region timer and timeToFire
    //timer and timeToFire
    public float timer;
    public float timeToFire;

    #endregion

    #region rotateRate
    //rotateRate
    public float rotateRate = 20;

    #endregion rotateRate

    #region spawn y axis
    public float SpawnY;
    #endregion spawn y axis

    #region angle
    //angle
    public float currentAngle = 0;

    #endregion angle

    #region bool
    //change direction
    public bool directionRight = true;
    #endregion
	
	// Update is called once per frame
	void Update ()
    {
        #region increase shotsPerSecond as time goes on
        //increase probability value as time goes on
        timer += Time.deltaTime * 1;

        #endregion 

        #region call fire beam
        //call function when random value is lower than the probability value
        if (timer >= timeToFire)
        {
            FireBeam();

            //reset timer
            timer = 0;
        }
        #endregion 

        changeProjectileDirection();
    }

    void FireBeam()
    {
        #region Fire beam
        GameObject beamInstance = Instantiate(beam, new Vector3 (transform.position.x, transform.position.y + SpawnY, 0), Quaternion.Euler(new Vector3(0,0,currentAngle))) as GameObject;

        if (currentAngle >= 0)
        {
            beamInstance.GetComponent<Rigidbody2D>().velocity = new Vector3(currentAngle / 100, (currentAngle / 100) - 0.9f);
        }

        if (currentAngle < 0)
        {
            beamInstance.GetComponent<Rigidbody2D>().velocity = new Vector3(currentAngle / 100, (((-1 * currentAngle) / 100) - 0.9f));
        }

        #region change angle
        //change angle fire direction if greater than 45 degrees
        if (directionRight)
        {
            currentAngle += rotateRate;
        }

        //change angle fire direction if less than 45 degrees
        if (!directionRight)
        {
            currentAngle -= rotateRate;
        }
        #endregion

        //play sound
        AudioSource.PlayClipAtPoint(pop, transform.position);
        #endregion 
    }

    void changeProjectileDirection()
    {
        if(currentAngle >= 80)
        {
            directionRight = false;
        }

        else if(currentAngle <= -80)
        {
            directionRight = true;
        }
    }
}
