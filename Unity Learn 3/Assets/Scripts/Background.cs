using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;

    void Start()
    {
        repeatWidth = (GetComponent<BoxCollider>().size.x / 2);
        startPos = transform.position;
    }

    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth) {
            transform.position = startPos;
        }
    }
}
