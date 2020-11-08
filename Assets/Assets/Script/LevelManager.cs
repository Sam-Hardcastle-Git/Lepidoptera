using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string name)
    {
        //reset Lives       
        SceneManager.LoadScene(name);
    }

    public static void GameOver()
    {

        //reset canStart and timeUntilStart
//        BeginTryAgain.canStart = false;
//        BeginTryAgain.timeUntilStart = 1;       
        
        //Load lose screen       
        SceneManager.LoadScene("Lose");
    }       
}
