using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScoreScript : MonoBehaviour
{
    [SerializeField] Text score;
    
    void Start()
    {
        score.text = PlayerPrefs.GetFloat("PlayerScore").ToString();
        FindObjectOfType<SoundManagerScript>().Play("win");
    }


}
