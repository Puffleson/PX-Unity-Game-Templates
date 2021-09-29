using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLoseScript : MonoBehaviour
{
    [SerializeField]
    private string loseSceneName;
    [SerializeField]
    private string winSceneName;
    [SerializeField]
    private float timeUntilWinTransition = 1f;
    public PlayerController player;
    private float currentHealth;
    private float lowHealth = 20;
    [SerializeField]
    private int keyAmountWinCondition = 1;
    private int currentKeyAmount = 0;
    [SerializeField]
    private Animator chestAnimator;
    private float currentScore = 0f;

    // Update is called once per frame
    void Update()
    {
        //checkLoseCondition();       // Calls checkLoseCondition(); function
        checkKeyAmount();       // Calls checkKeyAmount(); function

    }

    // Runs when collider2D enters the chest's trigger collider2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Runs only if the object that enters is a Player
        if (collision.tag == "Player")
        {
            // runs only when the number of keys the player has is equal to the amount of keys needed to open the chest
            if (currentKeyAmount == keyAmountWinCondition)
            {
                currentScore = player.getScore();       // Get current score
                PlayerPrefs.SetFloat("PlayerScore", currentScore);      // Set global scene variable to use in Win and Lose Scenes
                chestAnimator.SetTrigger("touchChest");     // Set trigger on touchChest animation parameter to true, allows the chest to play ChestOpened
                StartCoroutine(waitWinScreenTransition());  // stops all functions and runs this only until its done
            }
        }
    }

    // Checks if the player has died and loss yet
    private void checkLoseCondition()
    {
        currentHealth = player.getPlayerHealth();   // Get player health

        // Runs if player's current health is 0 or below
        if (currentHealth <= 0)
        {
            //TODO: Bool to turn off movements
            currentScore = player.getScore();       // Get current score
            PlayerPrefs.SetFloat("PlayerScore", currentScore);     // Set global scene variable to use in Win and Lose Scenes
            SceneManager.LoadScene(loseSceneName);      // Change to lose screen

        }

        if (currentHealth <= lowHealth)
        {
            FindObjectOfType<SoundManagerScript>().Play("PlayerDeath");
            Debug.Log("Low Health");
            //add funky music??
        }
    }

    // Check the player's current key amount
    private void checkKeyAmount()
    {
        currentKeyAmount = player.getKeyAmount();       // Get player key amount
        chestAnimator.SetInteger("currentKeyAmount", currentKeyAmount);     // Set key amount value in Animator file for chest
    }

    IEnumerator waitWinScreenTransition()
    {
        yield return new WaitForSeconds(timeUntilWinTransition);    // Wait specified amount of seconds until script continues running
        SceneManager.LoadScene(winSceneName);       // Load win screen
        
    }
}
