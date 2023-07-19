using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitTicket : MonoBehaviour
{
    private SpriteRenderer sr;

    [SerializeField] private Sprite[] frames;
    [SerializeField] float[] keyTimes;

    [SerializeField] private bool hasCoin = false;
    public CoinCollectable coinCollectable;
    private bool coinCollected = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().moveSpeed = 5f;
            StartCoroutine(OpenAnim());

            if (hasCoin && coinCollectable == null && !coinCollected)
            {
                StatManager.coinCount += 1;
                coinCollected = true;
            }
        }
    }

    IEnumerator OpenAnim()
    {
        sr.sprite = frames[0];
        yield return new WaitForSeconds(keyTimes[0]);
        sr.sprite = frames[1];
        yield return new WaitForSeconds(keyTimes[1]);
        sr.sprite = frames[2];
        yield return new WaitForSeconds(keyTimes[2]);
        sr.sprite = frames[3];
        yield return new WaitForSeconds(keyTimes[3]);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
