using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageThePlayerButterfly : MonoBehaviour
{
    #region variables
    //float variable that decides how much damage is being done to the PC
    public int damageToPC;

    #endregion variables

    #region functions
    // a public function of type float that returns the damage
    public int GetDamage()
    {
        return damageToPC;
    }

    //function to destroy self
    public void Hit()
    {
        Destroy(gameObject);
    }
    #endregion functions
}
