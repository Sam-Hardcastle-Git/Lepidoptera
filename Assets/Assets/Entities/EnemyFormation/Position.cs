using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{

    void OnDrawGizmos()
    {
        //the two arguments are positioning and radius of the sphere
        Gizmos.DrawWireSphere(transform.position, 1);
    }


}
