using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{

    public float speed = 10f; //at how much speed the laser will travel
    public Rigidbody2D rb; //for getting Rigidbody2D function of the laser object

    void Start()
    {

        rb.velocity = transform.right * speed; //shooting the laser at right direction{at x-axis} at{multiply by} some speed

    }

}
