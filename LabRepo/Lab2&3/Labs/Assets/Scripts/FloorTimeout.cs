using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTimeout : MonoBehaviour
{
    public float duration = 5.0f;
    public bool startTimer = false;
    public Transform spawnLoc;

    Coroutine timeout;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            // start timer using a coroutine
            timeout = StartCoroutine(Timeout());

        }
    }

    IEnumerator Timeout()
    {
        // yield gives control back to unity, can be called multiple times.

        // this will allow the function not to be touched for 5 seconds and returns when the time is up
        yield return new WaitForSeconds(duration);

        transform.position = spawnLoc.position;
    }

    public void ClearTimeout()
    {
        if(timeout != null)
        {
            StopCoroutine(timeout);
        }
    }
}
