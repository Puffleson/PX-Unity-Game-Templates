using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalObjectMovement : MonoBehaviour
{
    [SerializeField]
    private float objectSpeed;
    // declared a float variable
    [SerializeField]
    private Transform upPoint;
    // declared an upPoint variable;
    [SerializeField]
    private Transform downPoint;
    // declared a downpoint variable
    private bool chop;
    // declared a boolean chop

    // When a game object's collider 2d touches with this game object's collider 2d.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.parent = gameObject.transform; // Make the player a child of the game object.
    }

    // When a game object's collider 2d that touches with this game object's collider 2d stops touching it. 
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.parent = null; // Make the player not a child of this game object.
    }

    void Update()
    {
        if (transform.position.y >= upPoint.position.y)
        {
            chop = true;
        }
        // if the  position of y is greater than or equal to the defined upoint , then set chop = true
        if (transform.position.y <= downPoint.position.y)
        {
            chop = false;
        }
        // if the  position of y is less than or equal to the defined upoint , then set chop = false

        if (chop)
        {
            transform.position = Vector2.MoveTowards(transform.position, downPoint.position, objectSpeed * Time.deltaTime);
        }
        // if chop is true , then move the gameobject's position , to the downpoint with a speed of "crusherspeed*Time.deltaTime"
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, upPoint.position, objectSpeed * Time.deltaTime);

        }
        // if chop is false , then move the gameobject's position , to the upPoint with a speed of "crusherspeed*Time.deltaTime"

    }
}
