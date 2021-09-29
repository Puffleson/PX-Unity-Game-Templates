using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.UI;

//This is the function used to manage the volume slider on the menu screen. 
public class SoundControl : MonoBehaviour
{
    [SerializeField] Slider volumeSlider; // we use the Serialize field attribute when we want our variable to be private but to also show up in the editor.

    void Start() 
    {
      if (!PlayerPrefs.HasKey("musicVolume")) 
        {
            PlayerPrefs.SetFloat("musicVolume", 1);//If there isn't any saved data from the previous game session , we set the music volume to be 1. 
            //This means that our volume will be at 100%
            Load();
        }
        else
        {
            Load(); //Else if there is saved data from the previous game session we will call the 'Load' Function. 
        }
    }

    public void ChangeVolume() 
    {
        AudioListener.volume = volumeSlider.value; //Here we set the Audio listner volume to be equal to the volume slider value. 
        //This means that the volume of our game will be equal to that of the slider. 
        Save(); //Everytime the player selects their preffered volume it will be saved. 
    }
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume"); //In this code we are setting the value of the volume slider, to be equal to the value that is stored. 
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value); //We use the 'SetFloat function to save our data'. 
        //This stores the value of the volume slider into the music volume key name. 
    }
}