using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesSystem : MonoBehaviour
{
	
	//for live system
	public float lives = 3;
    public GameObject live1;
    public GameObject live2;
    public GameObject live3;
	
	public void deductLive()
    {

        //Deduct live and set health to full again for next live "START"

        lives += -1; //deduct live

        //Setting LIVES UI to false one by one after deducting lives
        switch (lives)
        {

            case 2: //If players live count is 2
                live1.SetActive(true); //Live UI Object 1 will be shown
                live2.SetActive(true); //Live UI Object 2 will be shown
                live3.SetActive(false); //Live UI Object 3 will not be shown (Because live count is now 2)
                break;

            case 1:
                live1.SetActive(true); //Live UI Object 1 will be shown
                live2.SetActive(false); //Live UI Object 2 will not be shown (Because live count is now 1)
                live3.SetActive(false); //Live UI Object 3 will not be shown (Because live count is now 1)
                break;

        }
		
		//Deduct live and set health to full again for next live "END"
		
	}
	
}