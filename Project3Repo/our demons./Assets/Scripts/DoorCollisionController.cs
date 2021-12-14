using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollisionController : MonoBehaviour
{
    // scene to transition to
    public string scene;

    // if requirements in lobby are not satisfied
    public AudioClip lobbyRequirements;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered door.");
            if (PlayerManager.Instance.hasRevolver && PlayerManager.Instance.hasLantern)
            {
                XRSceneTransitionManager.Instance.TransitionTo(scene);
            }
            else
            {
                Debug.Log("Lobby reqs not met.");
                // wait if player is already speaking
                PlayerManager.Instance.WaitToSpeak(PlayerManager.Instance.audioSource.clip);
                PlayerManager.Instance.audioSource.clip = lobbyRequirements;
                PlayerManager.Instance.audioSource.Play();
            }
        }

    }
}
