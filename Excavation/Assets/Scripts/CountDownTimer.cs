using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    private float currentTime;
    public float startingTime;
    public float lowTime;

    public Text countdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= lowTime)
            {
                LowTime();
            }
        }
        else
        {
            OnTimeout();
        }

        countdownText.text = currentTime.ToString();
    }



    void LowTime()
    {

    }



    void OnTimeout()
    {

    }
}
