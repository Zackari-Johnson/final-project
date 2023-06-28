using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesContainer : MonoBehaviour
{
    [SerializeField] private GameObject spikePrefab;
    [SerializeField] private int numSpikes;
    [Range(0, 4)][SerializeField] private int rotation;

    void Start()
    {
        GenerateSpikes();
        gameObject.transform.eulerAngles = Vector3.forward * rotation * 90;
    }

    void GenerateSpikes()
    {
        for (int i = 0; i < numSpikes; i++)
        {

            GameObject nextSpike = Instantiate(spikePrefab);
            nextSpike.transform.parent = transform;
            nextSpike.transform.position = transform.position + new Vector3(i * 0.5f, 0, 0);
            GameObject prevSpike = nextSpike;

        }
    }
}
