using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthAndDamage : MonoBehaviour
{

    public PlayerController player;
    [SerializeField]
    private float damage;
    private bool isDead = false;

    // Runs when a game object with a collider enters and stays inside the object the script is attached to's Collider2D
    private void OnTriggerStay2D(Collider2D collision)
    {
        // Runs when the player is not dead  (health is not 0)
       if(!isDead)
       {
            // Runs when object has the Tag "Player"
            if (collision.tag == "Player")
            {
                StartCoroutine(dealDamage()); // Runs specialised function - the script pauses until the function finishes
                checkPlayerDead(); // Class checkPlayerDead(); function
            }
       }
    }

    // Deals damage to the player object
    IEnumerator dealDamage()
    {
        yield return new WaitForEndOfFrame(); // only continues when the function is finished
        player.takeDamage(damage); // Calls PlayerController and decreases the health number but the damage specified by the player
    }  
    
    // Check whether the player is dead or not
    private void checkPlayerDead()
    {
        float playerHealth = player.getPlayerHealth();  // Checks and sets the player's current health in a variable to use in checkPlayerDead()
        float minHealth = 0f;   // Minumun health to indicate the player is dead is 0

        /* Compares the player's current health to the minimum health
         * Runs when the player's current health is equal to the minimum health of 0
         */
        if(playerHealth == minHealth)
        {
            isDead = true;  // Sets variable to indicate player is dead
            this.enabled = false; // Disable this script
        }
    }
}

