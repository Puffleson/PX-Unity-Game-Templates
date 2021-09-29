using UnityEngine;
using System;
using UnityEngine.Audio;

public class SoundManagerScript : MonoBehaviour
{
    //The main idea of this audio manager is to have a list of sounds where you can easily add or remove any sounds as you go
    public Sound[] sounds;   //this is public sound array named sound
    public AudioSource Audio;  

    void Awake() //To play sounds at the start 
    {
        foreach (Sound s in sounds)// to loop through a sound to go for each sounds and call the sounds that we want
        {
            s.source = gameObject.AddComponent<AudioSource>(); //To add an audio source component. 
           //Later when you want to play the sound you can call the play method on the AUdio Source
            s.source.clip = s.clip; // The sound we are looking at with the source will be equal to the audio source component

            s.source.volume = s.volume; //To control the volume
            s.source.pitch = s.pitch; //To control the pitch
            s.source.loop = s.loop; //To loop the audio
        }
    }

    void Start ()
    {
        Play("Theme"); //this will be the background music throughout the game 
    }

    public void Play(string name) // A new public method which will take in a string with any of our sounds
    {
        Sound s = Array.Find(sounds, sound => sound.name == name); //This will find the sound with the appropriate name
        //We store the sound that we found in the variable s
        if (s == null) //This code will end the current game object
        {
            Debug.LogWarning("Sound:" + name + "not found!"); //to not play a sound that it there
            return;
        }
        s.source.Play();
    }

}

























/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip jumpSound, collisionSound, looseSound, winSound, runSound;
    static AudioSource audioSrc; 

    // Start is called before the first frame update
    void Start()
    {
        collisionSound = Resources.Load<AudioClip> ("collision");
        jumpSound = Resources.Load<AudioClip> ("jump");
        looseSound = Resources.Load<AudioClip> ("loose");
        winSound = Resources.Load<AudioClip> ("win");
        runSound = Resources.Load<AudioClip> ("run");

        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip) {
            case "collision":
                audioSrc.PlayOneShot(collisionSound);
                break;
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "loose":
                audioSrc.PlayOneShot(looseSound);
                break;
            case "win":
                audioSrc.PlayOneShot(winSound);
                break;
            case "run":
                audioSrc.PlayOneShot(runSound);
                break;
        }

    }
}
*/
