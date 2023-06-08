using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;

    private Rigidbody2D rb;
    private Transform currentPoint;

    public float moveSpeed = 0.5f;

    public float waitTime = 1.5f;
    public float waitCounter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }

    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;

        if (waitCounter == 0)
        {
            if (currentPoint == pointB.transform)
            {
                rb.velocity = new Vector2(moveSpeed, 0);
            }
            else
            {
                rb.velocity = new Vector2(-moveSpeed, 0);
            }
        }

        if (Vector2.Distance(transform.position, currentPoint.position) <= 0.05f && currentPoint == pointB.transform)
        {
            waitCounter = waitTime;
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) <= 0.05f && currentPoint == pointA.transform)
        {
            waitCounter = waitTime;
            currentPoint = pointB.transform;
        }

        if (waitCounter > 0)
        {
            waitCounter -= Time.deltaTime;
        }
        else
        {
            waitCounter = 0;
        }
        

    }
}
