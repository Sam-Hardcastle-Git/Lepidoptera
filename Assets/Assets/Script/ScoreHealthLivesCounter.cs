using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHealthLivesCounter : MonoBehaviour

{
    #region variables

    #region score and score text
    //score and scoreText
    public static int score;
    private Text scoreText;
    #endregion

    #region health and healthText
    //health and healthText
    public int health;
    private Text healthText;
    #endregion

    #region lives and liveText
    //lives and liveText
    public int live = 3;
    private Text liveText;
    #endregion

    #region classes
    //classes
    public LifeCount lifeCount;
    #endregion classes

    #endregion variables

    #region functions

    #region start function
    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        healthText = GameObject.Find("HealthText").GetComponent<Text>();
        liveText = GameObject.Find("LifeText").GetComponent<Text>();

        Reset();
    }
    #endregion start function

    #region update function
    void Update ()
    {
        #region score, lives and health text
        scoreText.text = "Score: " + score;
        healthText.text = "Health: " + health;
        liveText.text = "Lives: " + live;
        #endregion score, lives and health text

        #region pass score into final score and/or high score
        //final score
        if (lifeCount.lives <= 0)
        {
            PlayerPrefabsManager.SetScoreKey(score);

            #region new high score
            // if higher than high score, new high score
            if(score >= PlayerPrefabsManager.GetHighScoreKey())
            {
                PlayerPrefabsManager.SetHighScoreKey(score);
            }
            #endregion new high score
        }
        #endregion pass score into final score and/or high score
    }
    #endregion update function

    #region public void functions
    public void increaseScore(int point)
    {
        #region add score and display score
        score += point;

        scoreText.text = score.ToString();
        #endregion 
    }

    public void alterHealth(int alteredHealth)
    {
        #region reduce health and display health
        health = alteredHealth;

        healthText.text = health.ToString();
        #endregion
    }

    public void lifeLost(int point)
    {
        #region reduce life and display
        live -= point;

        liveText.text = live.ToString();
        #endregion
    }
    #endregion public void functions

    #region void function reset
    void Reset()
    {
        #region reset score and display
        score = 0;

        scoreText.text = score.ToString();
        #endregion
    }

    #endregion void function reset

    #endregion functions
}
