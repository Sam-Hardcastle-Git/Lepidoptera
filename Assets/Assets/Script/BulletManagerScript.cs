using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManagerScript : MonoBehaviour
{

    public void destroyAllEnemyBullets()
    {
        DamageThePlayerButterfly[] enemyBulletArray = GameObject.FindObjectsOfType<DamageThePlayerButterfly>();

        foreach (DamageThePlayerButterfly enemyBullet in enemyBulletArray)
            if (enemyBullet)
            {
                Destroy(enemyBullet.gameObject);
            }
    }

}
