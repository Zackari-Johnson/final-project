using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillOutOfBounds : MonoBehaviour
{
    public float bottomBound;

    void Update()
    {
        if (transform.position.y < -bottomBound)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
