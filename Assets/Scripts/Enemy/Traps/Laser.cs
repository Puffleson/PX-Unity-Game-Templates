using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public BoxCollider2D damageCollider;
    public SpriteRenderer laserSpriteRenderer;
    [SerializeField]
    private float laserIntervalTime;
    [SerializeField]
    private float laserActiveTime;
    private float timer;
    private float totalLaserTime;

    // Runs when the Scene starts
    private void Start()
    {
        damageCollider.enabled = false;     // turn off the laser's Collider2D
        laserSpriteRenderer.enabled = false;       // turn off the laser's sprite
        totalLaserTime = laserIntervalTime + laserActiveTime;       // Calculates when to turn off the laser
    }

    // Runs every frame
    private void Update()
    {
        laserInterval();    // Calls laserInterval(); function
        
        // Runs when the current timer value is bigger than or equal to the time between laser activations and less than or equal to the the time until the laser turns of
        if(timer >= laserIntervalTime && timer <= totalLaserTime)
        {
            damageCollider.enabled = true;      // turn on laser Collider2D
            laserSpriteRenderer.enabled = true;     // turns on laser sprite
        }
        else if (timer >= totalLaserTime)       // Runs when timer value is bigger than or equal to the time until the laser turns off
        {
            damageCollider.enabled = false;     // turn off the laser's Collider2D
            laserSpriteRenderer.enabled = false;       // turn off the laser's sprite
            timer = 0;      // Reset timer
        }

    }

    // Adds 1 second to timer
    private void laserInterval()
    {
        timer += Time.deltaTime;
    }
}

