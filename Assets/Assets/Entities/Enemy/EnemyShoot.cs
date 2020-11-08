using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    //shotsPerSecond
    public float shotsPerSecond;

    #region projectile speed and gameObject
    //Projectile speed and gameObject
    public float enemyProjectileSpeed;
    public GameObject beam;

    #endregion projectile speed and gameObject

    #region Audio
    //audioClips
    public AudioClip pop;

    #endregion Audio

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        #region Fire at random periods

        #region increase probability as time goes on
        //increase probability value as time goes on
        float probability = Time.deltaTime * shotsPerSecond;

        #endregion increase probability as time goes on

        #region call fire beam
        //call function when random value is lower than the probability value
        if (Random.value < probability)
        {
            FireBeam();
        }
        #endregion call fire beam

        #endregion Fire at random periods
    }

    void FireBeam()
    {
        #region Fire beam
        GameObject beamInstance = Instantiate(beam, transform.position, Quaternion.identity) as GameObject;
        beamInstance.GetComponent<Rigidbody2D>().velocity = new Vector3(0, enemyProjectileSpeed);

        //play sound
        AudioSource.PlayClipAtPoint(pop, transform.position);
        #endregion Fire beam
    }
}
