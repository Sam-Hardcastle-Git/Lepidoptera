using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region variables

    #region motion
    //motion
    private Vector3 moveInput;
    public float speed;

    #endregion motion

    #region sprite
    //Box Collider
    BoxCollider2D boxCollider2D;

    #endregion

    #region projectile variables
    //projectile variables
    public GameObject projectile;
    public float coolDownTimer;
    public float projectileSpeed;
    public float fireRate;

    #endregion projectile variables

    #region audio
    //audio
    public AudioClip ding;

    #endregion audio

    #region sprite measurements
    private float halfSpriteWidth;
    private float halfSpriteHeight;
    #endregion sprite measurements

    #region sprite edge floats
    private float top;
    private float bottom;
    private float left;
    private float right;
    #endregion sprite edge floats

    #region canMove bools
    private bool canMoveDown = true;
    private bool canMoveUp = true;
    private bool canMoveLeft = true;
    private bool canMoveRight = true;
    #endregion canMove bools

    #endregion variables

    #region functions
    #region start and update functions
    // Use this for initialization
    void Start ()
    {
        //get the sprite renderer
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();

        //halfsprite height and width
        halfSpriteHeight = boxCollider2D.size.y / 2;
        halfSpriteWidth = boxCollider2D.size.x / 2;
    }
	
	// Update is called once per frame
	void Update ()
    {

        #region moving with Input.GetKey
        //left
        if (Input.GetKey(KeyCode.LeftArrow) && (canMoveLeft))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        //right
        if (Input.GetKey(KeyCode.RightArrow) && (canMoveRight))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        //up
        if (Input.GetKey(KeyCode.UpArrow) && (canMoveUp))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

        //down
        if (Input.GetKey(KeyCode.DownArrow) && (canMoveDown))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        #endregion moving with Input.GetKey

        #region sprite edges
        top = transform.position.y + halfSpriteHeight;
        bottom = transform.position.y - halfSpriteHeight;
        left = transform.position.x - halfSpriteWidth;
        right = transform.position.x + halfSpriteWidth;
        #endregion sprite edges

        #region press space to shoot
        if (Input.GetKey(KeyCode.F))
        {
            #region check if coolDownTimer is less than or equal to zero
            //countdown timer      
            if (coolDownTimer <= 0)
            {
                shoot();
                coolDownTimer = fireRate;
            }
            #endregion check if coolDownTimer is less than or equal to zero         

            #region lower speed
            speed = 1.5f;
            #endregion lower speed
        }

        else
            speed = 5;
        #endregion press space to shoot

        #region reset cooldown timer
        if (coolDownTimer > 0)
        {
            coolDownTimer -= 1 * Time.deltaTime;
        }
        #endregion reset cooldown timer

        stopAtBorders();
    }

    #endregion start and update functions

    #region custom functions
    void stopAtBorders()
    {
        #region stop moving below bottom edge of screen
        if (bottom <= 0)
        {
            canMoveDown = false;
        }
        else canMoveDown = true;
        #endregion stop moving below bottom edge of screen

        #region stop moving above top edge of screen
        if (top >= 5.5)
        {
            canMoveUp = false;
        }
        else canMoveUp = true;
        #endregion stop moving above top edge of screen

        #region stop moving beyond right edge of screen
        if (right >= 16)
        {
            canMoveRight = false;
        }
        else canMoveRight = true;
        #endregion stop moving beyond right edge of screen

        #region stop moving beyond left edge of screen
        if (left <= 0)
        {
            canMoveLeft = false;
        }
        else canMoveLeft = true;
        #endregion stop moving beyond left edge of screen
    }

    void shoot()
    {
        #region Fire beam

        #region create a beam and set it in motion
        GameObject beam = Instantiate(projectile, transform.position, Quaternion.Euler(new Vector3(0, 0, 180))) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed);

        #endregion create a beam and set it in motion

        #region play sound
        //play sound
        AudioSource.PlayClipAtPoint(ding, transform.position);

        #endregion play sound
        #endregion Fire beam
    }

    #endregion custom functions
    #endregion functions
}
