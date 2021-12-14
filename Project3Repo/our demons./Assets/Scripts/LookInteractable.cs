using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookInteractable : MonoBehaviour
{
    public float minLookDuration = 3.0f;
    public AudioClip clip;

    bool hasPlayed = false;

    Coroutine lookTimer;

    // start look timer coroutine
    public void StartTimer()
    {
        if (!hasPlayed)
        {
            lookTimer = StartCoroutine(LookTimer());
        }
    }

    // stop look timer
    public void StopTimer()
    {
        StopCoroutine(lookTimer);
    }

    IEnumerator LookTimer()
    {
        // wait for duration to make sure layer is looking at object, not just glancing
        yield return new WaitForSeconds(minLookDuration);

        // wait in case other dialogue is playing
        PlayerManager.Instance.WaitToSpeak(PlayerManager.Instance.audioSource.clip);
        PlayerManager.Instance.audioSource.clip = clip;
        PlayerManager.Instance.audioSource.Play();

        // play only once
        hasPlayed = true;
    }

    

}
