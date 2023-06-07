using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Vector3 spawnPos = new Vector3(25, 0, 0);


    public float startDelay = 4.0f;
    public float repeatRate = 4.0f;

    private PlayerController playerControllerScript;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);

        playerControllerScript =
        GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
          
        }
    }
}
