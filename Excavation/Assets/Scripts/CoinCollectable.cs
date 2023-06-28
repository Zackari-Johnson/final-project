using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectable : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Sprite[] frames;
    [SerializeField] float[] keyTimes;

    private bool isIdle = true;
    private bool isSpinning = false;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isIdle && !isSpinning)
        {
            StartCoroutine(Spin());
        } 
    }

    private IEnumerator Spin()
    {
        isSpinning = true;

        sr.sprite = frames[0];
        yield return new WaitForSeconds(keyTimes[0]); // 500 ms
        sr.sprite = frames[1];
        yield return new WaitForSeconds(keyTimes[1]); // 150 ms
        sr.sprite = frames[2];
        yield return new WaitForSeconds(keyTimes[2]); // 100 ms
        sr.sprite = frames[3];
        yield return new WaitForSeconds(keyTimes[3]); // 150 ms

        isSpinning = false;

    }
}
