using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooriController : MonoBehaviour
{
    // thought about using hashes, but since it's only called once there's no point in extra computation
    public string scene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            XRSceneTransitionManager.Instance.TransitionTo(scene);
        }
    }
}
