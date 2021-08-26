using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillEnemy : MonoBehaviour
{
    public GameObject currentEnemy;

    /* Runs when an object with a Collider2D component enters the current object the script is attached to's Collider2D
     * Uses "Is Trigger"
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Runs when the Collider2D has the tag "PlayerKillEnemy"
        if (collision.tag == "PlayerKillEnemy")
        {
            killCurrentEnemy();     //Calls killCurrentEnemy(); function
        }
    }

    // Kills the game object specified by the user
    private void killCurrentEnemy()
    {
        Destroy(currentEnemy);      // delete the game object from the scene
    }
}
