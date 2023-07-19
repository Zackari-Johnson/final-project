using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public static int difficulty;
    [SerializeField] private TMP_Text difText;
    private string[] difStrings = { "Hard", "Easy" };

    public void ChangeDifficulty()
    {
        difficulty += 1;
        difText.text = difStrings[difficulty % 2];

    }

    public void Back()
    {
        SceneManager.LoadScene("0_ Main Menu");
    }
}
