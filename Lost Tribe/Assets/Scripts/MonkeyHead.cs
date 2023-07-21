using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyHead : MonoBehaviour
{
    private float time = 0;
    private float offset;

    [Range(0, 10)] public float bobAmplifier;
    [Range(0, 10)] public float bobSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        time += Time.deltaTime;
        offset = Mathf.Sin(time * bobSpeed) * bobAmplifier;

        BobHead();
    }

    void BobHead()
    {
        transform.position = new Vector3(transform.position.x, offset, 0);
        Debug.Log(Mathf.Sin(time));
    }
}
