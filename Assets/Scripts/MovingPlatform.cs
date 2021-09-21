using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float objectSpeed;
    [SerializeField]
    private Transform rightPoint;
    [SerializeField]
    private Transform leftPoint;
    private bool isRight;

    private void OnCollisionEnter2D(Collision2D collision)
    {
         collision.transform.parent = gameObject.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.parent = null;
    }

    void Update()
    {
        // if game object position is further than the rightPoint
        if (transform.position.x >= rightPoint.position.x)
        {
            isRight = true;
        }

        // if game object position is further than the leftPoint
        if (transform.position.x <= leftPoint.position.x)
        {
            isRight = false;
        }

        // if isRight is true , then move the gameobject's position , to the leftPoint with a speed of "crusherspeed*Time.deltaTime"
        if (isRight)
        {
            transform.position = Vector2.MoveTowards(transform.position, leftPoint.position, objectSpeed * Time.deltaTime);
        }
        // if isRight is false , then move the gameobject's position , to the rightPoint with a speed of "crusherspeed*Time.deltaTime"
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, rightPoint.position, objectSpeed * Time.deltaTime);
        }


    }

}
