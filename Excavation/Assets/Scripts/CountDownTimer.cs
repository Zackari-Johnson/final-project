using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour
{
    private float currentTime;
    private float decimalNum;
    public float startingTime;
    public float lowTime;

    public TMP_Text countdownText;

    public Color startColor;
    public Color endColor;

    void Start()
    {
        currentTime = startingTime;
        countdownText.color = startColor;
    }


    void Update()
    {
        decimalNum = (Mathf.Round(currentTime * 1000.0f) * 0.001f);

        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;

           if (currentTime > lowTime)
            {
                countdownText.text = MathF.Round(currentTime).ToString();
            }

            else if (currentTime <= lowTime)
            {
                countdownText.text = decimalNum.ToString().Substring(0, 3);
            }


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
        countdownText.color = endColor;
    }



    void OnTimeout()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
