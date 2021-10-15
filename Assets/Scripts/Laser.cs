using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private BoxCollider2D damageCollider;
    private SpriteRenderer laserSpriteRenderer;
    [SerializeField]
    private float laserOffTime = 2;
    [SerializeField]
    private float laserOnTime = 3;
    private float timer;
    private float totalLaserTime;

    private void Start()
    {
        damageCollider = GetComponent<BoxCollider2D>();
        laserSpriteRenderer = GetComponent<SpriteRenderer>();

        damageCollider.enabled = false;
        laserSpriteRenderer.enabled = false;
        totalLaserTime = laserOffTime + laserOnTime;
    }

    private void Update()
    {
        laserInterval();
        if (timer >= laserOffTime && timer <= totalLaserTime)
        {
            damageCollider.enabled = true;
            laserSpriteRenderer.enabled = true;
        }
        else if (timer >= totalLaserTime)
        {
            damageCollider.enabled = false;
            laserSpriteRenderer.enabled = false;
            timer = 0;
        }

    }

    private void laserInterval()
    {
        timer += Time.deltaTime;
    }
}
