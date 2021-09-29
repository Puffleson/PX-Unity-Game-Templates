using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenTransitionScript : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;

    // OnClick listener function
    public void nextScene()
    {
        SceneManager.LoadScene(nextSceneName);  // Load next scene when pressing the next button
    }
}
