using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalWinScreenScript : MonoBehaviour
{
    [SerializeField]
    private Text ScoreNumber;
    void Start()
    {        
        ScoreNumber.text = PlayerPrefs.GetFloat("TotalPlayerScore").ToString();
    }

}
