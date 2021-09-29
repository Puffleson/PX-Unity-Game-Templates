using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointResetSystem : MonoBehaviour
{
	
	//for checkpoint reset system
    public GameObject startCheck;
    public GameObject playerMain;

    //for delay effect
    public Camera mainCam;

    //for LivesSystem
    public LivesSystem gameManagerLivesSystemScript;

    public GameObject lives2remain; //screen about 2 lives left
    public GameObject life1remain; //screen about 1 life left
    
	public void resetPlayerAtStart()
    {

        //placing player at start Checkpoint "START"

        playerMain.transform.position = startCheck.transform.position; //place player again at start position (By getting the startCheck {checkpoint} position and placing the player at that position)
        delayEffect();

        //placing player at start Checkpoint "END"

    }

    private void delayEffect() {

        mainCam.cullingMask = 2; //disabling culling mask (means it will not render the other objects in the scene except for Canvas UI {delay effect} )

        switch (gameManagerLivesSystemScript.lives)
        {

            case 2: //If players live count is 2
                lives2remain.SetActive(true); //if lives count is 2 then show the screen about 2 lives left
                break;

            case 1: //If players live count is 1
                life1remain.SetActive(true); //if life count is 1 then show the screen about 1 life left
                break;

        }

        StartCoroutine(delayEffectWait()); //calling delayEffectWait method

    }

    IEnumerator delayEffectWait()  //its a standalone method
    {

        yield return new WaitForSeconds(3); //Wait for 3 seconds to execute next line of code

        lives2remain.SetActive(false); //after 3 seconds disable the text screen
        life1remain.SetActive(false); //after 3 seconds disable the text screen

        mainCam.cullingMask = -1; //enabling culling mask (means it will now render all the objects in the scene again)

    }
	
}