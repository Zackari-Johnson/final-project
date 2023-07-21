using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{

    void Start()
    {

    }

   
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !PlayerController.isDead)
        {
            StatManager.deathCount += 1;
            PlayerController.isDead = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
