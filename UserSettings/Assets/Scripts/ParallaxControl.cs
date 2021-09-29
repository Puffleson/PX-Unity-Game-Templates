using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxControl : MonoBehaviour
{

    [SerializeField] private Vector2 parallaxEffectMultiplier;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;

    // Runs when the Scene starts
    private void Start()
    {
        cameraTransform = Camera.main.transform;        // Get the main camera's current position
        lastCameraPosition = cameraTransform.position;      // Get the main camera's last position
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;      // Get the current object's sprites component
        Texture2D texture = sprite.texture;     // Get the current object's texture properties
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;    // Calculate the total texture size
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;      // Calculate the next position for the parallax object based on the camera's position
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);      // Move the object
        lastCameraPosition = cameraTransform.position;      // Update the last position of the camera
        
        // Runs when the value of the camera minus the parallax object is the same as the total texture size
        if (cameraTransform.position.x - transform.position.x == textureUnitSizeX)
        {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;     // Set the new parallax position to move to
            transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);       // Move the object to that position
        }
    }
}
