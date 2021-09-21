using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    
    // Update is called once per frame
    void Update()
    {
        if(player != null)
            transform.position = new Vector3(player.position.x, player.position.y + 0.5f, transform.position.z); // Moves the camera's position to the player's current X and Y position.
            
    }
}
