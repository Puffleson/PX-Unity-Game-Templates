using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectables : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private PlayerController playerScript;
    [SerializeField]
    private float scoreAmount = 10f;
    private float startingScore = 0f;
    private float currentScore;
    [SerializeField]
    private float healAmount = 0;

    // Runs when the script is enabled
    private void OnEnable()
    {       
        scoreText.text = startingScore.ToString(); // Sets the content of scoreText as the starting score of '0'
    }

    /* Runs when a Collider2D enters/touches the Collider2D's of the current object 
     * Uses "Is Trigger"
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Runs if a Collider2D's game object has the Tag "Player"
        if(collision.tag == "Player")
        {
            /* Increase the score in PlayerController which returns a float with the added score
             * Updates the score in currentScore
             */
            FindObjectOfType<SoundManagerScript>().Play("click"); //this will be the click sounds used to collect each collector 
            currentScore = playerScript.updateScore(scoreAmount);         
            updateScoreUI();    // Calls updateScoreUI(); function
            playerScript.healPlayerHealth(healAmount);      // Heals the player by the amount stated by the user

            // Runs if the current game object this script is attached to has the layer "Key"
            if (this.gameObject.layer == LayerMask.NameToLayer("Key"))
            {
                FindObjectOfType<SoundManagerScript>().Play("key"); //this sound will be played when the player collects the key
                playerScript.addKeyAmount();    // Increases the amount of keys collected by the player
            }

            Destroy(this.gameObject);    // Delete the game object from the game
        }
    }
        
    private void updateScoreUI()
    {
        scoreText.text = "";     // Clears current content of scoreText
        scoreText.text = currentScore.ToString();   // Changes the content to the current new score calculated
    }
}
