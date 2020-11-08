using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreDisplay : MonoBehaviour
{    
    //final score
    public int finalScore;

    //final score text
    public Text finalScoreText;

    //high score
    public int highScore;

    //high score text
    public Text highScoreText;

    // Use this for initialization
    void Start ()
    {
        UpdateTheScore();
    }	

    void UpdateTheScore()
    {
        //scores
        highScore = PlayerPrefabsManager.GetHighScoreKey();
        finalScore = PlayerPrefabsManager.GetScoreKey();

        //display scores
        highScoreText.text = "High Score: " + highScore.ToString();
        finalScoreText.text = "Your Score: " + finalScore.ToString();
    }
}
