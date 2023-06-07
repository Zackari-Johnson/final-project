using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{

    public float speed = 30;
    private PlayerController playerControllerScript;


    public float leftBound = -15.0f;

    void Start()
    {
        playerControllerScript =
        GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
