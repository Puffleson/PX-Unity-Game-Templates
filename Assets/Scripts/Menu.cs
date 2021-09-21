using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class Menu : MonoBehaviour
{

    [SerializeField] private string levelOneSceneName;
    [SerializeField] private string menuSceneName;
    public void startGame()
    {
        /*Calls the function LoadScene that loads
         *  the scene that the player wants to start with
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
        SceneManager.LoadScene("MenuScene");
    }
}
