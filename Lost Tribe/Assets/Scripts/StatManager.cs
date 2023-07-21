using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class StatManager : MonoBehaviour
{
    public static float highScore = 0;
    public static float score = 0;

    public static int coinCount = 0;
    public static int deathCount = 0;
    public static float timeElapsed = 0;

    [SerializeField] private TMP_Text coinText;
    [SerializeField] private TMP_Text deathText;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text levelText;

    void Start()
    {
        
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        coinText.text = coinCount.ToString();
        deathText.text = deathCount.ToString();
        levelText.text = SceneManager.GetActiveScene().name;

        string min = TimeSpan.FromSeconds(timeElapsed).Minutes.ToString();
        string sec = TimeSpan.FromSeconds(timeElapsed).Seconds.ToString();

        if (sec.Length == 1)
        {
            sec = "0" + sec;
        }

        timeText.text = min + ":" + sec;

        
    }
}
