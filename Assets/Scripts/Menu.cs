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
    public Button run;
    public Texture m_Texture;


    public void startGame()
    {
        /*Calls the function LoadScene that loads
         *  the scene named as "SampleScene"
         */
        SceneManager.LoadScene("SampleScene");
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
        SceneManager.LoadScene("Menu");
   
    }

    public void switchToControlScreen()
    {
        screen2.SetActive(false);
        screen1.SetActive(true);
    }



}
