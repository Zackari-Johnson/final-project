using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;

    public float waitTime;
    private float waitTimer;

    public bool isRideable = true;

    public int startingPoint;
    public Transform[] points;

    private Vector2 moveDirection;

    private PlayerController player;

    private bool isPlayerOn = false;

    private int i;

    void Start()
    {
        transform.position = points[startingPoint].position;
    }

    
    void Update()
    {
        //when the platform makes it to the point
        if (Vector2.Distance(transform.position, points[i].position) < 0.1f)
        {
           //change point index
            i++;

            if (waitTimer == 0)
            {
                //start waiting
                waitTimer = waitTime;
            }

            if (i == points.Length)
            {
                //loop back to first point
                i = 0;
            }
        }

        if (waitTimer > 0)
        {
            //decrease time in timer
            waitTimer -= Time.deltaTime;
        }
        else
        {
            //set time to zero if negative
            waitTimer = 0;
        }

        if (waitTimer == 0)
        {
            //move platform when time is zero
            moveDirection = (points[i].position - transform.position).normalized;
            rb.velocity = speed * moveDirection;

        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        if (isPlayerOn && isRideable)
        {
            //make the player move with the platform
            player.externalInput = rb.velocity;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        isPlayerOn = true;

        player = collision.GetComponent<PlayerController>();

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {   
        player.externalInput = new Vector2(0, 0);
        isPlayerOn = false;
        player = null;
    }
}
