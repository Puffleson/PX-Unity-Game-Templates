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
