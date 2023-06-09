using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CountDownTimer : MonoBehaviour
{
    private float currentTime;
    
    private float decimalNum;

    public float startingTime;
    public float lowTime;

    public TMP_Text countdownText;

    void Start()
    {
        currentTime = startingTime;
    }


    void Update()
    {
        decimalNum = (Mathf.Round(currentTime * 100.0f) * 0.01f);

        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            countdownText.text = decimalNum.ToString().Substring(0, 4);

            if (currentTime <= lowTime)
            {
                LowTime();
            }
        }
        else
        {
            OnTimeout();
        }


        

        
    }



    void LowTime()
    {

    }



    void OnTimeout()
    {

    }
}
