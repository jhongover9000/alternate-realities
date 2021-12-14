using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public AudioClip doorOpen;
    public AudioSource audioSource;

    Animator animator;

    bool IsIdle = true;

    Coroutine coroutine;

    public bool isOpen = false;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        // if player has picked up both lantern and revolver, open door
        if (PlayerManager.Instance.hasLantern && PlayerManager.Instance.hasRevolver && !isOpen)
        {
            audioSource.clip = doorOpen;
            audioSource.Play();
            animator.SetBool("isOpen", true);
            isOpen = true;
        }
        //if(isOpen && !audioSource.isPlaying)
        //{
        //    // last ditch effort - get rid of door when sfx ends
        //        //gameObject.SetActive(false);
        //}
        //if (IsIdle)
        //{
        //    coroutine = StartCoroutine(CheckReqs());
        //    IsIdle = false;
        //}

    }

    IEnumerator CheckReqs()
    {
        Debug.Log("checking.");
        // if player has picked up both lantern and revolver, open door
        if (PlayerManager.Instance.hasLantern && PlayerManager.Instance.hasRevolver && !isOpen)
        {
            Debug.Log("checks out.");
            audioSource.clip = doorOpen;
            audioSource.Play();
            animator.SetBool("isOpen", true);
            isOpen = true;
        }
        else
        {
            yield return new WaitForSeconds(1);
            IsIdle = true;
        }
        
    }

}

