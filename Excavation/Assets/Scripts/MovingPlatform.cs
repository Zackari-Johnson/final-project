using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float baseSpeed;
    public bool lerp;
    [Range(0, 2)] public float easiness;
    [Range(0, 2)] public float peakSpeed;
    [Range(0, 1)] public float partiality;
    public float waitTime;
    private float waitTimer;

    private float lerpSpeed;
    public int startingPoint;
    public Transform[] points;

    private int i;

    void Start()
    {
        transform.position = points[startingPoint].position;
    }

    
    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.01f)
        {
            i++;

            if (waitTimer == 0)
            {
                waitTimer = waitTime;
            }
            if (i == points.Length)
            {
                i = 0;
            }
        }

        if (waitTimer > 0)
        {
            waitTimer -= Time.deltaTime;
        }
        else
        {
            waitTimer = 0;
        }

        if (waitTimer <= 0)
        {
            if (lerp)
            {
                lerpSpeed = easiness * baseSpeed * Vector2.Distance(transform.position, points[i].position);
                lerpSpeed += (Vector2.Distance(transform.position, points[i].position) / baseSpeed) * peakSpeed;
                lerpSpeed = lerpSpeed * partiality + baseSpeed * (1 - partiality);

                transform.position = Vector2.MoveTowards(transform.position, points[i].position, lerpSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, points[i].position, baseSpeed * Time.deltaTime);
            }

            
        }

        

        Debug.Log(waitTimer);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
