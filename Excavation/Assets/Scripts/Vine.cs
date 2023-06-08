using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{
    public Rigidbody2D hook;
    public GameObject[] prefabVineSegs;
    public int numLinks = 5;
    private GameObject newSeg;

    void Start()
    {
        GenerateVine();
    }

    void GenerateVine()
    {
        Rigidbody2D prevBod = hook;

        for (int i = 0; i < numLinks; i++)
        {
            newSeg = Instantiate(prefabVineSegs[0]);
            //if (i == 0)
            //{
            //    newSeg = Instantiate(prefabVineSegs[0]);
            //}

            //if (i > 0 && i < numLinks - 1)
            //{
            //    newSeg = Instantiate(prefabVineSegs[1]);
            //}

            //if (i == numLinks - 1)
            //{
            //    newSeg = Instantiate(prefabVineSegs[2]);
            //}

            newSeg.transform.parent = transform;
            newSeg.transform.position = transform.position;
            HingeJoint2D hj = newSeg.GetComponent<HingeJoint2D>();
            hj.connectedBody = prevBod;

            prevBod = newSeg.GetComponent<Rigidbody2D>();

            Debug.Log(i.ToString());

        }
    }

}
