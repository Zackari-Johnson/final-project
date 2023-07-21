using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
   public TMP_Text highScoreText;


    private void Update()
    {
        highScoreText.text = "High Score: " + StatManager.highScore.ToString();    
    }

    public void Play()
    {
        SceneManager.LoadScene("Level 1");
        StatManager.coinCount = 0;
        StatManager.deathCount = 0;
        StatManager.timeElapsed = 0;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Settings()
    {
        SceneManager.LoadScene("0_ Settings Menu");
    }
}
