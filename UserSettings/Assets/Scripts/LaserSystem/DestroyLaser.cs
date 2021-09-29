using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLaser : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) //trigger fuction
    {
        if (other.gameObject.tag == "Laser") //if collided gameObject`s tag is "Laser" then
        {
            DestroyObject(other.gameObject); //destroy the collided gameObject
        }
    }

}
