using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    #region variables
    public float damage;

    #endregion

    #region functions

    // a public function of type float that returns the damage
    public float GetDamage()
    {
        return damage;
    }

    //function to destroy self
    public void Hit()
    {
        Destroy(gameObject);
    }

    #endregion 
}
