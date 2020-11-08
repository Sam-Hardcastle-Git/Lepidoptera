using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    #region variables
    #region GameObject
    //Enemy Butterfly and KillBox GameObject
    public GameObject butterfly;
    #endregion GameObject

    #region dimensions
    //dimensions
    public float width = 10f;
    public float height = 5f;

    public float leftSideOfBorder;
    public float rightSideOfBorder;
    #endregion dimensions

    #region bool
    //Directional boolean
    public bool moveLeft = true;
    #endregion bool

    #region floats
    //public float spawn delay
    public float spawnDelay = 0.1f;

    //formation movement speed
    public float speed;
    #endregion floats
    #endregion variables

    // Use this for initialization. Create Enemy Butterfly instance and child it to the "position"
    void Start()
    {
        SpawnTilFull();
    }

    //draw a cube based on the specified dimensions
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }

	// Update is called once per frame
	void Update ()
    {
        #region formation border edges

        //find the edges of the formation border
        leftSideOfBorder = transform.position.x - (width / 2);
        rightSideOfBorder = transform.position.x + (width / 2);
        #endregion formation border edges

        #region SpawnUntilFull when everyone dies
        //If AllMembersDead() returns true
          if (AllMembersDead())
          {
//              print("all dead");

            //recreate enemies in their positions
              Destroy(gameObject);
        }
        #endregion SpawnUntilFull when everyone dies

        #region move
        if (moveLeft)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (moveLeft == false)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        #endregion move  

        ChangeDirection();
    }

    public bool AllMembersDead()
    {
        //go through every "position" and check if there is a child. For each transform component inside the Spawn Enemies "transform"...
        foreach (Transform childPositionGameObject in transform)
            {
        //if the childCount is greater than zero (childCount literally means the no of children)
                if (childPositionGameObject.childCount > 0)
                {
        //return false
                return false;
                }
            }
        //if there is no children left, then the bottom of the loop will be reached, meaning that true will be returned
                return true;        
    }

    public Transform NextFreePosition()
    {
        //go through every "position" and check if there is a child. For each transform component inside the SpawnEnemy "transform"...
        foreach (Transform childPositionGameObject in transform)
        {
            //if the childCount is equal to zero (childCount literally means the no of children)
            if (childPositionGameObject.childCount == 0)
            {
                //return a transform
                return childPositionGameObject;
            }
        }
        //if there is no children left, then the bottom of the loop will be reached, meaning that true will be returned
        return null;
    }

    void SpawnTilFull()
    {
        //This Transform is a reference to the return value of NextFreePosition, 
        //in other words, it represents a "position" without a butterfly childed to it
        Transform freePosition = NextFreePosition();

        //if there is a free position, create a GameObject for it
        if (freePosition)
        {
            //Create a butterfly instantiation in the free position
            GameObject butterflyInstance = Instantiate(butterfly, freePosition.position, Quaternion.identity) as GameObject;
            butterflyInstance.transform.parent = freePosition;

        }
        //invoke this method only if there is a free position
        if (NextFreePosition())
        {
            Invoke("SpawnTilFull", spawnDelay);
 //           print(NextFreePosition());
        }
    }

    public void ChangeDirection()
    {
        if (leftSideOfBorder <= 0)
        {
            moveLeft = false;
        }

        if (rightSideOfBorder >= 16)
        {
            moveLeft = true;
        }
    }
}
