using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginTryAgain : MonoBehaviour
{
    //Statics
    public bool canStart = false;
    public float timeUntilDestroyText = 1;

    //bool
//    public bool timeToCallTryAgain = false;  

    //Canvases
    public Canvas begin;
    public Canvas tryAgain;

    //scripts
    private LifeCount lifeCount;
        
    // Use this for initialization
    void Start ()
    {
        //Create Begin text
        CreateBeginClone();

        //Create life text
        lifeCount = GameObject.FindObjectOfType<LifeCount>();    
	}

	// Update is called once per frame
	void Update ()
    {
        DestroyText();     
    }

    void CreateBeginClone()
    {
        Canvas beginClone;
        beginClone = Instantiate(begin, transform.position, Quaternion.identity) as Canvas;              
    }

    public void TryAgain()
    {
        Canvas tryAgainClone;
        tryAgainClone = Instantiate(tryAgain, transform.position, Quaternion.identity) as Canvas;
    }

    void DestroyText()
    {
        if (GameObject.Find("Begin!(Clone)"))
        {
            countdownToTextDisappearing();
        }

        if (GameObject.Find("TryAgain(Clone)"))
        {
            countdownToTextDisappearing();
        }

        if (timeUntilDestroyText <= 0)
        {
            Destroy(GameObject.Find("Begin!(Clone)"));

            Destroy(GameObject.Find("TryAgain(Clone)"));

            timeUntilDestroyText = 1;
        }
    }

    void countdownToTextDisappearing()
    {
        //countdown
        timeUntilDestroyText = (timeUntilDestroyText - (1 * Time.deltaTime));
    }
}
