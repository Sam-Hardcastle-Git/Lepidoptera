using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    #region variables
    //a static of type MusicPlayer called "instance". 
    //Because it's static, this variable only belongs to this class and not any class instances
    static MusicPlayer instance = null;

    //list of soundtracks
    public AudioClip[] musicArray;

    //an audio source reference
    public AudioSource audioSource;

    #endregion variables

    #region functions
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start ()
    {       
        #region destroy the music player gameObject if there's already an instance of the MusicPlayer class
        //if any music player instance exists
        if (instance != null)
        {
            //destroy self
            Destroy(gameObject);
        }
        #endregion destroy the music player gameObject if there's already an instance of the MusicPlayer class

        #region if there is no MusicPlay instance, make this one the "instance"
        //however if there is no music player instance
        else
        {
            //make this particular instance of the music player class the "instance" 
            instance = this;

            //"gameObject" refers to the gameObject that this component is attached to.
            //"Don't Destroy On Load keeps the instance of the gameObject there when a new scene is loaded, along with its components
            GameObject.DontDestroyOnLoad(gameObject);                           

            //start music for the start menu
            AudioClip startLevelMusic = musicArray[0];

            audioSource.clip = startLevelMusic;
            audioSource.Play();
        }
        #endregion if there is no MusicPlay instance, make this one the "instance"
    }

    void OnLevelWasLoaded(int level)
    {
        AudioClip gameLevelMusic = musicArray[level];

        if(level <= 1)
        {
            audioSource.clip = gameLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }

        if(level == 2)
        {
            audioSource.clip = gameLevelMusic;
            audioSource.loop = false;
            audioSource.Play();
        }        
    }

    #endregion functions
}
