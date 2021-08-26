using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] Text score;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(PlayerPrefs.GetFloat("PlayerScore").ToString());
        //find the text asset named as "Score"
        Text score = GameObject.Find("Score").GetComponent<Text>();
        //Debug.Log(score.text);
        /*
         * Rename "Score's" text to have the Player's score
         * PlayerPrefs: gets the score that was saved in PlayerController.cs
         */
        score.text = PlayerPrefs.GetFloat("PlayerScore").ToString();
    }


}
