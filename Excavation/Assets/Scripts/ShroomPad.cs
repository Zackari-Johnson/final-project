using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomPad : MonoBehaviour
{

    private SpriteRenderer sr;

    [SerializeField] private Sprite[] frames;
    [SerializeField] float[] keyTimes;
    [SerializeField] float waitTime;
    private float waitTimer;

    public float bounceForce;

    private bool isExtended;
    private bool isRetracting;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (waitTimer > 0 && isExtended)
        {
            waitTimer -= Time.deltaTime;
        }
        else if (waitTimer <= 0 && isExtended)
        {
            waitTimer = 0;
            StartCoroutine(RetractAnim());
        }
    }
    void OnTriggerEnter2D(Collider2D body)
    {
        if (!isExtended)
        {
            StartCoroutine(ExtendAnim());
        }
        
        BouncePlayer(body);

        waitTimer = waitTime;
    }

    IEnumerator ExtendAnim()
    {
        sr.sprite = frames[0];
        yield return new WaitForSeconds(keyTimes[0]);
        sr.sprite = frames[1];
        yield return new WaitForSeconds(keyTimes[1]);
        sr.sprite = frames[2];

        isExtended = true;

        

    }

    IEnumerator RetractAnim()
    {
        if (!isRetracting)
        {
            isRetracting = true;
            sr.sprite = frames[3];
            yield return new WaitForSeconds(keyTimes[2]);
            sr.sprite = frames[4];
            yield return new WaitForSeconds(keyTimes[3]);
            sr.sprite = frames[0];

            isExtended = false;
            isRetracting = false;
        }
        
    }

    void BouncePlayer(Collider2D body)
    {
        if (body.CompareTag("Player"))
        {
            Rigidbody2D rb = body.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, bounceForce);
        } 
    }
}