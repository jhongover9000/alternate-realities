using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInterpreter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Oni"))
        {
            Debug.Log("Oni'd.");
            RevolverController.Instance.bulletCount = 6;
            //XRSceneTransitionManager.Instance.TransitionTo("Bamboo");
        }
    }
}
