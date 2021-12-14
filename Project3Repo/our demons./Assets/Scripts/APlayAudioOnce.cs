using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APlayAudioOnce : MonoBehaviour
{
    public AudioClip SoundToPlay;
    public float Volume;
    AudioSource audioSource;
    public bool alreadyPlayed = false;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void OnTriggerEnter()
    {
        if(!alreadyPlayed)
        {
            audioSource.PlayOneShot(SoundToPlay, Volume);
            alreadyPlayed = true;
        }
    }
}
