using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumblePlatform : MonoBehaviour
{
    [SerializeField] private float fallDelay = 1f;
    [SerializeField] private float destroyDelay = 1f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private ParticleSystem dirtPS;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        dirtPS.Play();
        yield return new WaitForSeconds(fallDelay);
        dirtPS.Play();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 1f;
        Destroy(gameObject, destroyDelay);
    }
    
}
