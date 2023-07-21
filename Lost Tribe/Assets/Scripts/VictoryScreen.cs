using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class VictoryScreen : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text deathText;

    void Start()
    {
        StatManager.score = Mathf.Round(10550 - 8 * StatManager.timeElapsed - 15 * StatManager.deathCount + 100 * StatManager.coinCount);
        if (StatManager.score <= 0)
        {
            scoreText.text = "Score: " + StatManager.score.ToString() + " :(";
        }
        else
        {
            scoreText.text = "Score: " + StatManager.score.ToString();
        }

        if (StatManager.score > StatManager.highScore)
        {
            StatManager.highScore = StatManager.score;
        }

        deathText.text = "Deaths: " + StatManager.deathCount.ToString();
    }

    void Update()
    {
        
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("0_ Main Menu");
        StatManager.score = 0;
    }
}
