using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSwingEffect : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    // declared a float variable
    [SerializeField]
    private Transform rightPoint;
    // declared an rightPoint variable;
    [SerializeField]
    private Transform leftPoint;
    // declared a leftPoint variable
    private bool chop;
    // declared a boolean chop


    void Update()
    {
        if (transform.position.x >= rightPoint.position.x)
        {
            chop = true;
        }
        // if the  position of x is greater than or equal to the defined rightPoint , then set chop = true
        if (transform.position.x <= leftPoint.position.x)
        {
            chop = false;
        }
        // if the  position of x is less than or equal to the defined leftPoint , then set chop = false

        if (chop)
        {
            transform.position = Vector2.MoveTowards(transform.position, leftPoint.position, Speed * Time.deltaTime);
        }
        // if chop is true , then move the gameobject's position , to the leftPoint with a speed of "speed*Time.deltaTime"
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, rightPoint.position, Speed * Time.deltaTime);

        }
        // if chop is false , then move the gameobject's position , to the rightPoint with a speed of "speed*Time.deltaTime"

    }
}
