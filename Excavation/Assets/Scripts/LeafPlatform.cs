using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafPlatform : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ps.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ps.Play();
        }
    }
}
