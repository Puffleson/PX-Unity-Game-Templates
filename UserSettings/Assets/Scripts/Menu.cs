using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class Menu : MonoBehaviour
{
    string path;
    [SerializeField] public RawImage image;
    [SerializeField] public GameObject screen1;
    [SerializeField] public GameObject screen2;
    [SerializeField] private string menuSceneName;
    [SerializeField] private string levelOneSceneName;
    public Button run;
    public Texture m_Texture;
    /*public Text toggleMusictxt;

    private void Start()
    {
        if (SoundManagerScript.sounds.Audio.isPlaying)
        {
            toggleMusictxt.text = "OFF";
        }
        else
        {
            toggleMusictxt.text = "ON";
        }
    }

    public void MusicToggle()
    {
        if(SoundManagerScript.sounds.Audio.isPlaying)
        {
            SoundManagerScript.sounds.Audio.Pause();
            toggleMusictxt.text = "ON";
        }
        else
        {
            SoundManagerScript.sounds.Audio.Play();
            toggleMusictxt.text = "OFF";
        }
    }
    */

    public void startGame()
    {
        /*Calls the function LoadScene that loads
         *  the scene named as 
         */
        SceneManager.LoadScene(levelOneSceneName);
    }

    public void quitGame()
    {   
        /*
         * Calls the application to close
         */
        Application.Quit();
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene(menuSceneName);
   
    }

    public void switchToControlScreen()
    {
        screen2.SetActive(false);
        screen1.SetActive(true);
    }



}
