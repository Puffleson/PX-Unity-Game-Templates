using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShootSystem : MonoBehaviour
{

    public Transform firePoint; //from where (which position) the laser will be fired
    public GameObject laserPrefab; //the object{laser} for cloning to be fired

    private void Start()
    {

        Shoot(); //calling Shoot() method at start

    }

    void Shoot() {

        StartCoroutine(Wait()); //we have created this method to wait for 3 seconds to clone the laser object

    }

    IEnumerator Wait()  //its a standalone method
    {

        yield return new WaitForSeconds(3); //Wait for 3 seconds to execute next line of code
        Instantiate(laserPrefab, firePoint.position, firePoint.rotation); //clone the laser object
        Shoot(); //calling Shoot() method again to clone the laser object again and again after waiting for 3 seconds

    }

}
